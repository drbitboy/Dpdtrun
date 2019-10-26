using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rk4lib.Test
{
    ////////////////////////////////////////////////////////////////////
    // Runge-Kutta fourth-order method (Rk4lib) tests
    ////////////////////////////////////////////////////////////////////
 
    public class Parabola : Rk4_params_base     // Sub-class from Rk4lib base class
    {
        //                   2        1       0
        // Parabola:  y = a x   +  b x  +  c x
        //     also:  y = (a*x  +  b)*x +  c
        //
        //      and:  dy/dx = 2ax + b

        public double a { set; get; }
        public double b { set; get; }
        // c does not matter for testing as it is a fixed offset for y
    }
    [TestClass]
    public class Rk4libParabolaTest
    {
        static double Parabola_dydx(double x, double y, Rk4_params_base abc_base)
        {
            // Parabola dy/dx model
            Parabola lcl_abc = abc_base as Parabola;         // Cast params as Parabola object
            double dydx = (2d * lcl_abc.a * x) + lcl_abc.b;  // dy/dx = 2ax + b
            return dydx;
        }


        [TestMethod]
        public void ParabolaForward20()
        {
            // Parabola with a=2 and b=0
            Parabola abc = new Parabola() { a = 2d, b = 0d };

            // Setup RK4 dy/dx and parameters
            Rk4 rk4 = new Rk4() { dydx = Parabola_dydx, parameters = abc };

            // Setup Rk4 intgration from x=1 to x=10
            double x0 = 1d;                         // Initial x
            double y0 = (abc.a * x0 * x0) + abc.b;  // Initial y
            double h = 1d;                          // Step size
            double x = x0 + 8.9;                    // Final x

            // Integrate Rk4 algorithm stops at (x0 + N*h),
            // with N integer and N>=8.9
            List<List<double>> result = rk4.Rk4_solve(x0, y0, x, h);

            // Check lists' sizes
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(10, result[1].Count);
            Assert.AreEqual(10, result[0].Count);

            // Check values
            for (int i = 0; i < 10; ++i)
            {
                double xi = i + 1;
                Assert.IsTrue(Math.Abs(xi - result[0][i]) < 1e-10);

                double y = (abc.a * xi + abc.b) * xi;
                Assert.IsTrue(Math.Abs(y - result[1][i]) < 1e-10);
            }

        }


        [TestMethod]
        public void Parabola100ReverseNeg28()
        {
            // Test Parabola with a=-2, b=8, and negative step size
            Parabola abc = new Parabola() { a = -2d, b = 8d };
            Rk4 rk4 = new Rk4() { dydx = Parabola_dydx, parameters = abc };

            // Initial x0=100, y0=-19200;  h=-2, stop after fourth step
            List<List<double>> result = rk4.Rk4_solve(100d, -19200d, 100d-7.9d, -2d);

            // Check lists' sizes
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(5, result[1].Count);
            Assert.AreEqual(5, result[0].Count);

            // Check values
            double val = -19200d;
            for (int i = 0; i < 5; ++i)
            {
                double x = 100d - (i << 1);
                Assert.IsTrue(Math.Abs(x - result[0][i]) < 1e-10);
                Assert.IsTrue(Math.Abs(val - result[1][i]) < 1e-10);

                val -= (abc.a * 4 * (x - 1));        // (x*x) - ((x-2)*(x-2) = 4x-4
                val -= (2 * abc.b);
            }

        }
    }
}
