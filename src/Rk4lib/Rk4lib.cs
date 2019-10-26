using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rk4lib
{
    // Simple abstract Runge-Kutta 4th-order integration model
    public abstract class Rk4
    {
        // Abstract method, which will be overridden, to calculate dy/dx derivative
        // - Concrete class will typically also contain parameters used by the concrete method
        public abstract double dydx(double x, double y);

        /// <summary>
        /// Fourth-order Runge-Kutta algorithm to integrate y from x0 to x; O((x-x0)/h)
        /// </summary>
        /// <param name="x0">Inital value (condition) of independent variable</param>
        /// <param name="y0">Initial value (condition) of dependent variable</param>
        /// <param name="x">Final value of independent variable</param>
        /// <param name="h">Step size for x; h&gt;0 if x&gt;x0; h&lt;0 if x&lt0; h!=0</param>
        /// <returns>
        /// List&lt;List&lt;double&gt;&gt;
        /// - List of two lists
        ///   - First list contains x values:  [x0, x0+h, x0+2h, ..., xN]; N = floor((x-x0)/h)
        ///     - x <= xN < x+h
        ///   - Second list contains y values:  [y0, y1, y2, ..., yN]
        /// </returns>
        public List<List<double>> Rk4_solve(double x0, double y0, double x, double h)
        {
            // Setup shadow h>0, x0, x>x0 to control loop termination
            double shadow_h = h > 0 ? h : -h;
            double shadow_x0 = x0;
            double shadow_x = h > 0 ? x : ((2 * x0) - x);

            // Initialize results List of Lists with initial conditions
            List<List<double>> results = new List<List<double>>
            {
                new List<double>{ x0 },
                new List<double>{ y0 }
            };

            // Initialize values for loop
            double lcl_x = x0;                  // x
            double halfh = h / 2d;              // h/2 (effectively constant)

            // Intermediate in-loop variables
            double lcl_y = y0;                  // Estimated y
            double lcl_x_hh;                    // x + h/2
            double esty0, esty1, esty2, esty3;  // Misc calcuations for 4th-order R-K

            while (shadow_x0 < shadow_x)
            {
                shadow_x0 += shadow_h;  // Setup for loop termination check

                // Runge-Kutta 4th order model using user-supplied, concrete dydx
                esty0 = h * dydx(lcl_x,                    lcl_y               );
                esty1 = h * dydx(lcl_x_hh = lcl_x + halfh, lcl_y + (esty0 / 2d));
                esty2 = h * dydx(lcl_x_hh,                 lcl_y + (esty1 / 2d));
                esty3 = h * dydx(lcl_x += h,               lcl_y + esty2       );

                lcl_y += (esty0 + (2d * (esty1 + esty2)) + esty3) / 6d;

                // Append data to lists
                results[0].Add(lcl_x);
                results[1].Add(lcl_y);
            }
            return results;
        }
    }
}
