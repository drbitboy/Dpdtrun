using System;
using System.Collections.Generic;

namespace Dpdtrunclass
{
    ////////////////////////////////////////////////////////////////
    /// <summary>
    /// Rk4 Sub-class to support Dpdtrun:  used to calculate dy/dx
    /// (derivative) for fourth-order Runge-Kutta solution; see derivation
    /// in README.md.
    /// </summary>
    public class Dpdtrun : Rk4lib.Rk4
    {
        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///            Dpdtrun parameters
        ///            N.B. Tmr and dP(t)/dt will always have the same sign
        public double Tmr_urad { set; get; }
        public double Tmr { private set; get; }
        public double Deltay { set; get; }
        public double Vfb { set; get; }
        public double DelT { set; get; }
        public double X_cb3_limit_lo { set; get; }
        public double X_cb3_limit_hi { set; get; }
        public double X_cb3_init { set; get; }
        public double Sc_init { set; get; }

        public List<List<double>> Integration_result;


        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// Derivative calculation, for fourth-order Runge-Kutta integration
        ///
        /// Arguments
        /// ---------
        ///
        /// t    - Time at which to calculate derivative
        /// P_t  - Solved-for X component of CB3(t), current position of 
        ///        pseudo-body at which spacecraft will aim an instrument
        ///        boresight to maintain a constant angular rate of the
        ///        actual target body wrt the boresight
        ///
        /// N.B.t=0 represents start of integration, at TCA + (Sc_init / Vfb)
        /// </summary>
        public override double dydx(double t, double P_t)
        {
            double deltaX = P_t - (Vfb * t);
            return Tmr * (Deltay + (deltaX * deltaX / Deltay));
        }

        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Analytical model parameters
        /// </summary>
        public double Bsquared { set; get; }            // Maximum fractional contribution of Vfb to Tmr
        public double Broot { set; get; }               // SQRT(Bsquared - 1) or SQRT(1 - Bsquared)
        public double Constint { set; get; }            // Constant of integration
        public bool ConstintIsNaN;                      // True if Constant of integration is NaN
        public double Time_minus_TCA_0 { set; get; }    // Start time for integration
        private bool Models_uninitialized { set; get; }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Calculate per-run constants
        /// </summary>
        public void Initialize_models()
        {
            // Both models' parameters
            Tmr = Tmr_urad / 1000000d;                   // Convert microradian/s to radian/s

            if (X_cb3_limit_hi < X_cb3_limit_lo)
            {
                double xtmp = X_cb3_limit_lo;
                X_cb3_limit_lo = X_cb3_limit_hi;
                X_cb3_limit_hi = xtmp;
            }

            // Analytical model parameters
            Bsquared = Vfb / (Tmr * Deltay);             // N.B. Tmr conversion must be complete before this
            Broot = Math.Sqrt(Math.Abs(Bsquared - 1d));
            Time_minus_TCA_0 = Sc_init / Vfb;            // Start time of integration wrt TCA

            double deltaX0 = X_cb3_init - Sc_init;
            double tanTheta = deltaX0 / Deltay;

            if (Bsquared > 1d)      Constint = Math.Log((tanTheta - Broot) / (tanTheta + Broot)) / (2d * Broot); 
            else if (Bsquared < 1d) Constint = Math.Atan(tanTheta / Broot) / Broot;
            else                    Constint = -Deltay / deltaX0;

            ConstintIsNaN = Double.IsNaN(Constint);

            Models_uninitialized = false;
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Declare model parameters as not initialized
        /// </summary>
        public void Uninitialize_models()
        {
            Models_uninitialized = true;
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Calculate P(t), position of CB3 as offset from Pnom
        /// </summary>
        /// <param name="t_minus_TCA">
        /// Time at spacecraft, s past Time of Closest Approach (TCA)
        /// </param>
        /// <returns>
        /// P(t), X offset of CB3 from Pnom, double
        /// </returns>
        private double Analytical_model(double t_minus_TCA)
        {
            // Ensure per-run constants are calculated
            if (Models_uninitialized) Initialize_models();

            /*
            // Special case if constant of integration could not be calculated:
            if (ConstintIsNaN)
            {
                // - Use Rk4
                List<List<double>> lld = Rk4_solve(t_minus_TCA - timestep
                                                  , X_cb3_last
                                                  , t_minus_TCA - (timestep / 2d)
                                                  , timestep
                                                  );
                return lld[1][1];
            }
            */

            // Normal case:  X_cb3_last and timestep arguments are ignored
            double kTplusC = (Tmr * (t_minus_TCA - Time_minus_TCA_0)) + Constint;

            double deltaX;     // X offset from S/C to CB3 = [P(t) - Sc(t)]

            if (Bsquared > 1d)
            {
                double exp2BT = Math.Exp(2d * Broot * kTplusC);
                deltaX = (Deltay * Broot * (1d + exp2BT) / (1d - exp2BT));
            } 
            else if (Bsquared < 1d)
            {
                deltaX = (Deltay * Broot * Math.Tan(Broot * kTplusC));
            }
            else    // Bsquared is 1
            {
                deltaX = -(Deltay / kTplusC);
            }

            // Add deltaX to [S/C position] get CB3 X offset from Pnom, return result
            return (t_minus_TCA * Vfb) + deltaX;
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determine if the integration has reached the last timestep
        /// </summary>
        /// <param name="timestep">
        /// Integration timestep, seconds; may be positive or negative
        /// </param>
        /// <param name="P_t">
        /// P(t), current Pnom-relative X offset of CB3;
        /// P_t will be compared against one of the integration limits, X_cb3_limit_lo/_hi
        /// </param>
        /// <returns></returns>
        private bool Continue_integration(double timestep, double P_t)
        {
            // Special case to avoid infinite loops
            if (timestep == 0d) return true;

            // Increasing X with each timestep, compare against downtrack limit:
            // Forward timestep (timestep > 0), CB3 moving downtrack with time (dx/dt > 0), or
            // Backward timestep (timestep < 0), CB3 moving uptrack with time (dx/dt < 0)
            if ((timestep*Tmr) > 0d) return P_t < X_cb3_limit_hi;

            // Decreasing X with each timestep, compare against uptrack limit:
            // Forward timestep (timestep > 0), CB3 moving uptrack with time (dx/dt < 0), or
            // Backward timestep (timestep < 0), CB3 moving downtrack with time (dx/dt > 0)
            else return P_t > X_cb3_limit_lo;
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Perform integration in one direction
        /// </summary>
        /// <return>List<List<double>></double></return></returns>
        private List<List<double>> Integrate_onedir(double timestep)
        {
            ////////////////////////////////////////////////////////////
            // 1) Integrate using Analytical model
            List<List<double>> listlist = new List<List<double>>
            {
                new List<double>{ Time_minus_TCA_0 },
                new List<double>{ X_cb3_init }
            };
            int lastindex = 0;

            if (ConstintIsNaN)
            {
                // If analytical solution is not available, use Rk4 as proxy
                double X_cb3_last = X_cb3_init;
                double Time_minus_TCA_last = Time_minus_TCA_0;
                double halfstep = timestep / 2d;
                while (Continue_integration(timestep, X_cb3_last))
                {
                    listlist[0].Add(Time_minus_TCA_last + timestep);  // Next time
                    List<List<double>> 
                        shortlist = Rk4_solve(Time_minus_TCA_last
                                             , X_cb3_last
                                             , Time_minus_TCA_last + halfstep
                                             , timestep
                                             );
                    listlist[1].Add(X_cb3_last = shortlist[1][1]);    // Next Rk4 result
                    Time_minus_TCA_last = shortlist[0][1];
                    ++lastindex;
                }
            }
            else
            {
                while (Continue_integration(timestep, listlist[1][lastindex]))
                {
                    listlist[0].Add(listlist[0][lastindex] + timestep);           // Next time
                    listlist[1].Add(Analytical_model(listlist[0][++lastindex]));  // Next analytic result
                }
            }

            ////////////////////////////////////////////////////////////
            // 2) Integrate using fourth-order Runge-Kutta model

            // 2.1) Calculate stop time as one-half timestep
            //      before last time in analytic result
            double stoptime = listlist[0][lastindex] - (timestep / 2d);

            // 2.2) Perform integration
            List<List<double>> rk4listlist = Rk4_solve(Time_minus_TCA_0
                                                      , X_cb3_init
                                                      , stoptime
                                                      , timestep);

            // Append Rk4 result list; assume times are the same
            listlist.Add(rk4listlist[1]);

            return listlist;
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Perform integration based on Dpdtrun parameters,
        ///           from initial conditions to, or through, each limit"
        ///           X_cb3_limit_lo; X_cb3_limit_hi.
        /// </summary>
        /// <returns></returns>
        public void Integrate()
        {
            Initialize_models();   // Ensure models are initialized

            // Integrate in same and opposite directions as DelT parameter
            // N.B. opposite-direction lists will be reversed in-place,
            //      then have their post-reversal item removed (the initial conditions),
            //      then have same-direction lists appended (which include the initial conditions),
            //      then returned as result of this method
            List<List<double>> samedir = Integrate_onedir(DelT);
            Integration_result = Integrate_onedir(-DelT);

            // Process three lists:  time; analytical integration; rk4 integration
            for (int ilist=0; ilist < 3; ++ilist)
            {
                Integration_result[ilist].Reverse();                                      // Reverse opposite-dir lists
                Integration_result[ilist].RemoveAt(Integration_result[ilist].Count - 1);  // Drop last item
                Integration_result[ilist].AddRange(samedir[ilist]);                       // Combine same-dir lists
            }
        }


        ////////////////////////////////////////////////////////////////
        /// <summary>
        ///           Dpdtrun Constructor
        /// </summary>
        public Dpdtrun()
        {
            Uninitialize_models();
        }
    }
}
