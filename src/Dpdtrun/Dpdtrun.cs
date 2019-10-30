using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dpdtrun
{
    public partial class Form1 : Form
    {
        private static bool first_ofd_call = true;

        private Dpdtrun Dpdtrun;

        private Color log_save_color;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dpdtrun = new Dpdtrun();
            log_save_color = log_lbl.BackColor;
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (first_ofd_call)
            {
                first_ofd_call = false;
                excel_ofd.InitialDirectory = Application.StartupPath;
            }

            if (excel_ofd.ShowDialog() == DialogResult.OK)
            {
                excel_tb.Text = excel_ofd.FileName;
                excel_ofd.InitialDirectory = Path.GetFullPath(excel_ofd.FileName);
            }
        }

        private void send_log_lbl(String s, bool warn_colors = false)
        {
            log_lbl.Text = s;
            if (warn_colors)
            {
                log_lbl.BackColor = Color.Red;
                log_lbl.ForeColor = Color.White;
            } else
            {
                log_lbl.BackColor = Color.LightBlue;
                log_lbl.ForeColor = Color.Black;
            }
        }
        private double tb_to_double(TextBox tb, RadioButton rb = null)
        {
            double val;
            string txt = tb.Text;
            string tbname = tb.Name.Substring(0, tb.Name.Length - 3); // Remove _tb suffix

            try
            {
                val = Convert.ToDouble(txt);
                send_log_lbl(String.Format("Parsed [{0}] from text [{1}] in TextBox {2}", val, txt, tbname));
            }
            catch
            {
                send_log_lbl(String.Format("Failed to parse floating point value from {0}<{1}> ", tbname, txt), true);
                throw;
            }

            if ((!(rb is null)) && rb.Checked) {
                try
                {
                    if (Dpdtrun.Vfb == 0.0) throw new System.Exception();
                    val /= Dpdtrun.Vfb;
                }
                catch
                {
                    send_log_lbl(String.Format("Could not convert {0} value <{1}> from seconds to km; N.B. vFb <{2}> must be positive", tbname, txt, Dpdtrun.Vfb), true);
                    throw;
                }
            }

            return val;
        }
        private void go_btn_Click(object sender, EventArgs e)
        {
            if (true)
            {
                int tly = top_left_gb.Bottom;
                int tlx = top_left_gb.Right;
                int hgt = bottom_right_gb.Top - tly;
                int wid = bottom_right_gb.Left - tlx;
                int plot_top = excel_tb.Bottom;

                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                System.Drawing.Pen myPen = new System.Drawing.Pen(Color.Black, 2);
                System.Drawing.Graphics formGraphics;
                formGraphics = this.CreateGraphics();
                formGraphics.DrawRectangle(myPen, new Rectangle(tlx, tly, wid, hgt));
                myBrush.Dispose();
                formGraphics.Dispose();

                //return;
            }

            send_log_lbl("[Go] button clicked ...");

            try
            {
                Dpdtrun.Tmr = tb_to_double(tmr_tb);
                Dpdtrun.Deltay = tb_to_double(deltay_tb);
                Dpdtrun.Vfb = tb_to_double(vfb_tb);
                if (Dpdtrun.Vfb < 0.0)
                {
                    send_log_lbl("Vfb must be non-negative", true);
                    return;
                }
                Dpdtrun.DelT = tb_to_double(delt_tb);
                if (Dpdtrun.DelT == 0.0)
                {
                    send_log_lbl("DelT must be a non-zero value", true);
                    return;
                }
                Dpdtrun.X_cb3_init = tb_to_double(x_cb3_init_tb, xcb3_init_s_rb);
                Dpdtrun.Sc_init = tb_to_double(sc_init_tb, sc_init_s_rb);
                Dpdtrun.X_cb3_limit_lo = tb_to_double(xcb3_limit_left_tb, xcb3_s_rb);
                Dpdtrun.X_cb3_limit_hi = tb_to_double(xcb3_limit_right_tb, xcb3_s_rb);

                send_log_lbl("All input values were successfully parsed");
            }
            catch
            {
                return;
            }
        }

        private void inputs_lbl_DoubleClick(object sender, EventArgs e)
        {
            tmr_tb.Text = "427";
            deltay_tb.Text = "3000";
            vfb_tb.Text = "14.43";
            delt_tb.Text = "1";
            
            x_cb3_init_tb.Text = "0";
            
            sc_init_tb.Text = "-300";
            sc_init_s_rb.Checked = true;
            
            xcb3_limit_left_tb.Text = "-96";
            xcb3_limit_right_tb.Text = "96";
            xcb3_s_rb.Checked = true;
        }

        private void log_lbl_Click(object sender, EventArgs e)
        {
            if (log_lbl.BackColor != Color.Red)
            {
                log_lbl.Text = "";
                log_lbl.BackColor = log_save_color;
            }
        }
    }

    public class Dpdtrun : Rk4lib.Rk4
    {
        public double Tmr { set; get; }
        public double Deltay { set; get; }
        public double Vfb { set; get; }
        public double DelT { set; get; }
        public double X_cb3_limit_lo { set; get; }
        public double X_cb3_limit_hi { set; get; }
        public double X_cb3_init { set; get; }
        public double Sc_init { set; get;  }

        public override double dydx(double x0, double y0)
        {
            return 0.0;
        }
    }
}
