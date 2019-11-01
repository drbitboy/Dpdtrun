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

namespace DpdtrunUI
{
    public partial class Form1 : Form
    {
        private Dpdtrunclass.Dpdtrun Dpdtrun;

        private Color log_save_color;
        private Color constint_nan_save_color;
        private static readonly Color Color_warn = Color.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dpdtrun = new Dpdtrunclass.Dpdtrun();  // Instantiate Dpdtrun object
            log_save_color = log_lbl.BackColor;    // Save default color of Label log_lbl
            constint_nan_save_color = constint_nan_lbl.BackColor;  // Same for Constint NaN label
        }

        /// <summary>
        /// Click button to use OpenFileDialog to select eXcel filename
        /// and location to which to save data
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (excel_ofd.InitialDirectory is null)
            {
                excel_ofd.InitialDirectory = Application.StartupPath;
            }

            if (excel_ofd.ShowDialog() == DialogResult.OK)
            {
                excel_tb.Text = excel_ofd.FileName;
                excel_ofd.InitialDirectory = Path.GetFullPath(excel_ofd.FileName);
            } else
            {
                excel_tb.Text = "";
            }
        }

        /// <summary>
        /// Write string to Label log_lbl
        /// </summary>
        /// <param name="s">String content to write</param>
        /// <param name="warn_colors">
        /// If this is true, use Color_warn for background color and white for foreground,
        /// else use light blue and black
        /// </param>
        private void send_log_lbl(String s, bool warn_colors = false)
        {
            log_lbl.Text = s;
            if (warn_colors)
            {
                log_lbl.BackColor = Color_warn;
                log_lbl.ForeColor = Color.White;
            } else
            {
                log_lbl.BackColor = Color.LightBlue;
                log_lbl.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Convert TextBox .Text string to double
        /// </summary>
        /// <param name="tb">TextBox containing .Text to convert</param>
        /// <param name="rb">
        /// [Interpret units as seconds] (..._s_rb) RadioButton;
        /// if .Checked is true, divide, which is in units of seconds, by Vfb to yield km
        /// </param>
        /// <returns></returns>
        private double tb_to_double(TextBox tb, RadioButton seconds_rb = null)
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

            if ((!(seconds_rb is null)) && seconds_rb.Checked) {
                try
                {
                    if (Dpdtrun.Vfb == 0.0) throw new System.Exception();
                    val *= Dpdtrun.Vfb;
                }
                catch
                {
                    send_log_lbl(String.Format("Could not convert {0} value <{1}> from seconds to km; N.B. vFb <{2}> must be positive", tbname, txt, Dpdtrun.Vfb), true);
                    throw;
                }
            }

            return val;
        }
    
        /// <summary>
        /// Perform integration, plot resultant data,
        /// log results to Label log_lbl
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void go_btn_Click(object sender, EventArgs e)
        {
            if (true)
            {
                int tlx = top_left_gb.Right;
            }

            send_log_lbl("[Go] button clicked ...");

            try
            {
                Dpdtrun.Tmr_urad = tb_to_double(tmr_tb);     // N.B. microradian/s
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

                Dpdtrun.Uninitialize_models();
                send_log_lbl("Integrating ...");
                Dpdtrun.Integrate();
                send_log_lbl("Integration complete");

                if (Dpdtrun.ConstintIsNaN)
                {
                    constint_nan_lbl.Text = "N.B. Constant of integration is NaN; analytical solution was not used.";
                    constint_nan_lbl.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    constint_nan_lbl.Text = "Analytical solution was calculated.";
                    constint_nan_lbl.BackColor = constint_nan_save_color;
                }

                Plot_data();

                if (excel_tb.Text.EndsWith(".xls"))
                {
                    Dpdtrun.Write_xls(excel_tb.Text);
                    excel_tb.Text = "";
                    send_log_lbl("Integration complete\nwrote to eXcel file");
                }
            }
            catch (System.Exception theexcept)
            {
                if (log_lbl.BackColor != Color_warn)
                {
                    send_log_lbl(String.Format("Unknown error;\n- error message is [{0}];\n- last message was [{1}]"
                                              , theexcept.Message
                                              , log_lbl.Text)
                                , true
                                );
                }
            }
        } // private void go_btn_Click(object sender, EventArgs e)


        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// Double-click "Inputs" label Load user interface with test data
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void inputs_lbl_DoubleClick(object sender, EventArgs e)
        {
            tmr_tb.Text = "3000";              // Microradian/s
            deltay_tb.Text = "2000";           // Miss distance, km
            vfb_tb.Text = "14";                // km/s
            delt_tb.Text = "1";                // Integration time step, s
            
            x_cb3_init_tb.Text = "0";          // CB3 offset wrt Pnom, km

            sc_init_s_rb.Checked = true;       // S/C offset units will be [s past TCA]
            sc_init_tb.Text = "-200";          // S/C offset wrt Pnom, s past TCA

            xcb3_s_rb.Checked = true;          // Along track coverage units will be [equivlaent s past TCA]
            xcb3_limit_left_tb.Text = "-600";  // Uptrack coverage limit, s past TCA
            xcb3_limit_right_tb.Text = "600";  // Downtrack coverage limit, s past TCA
        }

        /// <summary>
        /// Clear log label if it is clicked and its
        /// background is not set to the warning color 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void log_lbl_Click(object sender, EventArgs e)
        {
            if (log_lbl.BackColor != Color_warn)
            {
                log_lbl.Text = "";
                log_lbl.BackColor = log_save_color;
            }
        }

        /// <summary>
        ///           XY plot scaling integrated using a Matrix
        /// </summary>
        class XYScaler
        {
            double[][] xymatrix;
            private double Low_datax { set; get; }
            private double High_datax { set; get; }
            private double Low_datay { set; get; }
            private double High_datay { set; get; }

            /// <summary>
            ///           Constructor for XYScaler
            /// </summary>
            /// <param name="lodatax">Left-most X data value to plot</param>
            /// <param name="hidatax">Right-most X data value to plot</param>
            /// <param name="loplotx">Left-most plot position in graphics coordinate system (GCS)</param>
            /// <param name="hiplotx">Right-most plot position in GCS</param>
            /// <param name="lodatay">Bottom-most Y data value to plot</param>
            /// <param name="hidatay">Top-most Y data value to plot</param>
            /// <param name="loploty">Bottom-most plot position in GCS</param>
            /// <param name="hiploty">Top-most plot position in GCS</param>
            public XYScaler(double lodatax, double hidatax, double loplotx, double hiplotx
                           , double lodatay, double hidatay, double loploty, double hiploty
                           )
            {
                xymatrix = new double[3][];
                // Populate 3x3 matrix
                double scaler = (hiplotx - loplotx) / (hidatax - lodatax);
                xymatrix[0] = new double[] { scaler, 0d, loplotx - (scaler * lodatax) };

                scaler = (hiploty - loploty) / (hidatay - lodatay);
                xymatrix[1] = new double[] { 0d, scaler, loploty - (scaler * lodatay) };

                xymatrix[1] = new double[] { 0d, 0d, 1d };

                // Save upper limits to deal with infinity
                Low_datax = lodatax;
                High_datax = hidatax;
                Low_datay = lodatay;
                High_datay = hidatay;
            }

            /// <summary>
            ///            Re-set either X row (xymatrix[0]) or Y row (xymatrix)
            /// </summary>
            /// <param name="lodata">Left-most X or bottom-most Y data value</param>
            /// <param name="hidata">Right-most X or top-most Y data value</param>
            /// <param name="loplot">Left-most or bottom-most plot position in Graphical Coordinate System (GCS)</param>
            /// <param name="hiplot">Right-most or top-most plot position in GCS</param>
            /// <param name="isX">True or false to set X or Y row, respectively</param>
            public void Setlims(double lodata, double hidata, double loplot, double hiplot, bool isX)
            {
                double scaler = (hiplot - loplot) / (hidata - lodata);
                if (isX)
                {
                    xymatrix[0] = new double[] { scaler, 0d, loplot - (scaler * lodata) };
                    Low_datax = lodata;
                    High_datax = hidata;
                }
                else
                {
                    xymatrix[1] = new double[] { 0d, scaler, loplot - (scaler * lodata) };
                    Low_datay = lodata;
                    High_datay = hidata;
                }
            }

            /// <summary>
            ///           Dot product of two vectors; unit operation of Transform
            /// </summary>
            /// <param name="v1">First 3-vector</param>
            /// <param name="v2">Secont 3-vector</param>
            /// <returns></returns>
            private double Dot(double[] v1, double[] v2)
            {
                return (v1[0] * v2[0]) + (v1[1] * v2[1]) + (v1[2] * v2[2]);
            }

            /// <summary>
            ///           Multiply vector by xymatrix
            /// </summary>
            /// <param name="v">Input 3-vector to be transformed</param>
            /// <returns>New 3-vector</returns>
            private double[] Transform(double[] v)
            {
                return new double[] { Dot(xymatrix[0], v), Dot(xymatrix[1], v), 1d };
            }

            /// <summary>
            ///           Coordinate transformation from real data to plot
            /// </summary>
            /// <param name="xval"></param>
            /// <param name="yval"></param>
            /// <returns>Point</returns>
            public Point D2p(double X, double Y)
            {
                // Store (X,Y,1) in a vector
                double[] v = new double[] { Double.IsInfinity(X) ? (X>0d ? High_datax : Low_datax) : X
                                          , Double.IsInfinity(Y) ? (X>0d ? High_datay : Low_datay) : Y
                                          , 1d
                                          };

                // Transform (X,Y) data to graphical coordinate system
                double[] mxv = Transform(v);

                // Return point
                return new Point(Convert.ToInt32(mxv[0]), Convert.ToInt32(mxv[1]));
            }

            public int D2py(double Y)
            {
                return Convert.ToInt32(Dot(xymatrix[1]
                                          , new double[] { 0d, double.IsInfinity(Y) ? High_datay : Y, 1d }
                                          )
                                      );
            }

            public int D2px(double X)
            {
                return Convert.ToInt32(Dot(xymatrix[0]
                                          , new double[] { double.IsInfinity(X) ? High_datay : X, 0d, 1d }
                                          )
                                      );
            }
        } // class XYScaler


        /// <summary>
        ///            Plotting in the form
        ///            This is re-inventing the wheel,
        ///            but it's easy and makes the app somewhat self-contained
        /// </summary>
        class Plot_surface
        {
            private int Ytop { set; get; }
            private int Ybot { set; get; }
            private int Xlft { set; get; }
            private int Xrgt { set; get; }
            private int Wid { set; get; }
            private int Hgt { set; get; }
            private Form1 F1 { set; get; }
            private XYScaler xyscal;
            private System.Drawing.Graphics F1g;
            private System.Drawing.SolidBrush F1brushblk;  // Black
            private System.Drawing.SolidBrush F1brushlty;  // LightYellow
            private System.Drawing.SolidBrush F1brushdiffs;
            private System.Drawing.Pen F1penblk;
            private System.Drawing.Pen F1penwht;
            private System.Drawing.Pen F1peninitlines;

            /// <summary>
            ///           Constructor
            /// </summary>
            /// <param name="f1">Form1 object on which to draw</param>
            public Plot_surface(Form1 f1)
            {
                F1 = f1;
                Ytop = F1.top_left_gb.Bottom;
                Xlft = F1.top_left_gb.Right;
                Ybot = F1.bottom_right_gb.Top;
                Xrgt = F1.bottom_right_gb.Left;
                Wid = Xrgt - Xlft;
                Hgt = Ybot - Ytop;
                F1g = F1.CreateGraphics();
                F1brushblk = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                F1brushlty = new System.Drawing.SolidBrush(System.Drawing.Color.LightYellow);
                F1brushdiffs = new System.Drawing.SolidBrush(F1.diffs_lbl.ForeColor);
                F1penblk = new System.Drawing.Pen(Color.Black, 2);
                F1penwht = new System.Drawing.Pen(Color.White, 2);
                F1peninitlines = new System.Drawing.Pen(F1.cb3_init_lbl.ForeColor);
            }

            ~Plot_surface()
            {
                if (!(F1brushblk is null)) F1brushblk.Dispose();
                if (!(F1brushlty is null)) F1brushlty.Dispose();
                if (!(F1penblk is null)) F1penblk.Dispose();
                if (!(F1penwht is null)) F1penwht.Dispose();
                if (!(F1peninitlines is null)) F1peninitlines.Dispose();
                if (!(F1brushdiffs is null)) F1brushdiffs.Dispose();
                if (!(F1g is null)) F1g.Dispose();
            }

            public void Setlims(double lodata, double hidata, bool isX)
            {
                if (xyscal is null)
                {
                    if (isX) { xyscal = new XYScaler(lodata, hidata, Xlft, Xrgt, 0d, 1d, 0d, 1d); }
                    else     { xyscal = new XYScaler(0d, 1d, 0d, 1d, lodata, hidata, Ybot, Ytop); }
                }
                else { xyscal.Setlims(lodata, hidata, isX ? Xlft : Ybot, isX ? Xrgt : Ytop, isX); }
            }

            private static Point Ptminus(Point p1, int offset)
            {
                return new Point(p1.X - offset, p1.Y - offset);
            }

            public void Clear() { F1g.Clear(F1.BackColor); }

            public void DrawAxes()
            {
                F1g.DrawRectangle(F1penblk, Rectangle.FromLTRB(Xlft, Ytop, Xrgt, Ybot));
            }

            /// <summary>
            ///           Draw one data point as a circle of a given diameter
            /// </summary>
            /// <param name="xdata">X data coordinate</param>
            /// <param name="ydata">Y data coordinate</param>
            /// <param name="brush">Brush to use</param>
            /// <param name="diam">Diameter of filled circle to draw</param>
            public void Spot(double xdata, double ydata, Brush brush, int diam)
            {
                int radius = diam >> 1;
                Point topleft = Ptminus(xyscal.D2p(xdata, ydata), radius);
                System.Drawing.Size sz = new Size(diam, diam);
                F1g.FillEllipse(brush, new Rectangle(topleft, sz));
            }
            public void Spots(List<double> xlist, List<double> ylist, Brush brush, int diameter)
            {
                int L = xlist.Count;
                for (int i = 0; i < L; ++i) { Spot(xlist[i], ylist[i], brush, diameter); }
            }
            public void Hline(double y, Pen pen)
            {
                int ploty = xyscal.D2py(y);
                F1g.DrawLine(pen, Xlft, ploty, Xrgt, ploty);
            }
            public void Vline(double x, Pen pen)
            {
                int iplotx = xyscal.D2px(x);
                F1g.DrawLine(pen, iplotx, Ybot, iplotx, Ytop);
            }

            static IEnumerable<double> Zipabsdiff(IEnumerable<double> anenumable, IEnumerable<double> rkenumable)
            {
                var enuman = anenumable.GetEnumerator();
                var enumrk = rkenumable.GetEnumerator();
                while (enuman.MoveNext())
                {
                    enumrk.MoveNext();
                    if (Double.IsInfinity(enuman.Current) || Double.IsInfinity(enumrk.Current)) yield return 0d;
                    yield return Math.Abs(enuman.Current - enumrk.Current);
                }
            }

            public void Do_plot(List<List<double>>listlist)
            {
                Clear();
                DrawAxes();

                // Set X limits, units are seconds
                double xmx = listlist[0][0];
                double xmn = xmx;
                foreach (double val in listlist[0])
                {
                    if (val > xmx) xmx = val;
                    else if (val < xmn) xmn = val;
                }
                Setlims(xmn, xmx, true);

                // Set ordinate limits in km
                double ymx = listlist[1][0];
                double ymn = ymx;
                foreach (List<double> ylist in listlist.GetRange(1,2))
                {
                    foreach (double val in ylist)
                    {
                        if (Double.IsInfinity(val)) continue;
                        if (val > ymx || Double.IsInfinity(ymx)) ymx = val;
                        else if (val < ymn) ymn = val;
                    }
                }
                Setlims(ymn, ymx, false);

                // Horizontal line at CB3 initial position
                Hline(F1.Dpdtrun.X_cb3_init, F1peninitlines);
                F1.cb3_init_lbl.Location = new Point(F1.cb3_init_lbl.Location.X, xyscal.D2py(F1.Dpdtrun.X_cb3_init) + 3);
                F1.cb3_init_lbl.Visible = true;

                // Vertical line at S/C initial position; convert km to seconds first
                double Sc_init_s = F1.Dpdtrun.Sc_init / F1.Dpdtrun.Vfb;
                Vline(Sc_init_s, F1peninitlines);
                F1.sc_init_lbl.Location = new Point(xyscal.D2px(Sc_init_s) + 3, F1.sc_init_lbl.Location.Y);
                F1.sc_init_lbl.Visible = true;

                // Vertical line at zero (t-TCA = 0)
                if (xmn < 0 && 0 < xmx)
                {
                    Vline(0, F1penwht);
                    F1.tca_lbl.Location = new Point(xyscal.D2px(0) + 3, F1.tca_lbl.Location.Y);
                    F1.tca_lbl.Visible = true;
                }
                else
                {
                    F1.tca_lbl.Visible = false;
                }

                // Horizontal line at zero (P(t) = Pnom = 0)
                if (ymn < 0 && 0 < ymx)
                {
                    Hline(0, F1penwht);
                    F1.pnom_lbl.Location = new Point(F1.pnom_lbl.Location.X, xyscal.D2py(0) + 3);
                    F1.pnom_lbl.Visible = true;
                }
                else
                {
                    F1.pnom_lbl.Visible = false;
                }

                // Plot analytical (listlist[1]) and Rk4 (listlist[2]) solutions
                Spots(listlist[0], listlist[1], F1brushblk, 18);
                Spots(listlist[0], listlist[2], F1brushlty, 8);

                // Plot limits:  Y min; Y max; X min; X max
                F1.ylo_lbl.Text = String.Format("{0}s|{1}km"
                                               , Math.Round(ymn / F1.Dpdtrun.Vfb, 0)
                                               , Math.Round(ymn, 0)
                                               );
                F1.ylo_lbl.Visible = true;

                F1.yhi_lbl.Text = String.Format("{0}s|{1}km"
                                               , Math.Round(ymx / F1.Dpdtrun.Vfb, 0)
                                               , Math.Round(ymx, 0)
                                               );
                F1.yhi_lbl.Visible = true;

                F1.xlo_lbl.Text = String.Format("{0}s|{1}km"
                                               , Math.Round(xmn, 0)
                                               , Math.Round(xmn * F1.Dpdtrun.Vfb, 0)
                                               );
                F1.xlo_lbl.Visible = true;

                F1.xhi_lbl.Text = String.Format("{0}s|{1}km"
                                               , Convert.ToInt32(Math.Round(xmx, 0))
                                               , Math.Round(xmx * F1.Dpdtrun.Vfb, 0)
                                               );
                F1.xhi_lbl.Visible = true;

                // Ensure X and Y labels are visible
                F1.cb3_posn_lbl.Visible = true;
                F1.sc_posn_lbl.Visible = true;



                ////////////////////////////////////////////////////////////
                // Plot log base 1000 of absolute differences between
                // analytical and RK solutions
                List<double> cb3absdiffs = Zipabsdiff(listlist[1], listlist[2]).ToList();

                // - Find maximum difference
                double cb3absdiffmx = cb3absdiffs[0];
                foreach (double val in cb3absdiffs)
                {
                    if (Double.IsInfinity(val)) continue;
                    if (val > cb3absdiffmx || Double.IsInfinity(cb3absdiffmx)) cb3absdiffmx = val;
                }

                List<Label> labels = new List<Label>
                    {
                        F1.diff_yoctom_lbl
                        , F1.diff_zeptom_lbl
                        , F1.diff_attom_lbl
                        , F1.diff_femtom_lbl
                        , F1.diff_picom_lbl
                        , F1.diff_nanom_lbl
                        , F1.diff_microm_lbl
                        , F1.diff_millim_lbl
                        , F1.diff_m_lbl
                        , F1.diff_km_lbl
                        , F1.diff_megam_lbl
                        , F1.diff_gigam_lbl
                        , F1.diff_teram_lbl
                        , F1.diff_petam_lbl
                        , F1.diff_exam_lbl
                        , F1.diff_zettam_lbl
                        , F1.diff_yottam_lbl
                    };

                // - Plot differences only if some are non-zero
                if (cb3absdiffmx == 0d)
                {
                    F1.diffs_lbl.Visible = false;
                    foreach (Label lbl in labels) lbl.Visible = false;
                }
                else
                {
                    // - Find minimum difference
                    double cb3absdiffmn = cb3absdiffmx;
                    foreach (double val in cb3absdiffs)
                    {
                        if (0d < val && val < cb3absdiffmn) cb3absdiffmn = val;
                    }

                    // - Set limits as log base 1000
                    double log1k = Math.Log(1000d);
                    double lolim = Math.Floor(Math.Log(cb3absdiffmn) / log1k) - 1;
                    double hilim = Math.Ceiling(Math.Log(cb3absdiffmx) / log1k);

                    // - Differences that are zero will be a very low logarithm
                    double zerolim = (2d * (lolim - 0.5)) - (hilim + 0.5);

                    // - Convert differences to log values
                    List<double> log1kdiffs = new List<double>(cb3absdiffs.Count);
                    foreach (double val in cb3absdiffs)
                    {
                        log1kdiffs.Add((val > 0 && !Double.IsInfinity(val)) ? (Math.Log(val) / log1k) : zerolim);
                    }

                    // Locate the bottom abscissa axis title
                    F1.sc_posn_lbl.Location = new Point((Xlft + Xrgt - F1.sc_posn_lbl.Size.Width) / 2
                                                        , F1.sc_posn_lbl.Location.Y
                                                        );

                    // Locate the left ordinate axis title
                    F1.cb3_posn_lbl.Location = new Point(F1.cb3_posn_lbl.Location.X
                                                        , (Ytop + Ybot - F1.cb3_posn_lbl.Size.Height) / 2
                                                        );

                    // - Set ordinate to log limits
                    Setlims(lolim - 0.5, hilim + 0.5, false);

                    // Make visible and locate the right ordinate axis title
                    F1.diffs_lbl.Visible = true;
                    F1.diffs_lbl.Location = new Point(F1.diffs_lbl.Location.X
                                                     , (Ytop + Ybot - F1.diffs_lbl.Size.Height) / 2
                                                     );

                    // Make visible and locate the right ordinate labels
                    foreach (Label lbl in labels)
                    {
                        try
                        {
                            double tag = Convert.ToDouble(lbl.Tag);
                            if (tag < lolim || tag > hilim) throw new Exception("ignore");
                            lbl.Location = new Point(lbl.Location.X, xyscal.D2py(tag));
                            lbl.Visible = true;
                        }
                        catch
                        {
                            lbl.Visible = false;
                        }
                    }

                    // Plot the differences between the analytical and Runge-Kutta solutions
                    Spots(listlist[0], log1kdiffs, F1brushdiffs, 3);

                } // if (cb3absdiffmx == 0d) ... else
            }
        }

        /// <summary>
        ///           Mininmal plot functionality
        /// </summary>
        private void Plot_data()
        {
            Plot_surface plot_surf = new Plot_surface(this);
            plot_surf.Do_plot(Dpdtrun.Integration_result);
        }
    }
}
