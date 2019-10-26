using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rk4lib
{

    public abstract class Rk4
    {
        public abstract double dydx(double x, double y);

        public List<List<double>> Rk4_solve(double x0, double y0, double x, double h)
        {
            double shadow_h = h > 0 ? h : -h;
            double shadow_x0 = x0;
            double shadow_x = h > 0 ? x : ((2 * x0) - x);
            double halfh = h / 2d;

            double lcl_x = x0;
            double lcl_x_hh;
            double lcl_y = y0;

            List<List<double>> lists = new List<List<double>>();
            lists.Add(new List<double>());
            lists.Add(new List<double>());

            lists[0].Add(lcl_x);
            lists[1].Add(lcl_y);

            double esty0, esty1, esty2, esty3;

            while (shadow_x0 < shadow_x)
            {
                shadow_x0 += shadow_h;

                esty0 = h * dydx(lcl_x,                    lcl_y);
                esty1 = h * dydx(lcl_x_hh = lcl_x + halfh, lcl_y + (esty0 / 2d));
                esty2 = h * dydx(lcl_x_hh,                 lcl_y + (esty1 / 2d));
                esty3 = h * dydx(lcl_x += h,               lcl_y + esty2);

                lcl_y += (esty0 + (2d * (esty1 + esty2)) + esty3) / 6d;

                lists[0].Add(lcl_x);
                lists[1].Add(lcl_y);
            }
            return lists;
        }
    }
}
