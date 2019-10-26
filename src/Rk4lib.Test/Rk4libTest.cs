using System;                       // For Math
using System.Collections.Generic;   // For List
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk4lib.Test
{
    ////////////////////////////////////////////////////////////////////
    // Runge-Kutta fourth-order method (Rk4lib) tests
    ////////////////////////////////////////////////////////////////////
 
    public class ParabolaRk4 : Rk4  // Sub-class from Rk4lib.Rk4 abstract base class
    {
        ////////////////////////////////////////////////////////////////
        //                  2       1      0
        // Parabola:  y = Ax   +  Bx  +  Cx
        //
        //      and:  dy/dx = 2Ax + B
        //
        ////////////////////////////////////////////////////////////////

        // Parameters
        public double A { set; get; }
        public double B { set; get; }
        // C does not matter for testing as it is a fixed offset for y

        // Parabola dy/dx model
        public override double dydx(double x, double y)
        {
            return (2d * A * x) + B;
        }
    }
    [TestClass]
    public class Rk4libParabolaTest
    {

        [TestMethod]
        public void ParabolaForward20()
        {
            // Parabola with A=2 and B=0
            ParabolaRk4 rk4 = new ParabolaRk4() { A = 2d, B = 0d };

            // Setup Rk4 intgration from x=1 to x=10
            double x0 = 1d;                         // Initial x
            double y0 = (rk4.A * x0 * x0) + rk4.B;  // Initial y
            double h = 1d;                          // Step size
            double x = x0 + 8.9;                    // Minimum final x

            // Integrate Rk4 algorithm stops at (x0 + N*h),
            // with N integer and N>=8.9
            List<List<double>> result = rk4.Rk4_solve(x0, y0, x, h);

            Assert.AreEqual(2, result.Count);      // Check lists' sizes
            Assert.AreEqual(10, result[0].Count);
            Assert.AreEqual(10, result[1].Count);

            // Check values
            for (int i = 0; i < 10; ++i)
            {
                double xi = i + 1;
                Assert.IsTrue(Math.Abs(xi - result[0][i]) < 1e-10);

                double y = (rk4.A * xi + rk4.B) * xi;
                Assert.IsTrue(Math.Abs(y - result[1][i]) < 1e-10);
            }

        }


        [TestMethod]
        public void Parabola100ReverseNeg28()
        {
            // Test Parabola with A=-2, B=8, and negative, non-unity step size
            ParabolaRk4 rk4 = new ParabolaRk4() { A = -2d, B = 8d };

            // Initial x0=100, y0=-19200;  h=-2, stop after fourth step
            List<List<double>> result = rk4.Rk4_solve(100d, -19200d, 100d-7.9d, -2d);

            Assert.AreEqual(2, result.Count);     // Check lists' sizes
            Assert.AreEqual(5, result[1].Count);
            Assert.AreEqual(5, result[0].Count);

            // Check values
            double val = -19200d;
            for (int i = 0; i < 5; ++i)
            {
                double x = 100d - (i << 1);
                Assert.IsTrue(Math.Abs(x - result[0][i]) < 1e-10);
                Assert.IsTrue(Math.Abs(val - result[1][i]) < 1e-10);

                val -= (rk4.A * 4 * (x - 1));        // (x*x) - ((x-2)*(x-2) = 4x-4
                val -= (2 * rk4.B);
            }

        }
    }
}
