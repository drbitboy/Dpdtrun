using System.Windows.Forms;
using System.Drawing;

namespace DpdtrunUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox dpdtrun_diagram;
            this.tmr_tb = new System.Windows.Forms.TextBox();
            this.tmr_left_lbl = new System.Windows.Forms.Label();
            this.tmi_right_lbl = new System.Windows.Forms.Label();
            this.deltay_right_lbl = new System.Windows.Forms.Label();
            this.deltay_left_lbl = new System.Windows.Forms.Label();
            this.deltay_tb = new System.Windows.Forms.TextBox();
            this.vfb_right_lbl = new System.Windows.Forms.Label();
            this.vfb_left_lbl = new System.Windows.Forms.Label();
            this.vfb_tb = new System.Windows.Forms.TextBox();
            this.delt_right_lbl = new System.Windows.Forms.Label();
            this.delt_left_lbl = new System.Windows.Forms.Label();
            this.delt_tb = new System.Windows.Forms.TextBox();
            this.go_btn = new System.Windows.Forms.Button();
            this.inputs_lbl = new System.Windows.Forms.Label();
            this.outputs_lbl = new System.Windows.Forms.Label();
            this.excel_btn = new System.Windows.Forms.Button();
            this.excel_tb = new System.Windows.Forms.TextBox();
            this.excel_ofd = new System.Windows.Forms.OpenFileDialog();
            this.xcb0km_left_lbl = new System.Windows.Forms.Label();
            this.xcb3_limit_left_tb = new System.Windows.Forms.TextBox();
            this.xcb3_limit_right_tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xcb3_s_rb = new System.Windows.Forms.RadioButton();
            this.xcb3_km_rb = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sc_init_s_rb = new System.Windows.Forms.RadioButton();
            this.sc_km_rb = new System.Windows.Forms.RadioButton();
            this.scinit_left_lbl = new System.Windows.Forms.Label();
            this.sc_init_tb = new System.Windows.Forms.TextBox();
            this.log_lbl = new System.Windows.Forms.Label();
            this.xcb3_init = new System.Windows.Forms.Label();
            this.x_cb3_init_tb = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xcb3_init_s_rb = new System.Windows.Forms.RadioButton();
            this.xcb3_init_km_rb = new System.Windows.Forms.RadioButton();
            this.bottom_right_gb = new System.Windows.Forms.GroupBox();
            this.top_left_gb = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.constint_nan_lbl = new System.Windows.Forms.Label();
            this.ylo_lbl = new System.Windows.Forms.Label();
            this.yhi_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xlo_lbl = new System.Windows.Forms.Label();
            this.xhi_lbl = new System.Windows.Forms.Label();
            this.sc_posn_lbl = new System.Windows.Forms.Label();
            this.cb3_posn_lbl = new System.Windows.Forms.Label();
            this.tca_lbl = new System.Windows.Forms.Label();
            this.pnom_lbl = new System.Windows.Forms.Label();
            this.cb3_init_lbl = new System.Windows.Forms.Label();
            this.sc_init_lbl = new System.Windows.Forms.Label();
            this.diffs_lbl = new System.Windows.Forms.Label();
            this.diff_yoctom_lbl = new System.Windows.Forms.Label();
            this.diff_zeptom_lbl = new System.Windows.Forms.Label();
            this.diff_attom_lbl = new System.Windows.Forms.Label();
            this.diff_femtom_lbl = new System.Windows.Forms.Label();
            this.diff_picom_lbl = new System.Windows.Forms.Label();
            this.diff_nanom_lbl = new System.Windows.Forms.Label();
            this.diff_microm_lbl = new System.Windows.Forms.Label();
            this.diff_millim_lbl = new System.Windows.Forms.Label();
            this.diff_m_lbl = new System.Windows.Forms.Label();
            this.diff_km_lbl = new System.Windows.Forms.Label();
            this.diff_megam_lbl = new System.Windows.Forms.Label();
            this.diff_gigam_lbl = new System.Windows.Forms.Label();
            this.diff_teram_lbl = new System.Windows.Forms.Label();
            this.diff_petam_lbl = new System.Windows.Forms.Label();
            this.diff_exam_lbl = new System.Windows.Forms.Label();
            this.diff_zettam_lbl = new System.Windows.Forms.Label();
            this.diff_yottam_lbl = new System.Windows.Forms.Label();
            dpdtrun_diagram = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpdtrun_diagram
            // 
            dpdtrun_diagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dpdtrun_diagram.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dpdtrun_diagram.BackgroundImage = global::Dpdtrun.Properties.Resources.dpdtrun_diagram_wonb;
            dpdtrun_diagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            dpdtrun_diagram.Location = new System.Drawing.Point(373, -7);
            dpdtrun_diagram.Margin = new System.Windows.Forms.Padding(0);
            dpdtrun_diagram.Name = "dpdtrun_diagram";
            dpdtrun_diagram.Padding = new System.Windows.Forms.Padding(0);
            dpdtrun_diagram.Size = new System.Drawing.Size(472, 295);
            dpdtrun_diagram.TabIndex = 1200;
            dpdtrun_diagram.TabStop = false;
            // 
            // tmr_tb
            // 
            this.tmr_tb.Location = new System.Drawing.Point(101, 34);
            this.tmr_tb.Name = "tmr_tb";
            this.tmr_tb.Size = new System.Drawing.Size(122, 20);
            this.tmr_tb.TabIndex = 0;
            // 
            // tmr_left_lbl
            // 
            this.tmr_left_lbl.AutoSize = true;
            this.tmr_left_lbl.Location = new System.Drawing.Point(64, 37);
            this.tmr_left_lbl.Name = "tmr_left_lbl";
            this.tmr_left_lbl.Size = new System.Drawing.Size(31, 13);
            this.tmr_left_lbl.TabIndex = 199;
            this.tmr_left_lbl.Text = "TMR";
            this.tmr_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmi_right_lbl
            // 
            this.tmi_right_lbl.AutoSize = true;
            this.tmi_right_lbl.Location = new System.Drawing.Point(229, 28);
            this.tmi_right_lbl.Name = "tmi_right_lbl";
            this.tmi_right_lbl.Size = new System.Drawing.Size(140, 26);
            this.tmi_right_lbl.TabIndex = 299;
            this.tmi_right_lbl.Text = "Target Motion Rate,\r\nmicrorad/s (sequenced rate)";
            // 
            // deltay_right_lbl
            // 
            this.deltay_right_lbl.AutoSize = true;
            this.deltay_right_lbl.Location = new System.Drawing.Point(229, 63);
            this.deltay_right_lbl.Name = "deltay_right_lbl";
            this.deltay_right_lbl.Size = new System.Drawing.Size(117, 13);
            this.deltay_right_lbl.TabIndex = 599;
            this.deltay_right_lbl.Text = "Flyby miss distance, km";
            // 
            // deltay_left_lbl
            // 
            this.deltay_left_lbl.AutoSize = true;
            this.deltay_left_lbl.Location = new System.Drawing.Point(58, 63);
            this.deltay_left_lbl.Name = "deltay_left_lbl";
            this.deltay_left_lbl.Size = new System.Drawing.Size(37, 13);
            this.deltay_left_lbl.TabIndex = 499;
            this.deltay_left_lbl.Text = "deltaY";
            this.deltay_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deltay_tb
            // 
            this.deltay_tb.Location = new System.Drawing.Point(101, 60);
            this.deltay_tb.Name = "deltay_tb";
            this.deltay_tb.Size = new System.Drawing.Size(122, 20);
            this.deltay_tb.TabIndex = 1;
            // 
            // vfb_right_lbl
            // 
            this.vfb_right_lbl.AutoSize = true;
            this.vfb_right_lbl.Location = new System.Drawing.Point(229, 89);
            this.vfb_right_lbl.Name = "vfb_right_lbl";
            this.vfb_right_lbl.Size = new System.Drawing.Size(100, 13);
            this.vfb_right_lbl.TabIndex = 899;
            this.vfb_right_lbl.Text = "Flyby velocity, km/s";
            // 
            // vfb_left_lbl
            // 
            this.vfb_left_lbl.AutoSize = true;
            this.vfb_left_lbl.Location = new System.Drawing.Point(70, 89);
            this.vfb_left_lbl.Name = "vfb_left_lbl";
            this.vfb_left_lbl.Size = new System.Drawing.Size(25, 13);
            this.vfb_left_lbl.TabIndex = 799;
            this.vfb_left_lbl.Text = "vFb";
            this.vfb_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vfb_tb
            // 
            this.vfb_tb.Location = new System.Drawing.Point(101, 86);
            this.vfb_tb.Name = "vfb_tb";
            this.vfb_tb.Size = new System.Drawing.Size(122, 20);
            this.vfb_tb.TabIndex = 2;
            // 
            // delt_right_lbl
            // 
            this.delt_right_lbl.AutoSize = true;
            this.delt_right_lbl.Location = new System.Drawing.Point(229, 115);
            this.delt_right_lbl.Name = "delt_right_lbl";
            this.delt_right_lbl.Size = new System.Drawing.Size(61, 13);
            this.delt_right_lbl.TabIndex = 1199;
            this.delt_right_lbl.Text = "Timestep, s";
            // 
            // delt_left_lbl
            // 
            this.delt_left_lbl.AutoSize = true;
            this.delt_left_lbl.Location = new System.Drawing.Point(65, 115);
            this.delt_left_lbl.Name = "delt_left_lbl";
            this.delt_left_lbl.Size = new System.Drawing.Size(30, 13);
            this.delt_left_lbl.TabIndex = 1099;
            this.delt_left_lbl.Text = "DelT";
            this.delt_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // delt_tb
            // 
            this.delt_tb.Location = new System.Drawing.Point(101, 112);
            this.delt_tb.Name = "delt_tb";
            this.delt_tb.Size = new System.Drawing.Size(122, 20);
            this.delt_tb.TabIndex = 3;
            // 
            // go_btn
            // 
            this.go_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.go_btn.Location = new System.Drawing.Point(101, 216);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(122, 33);
            this.go_btn.TabIndex = 8;
            this.go_btn.Text = "Integrate";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.go_btn_Click);
            // 
            // inputs_lbl
            // 
            this.inputs_lbl.AutoSize = true;
            this.inputs_lbl.Location = new System.Drawing.Point(12, 11);
            this.inputs_lbl.Name = "inputs_lbl";
            this.inputs_lbl.Size = new System.Drawing.Size(36, 13);
            this.inputs_lbl.TabIndex = 16;
            this.inputs_lbl.Text = "Inputs";
            this.inputs_lbl.DoubleClick += new System.EventHandler(this.inputs_lbl_DoubleClick);
            // 
            // outputs_lbl
            // 
            this.outputs_lbl.AutoSize = true;
            this.outputs_lbl.Location = new System.Drawing.Point(12, 302);
            this.outputs_lbl.Name = "outputs_lbl";
            this.outputs_lbl.Size = new System.Drawing.Size(44, 13);
            this.outputs_lbl.TabIndex = 17;
            this.outputs_lbl.Text = "Outputs";
            // 
            // excel_btn
            // 
            this.excel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excel_btn.Location = new System.Drawing.Point(48, 325);
            this.excel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.excel_btn.Name = "excel_btn";
            this.excel_btn.Size = new System.Drawing.Size(31, 20);
            this.excel_btn.TabIndex = 9;
            this.excel_btn.Text = "...";
            this.excel_btn.UseVisualStyleBackColor = true;
            this.excel_btn.Click += new System.EventHandler(this.excel_btn_Click);
            // 
            // excel_tb
            // 
            this.excel_tb.Location = new System.Drawing.Point(82, 326);
            this.excel_tb.Name = "excel_tb";
            this.excel_tb.Size = new System.Drawing.Size(757, 20);
            this.excel_tb.TabIndex = 9;
            // 
            // excel_ofd
            // 
            this.excel_ofd.CheckFileExists = false;
            this.excel_ofd.FileName = "dpdtrun00.xls";
            this.excel_ofd.Filter = "eXcel files (*.xls)|*.xls|HTML files (*.html)|*.html|All files (*.*)|*.*";
            this.excel_ofd.InitialDirectory = ".\\";
            this.excel_ofd.Title = "eXcel file to save dP/dt run data";
            // 
            // xcb0km_left_lbl
            // 
            this.xcb0km_left_lbl.AutoSize = true;
            this.xcb0km_left_lbl.Location = new System.Drawing.Point(33, 190);
            this.xcb0km_left_lbl.Name = "xcb0km_left_lbl";
            this.xcb0km_left_lbl.Size = new System.Drawing.Size(62, 13);
            this.xcb0km_left_lbl.TabIndex = 21;
            this.xcb0km_left_lbl.Text = "X CB3 limits";
            this.xcb0km_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xcb3_limit_left_tb
            // 
            this.xcb3_limit_left_tb.Location = new System.Drawing.Point(101, 190);
            this.xcb3_limit_left_tb.Name = "xcb3_limit_left_tb";
            this.xcb3_limit_left_tb.Size = new System.Drawing.Size(62, 20);
            this.xcb3_limit_left_tb.TabIndex = 6;
            // 
            // xcb3_limit_right_tb
            // 
            this.xcb3_limit_right_tb.Location = new System.Drawing.Point(164, 190);
            this.xcb3_limit_right_tb.Name = "xcb3_limit_right_tb";
            this.xcb3_limit_right_tb.Size = new System.Drawing.Size(59, 20);
            this.xcb3_limit_right_tb.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xcb3_s_rb);
            this.groupBox1.Controls.Add(this.xcb3_km_rb);
            this.groupBox1.Location = new System.Drawing.Point(228, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 31);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // xcb3_s_rb
            // 
            this.xcb3_s_rb.AutoSize = true;
            this.xcb3_s_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xcb3_s_rb.ForeColor = System.Drawing.Color.Blue;
            this.xcb3_s_rb.Location = new System.Drawing.Point(51, 9);
            this.xcb3_s_rb.Name = "xcb3_s_rb";
            this.xcb3_s_rb.Size = new System.Drawing.Size(31, 17);
            this.xcb3_s_rb.TabIndex = 1;
            this.xcb3_s_rb.Text = "s";
            this.xcb3_s_rb.UseVisualStyleBackColor = true;
            // 
            // xcb3_km_rb
            // 
            this.xcb3_km_rb.AutoSize = true;
            this.xcb3_km_rb.Checked = true;
            this.xcb3_km_rb.Location = new System.Drawing.Point(6, 9);
            this.xcb3_km_rb.Name = "xcb3_km_rb";
            this.xcb3_km_rb.Size = new System.Drawing.Size(39, 17);
            this.xcb3_km_rb.TabIndex = 0;
            this.xcb3_km_rb.TabStop = true;
            this.xcb3_km_rb.Text = "km";
            this.xcb3_km_rb.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sc_init_s_rb);
            this.groupBox2.Controls.Add(this.sc_km_rb);
            this.groupBox2.Location = new System.Drawing.Point(228, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 31);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // sc_init_s_rb
            // 
            this.sc_init_s_rb.AutoSize = true;
            this.sc_init_s_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sc_init_s_rb.ForeColor = System.Drawing.Color.Blue;
            this.sc_init_s_rb.Location = new System.Drawing.Point(51, 9);
            this.sc_init_s_rb.Name = "sc_init_s_rb";
            this.sc_init_s_rb.Size = new System.Drawing.Size(31, 17);
            this.sc_init_s_rb.TabIndex = 1;
            this.sc_init_s_rb.Text = "s";
            this.sc_init_s_rb.UseVisualStyleBackColor = true;
            // 
            // sc_km_rb
            // 
            this.sc_km_rb.AutoSize = true;
            this.sc_km_rb.Checked = true;
            this.sc_km_rb.Location = new System.Drawing.Point(6, 9);
            this.sc_km_rb.Name = "sc_km_rb";
            this.sc_km_rb.Size = new System.Drawing.Size(39, 17);
            this.sc_km_rb.TabIndex = 0;
            this.sc_km_rb.TabStop = true;
            this.sc_km_rb.Text = "km";
            this.sc_km_rb.UseVisualStyleBackColor = true;
            // 
            // scinit_left_lbl
            // 
            this.scinit_left_lbl.AutoSize = true;
            this.scinit_left_lbl.Location = new System.Drawing.Point(43, 164);
            this.scinit_left_lbl.Name = "scinit_left_lbl";
            this.scinit_left_lbl.Size = new System.Drawing.Size(52, 13);
            this.scinit_left_lbl.TabIndex = 26;
            this.scinit_left_lbl.Text = "X S/C init";
            this.scinit_left_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sc_init_tb
            // 
            this.sc_init_tb.Location = new System.Drawing.Point(101, 164);
            this.sc_init_tb.Name = "sc_init_tb";
            this.sc_init_tb.Size = new System.Drawing.Size(122, 20);
            this.sc_init_tb.TabIndex = 5;
            // 
            // log_lbl
            // 
            this.log_lbl.AutoSize = true;
            this.log_lbl.Location = new System.Drawing.Point(4, 253);
            this.log_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.log_lbl.Name = "log_lbl";
            this.log_lbl.Size = new System.Drawing.Size(0, 13);
            this.log_lbl.TabIndex = 29;
            this.log_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.log_lbl.Click += new System.EventHandler(this.log_lbl_Click);
            // 
            // xcb3_init
            // 
            this.xcb3_init.AutoSize = true;
            this.xcb3_init.Location = new System.Drawing.Point(42, 142);
            this.xcb3_init.Name = "xcb3_init";
            this.xcb3_init.Size = new System.Drawing.Size(53, 13);
            this.xcb3_init.TabIndex = 33;
            this.xcb3_init.Text = "X CB3 init";
            this.xcb3_init.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // x_cb3_init_tb
            // 
            this.x_cb3_init_tb.Location = new System.Drawing.Point(101, 138);
            this.x_cb3_init_tb.Name = "x_cb3_init_tb";
            this.x_cb3_init_tb.Size = new System.Drawing.Size(122, 20);
            this.x_cb3_init_tb.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.xcb3_init_s_rb);
            this.groupBox3.Controls.Add(this.xcb3_init_km_rb);
            this.groupBox3.Location = new System.Drawing.Point(228, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 31);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // xcb3_init_s_rb
            // 
            this.xcb3_init_s_rb.AutoSize = true;
            this.xcb3_init_s_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xcb3_init_s_rb.ForeColor = System.Drawing.Color.Blue;
            this.xcb3_init_s_rb.Location = new System.Drawing.Point(51, 9);
            this.xcb3_init_s_rb.Name = "xcb3_init_s_rb";
            this.xcb3_init_s_rb.Size = new System.Drawing.Size(31, 17);
            this.xcb3_init_s_rb.TabIndex = 1;
            this.xcb3_init_s_rb.Text = "s";
            this.xcb3_init_s_rb.UseVisualStyleBackColor = true;
            // 
            // xcb3_init_km_rb
            // 
            this.xcb3_init_km_rb.AutoSize = true;
            this.xcb3_init_km_rb.Checked = true;
            this.xcb3_init_km_rb.Location = new System.Drawing.Point(6, 9);
            this.xcb3_init_km_rb.Name = "xcb3_init_km_rb";
            this.xcb3_init_km_rb.Size = new System.Drawing.Size(39, 17);
            this.xcb3_init_km_rb.TabIndex = 0;
            this.xcb3_init_km_rb.TabStop = true;
            this.xcb3_init_km_rb.Text = "km";
            this.xcb3_init_km_rb.UseVisualStyleBackColor = true;
            // 
            // bottom_right_gb
            // 
            this.bottom_right_gb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bottom_right_gb.Location = new System.Drawing.Point(778, 593);
            this.bottom_right_gb.Name = "bottom_right_gb";
            this.bottom_right_gb.Size = new System.Drawing.Size(67, 31);
            this.bottom_right_gb.TabIndex = 1201;
            this.bottom_right_gb.TabStop = false;
            this.bottom_right_gb.Visible = false;
            // 
            // top_left_gb
            // 
            this.top_left_gb.ForeColor = System.Drawing.SystemColors.Control;
            this.top_left_gb.Location = new System.Drawing.Point(2, 339);
            this.top_left_gb.Margin = new System.Windows.Forms.Padding(0);
            this.top_left_gb.Name = "top_left_gb";
            this.top_left_gb.Padding = new System.Windows.Forms.Padding(0);
            this.top_left_gb.Size = new System.Drawing.Size(77, 24);
            this.top_left_gb.TabIndex = 1202;
            this.top_left_gb.TabStop = false;
            this.top_left_gb.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::Dpdtrun.Properties.Resources.dpdt_formula;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(107, 248);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 62);
            this.flowLayoutPanel1.TabIndex = 1203;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(295, 214);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 26);
            this.label1.TabIndex = 1204;
            this.label1.Text = "s:  seconds\r\npast TCA";
            // 
            // constint_nan_lbl
            // 
            this.constint_nan_lbl.AutoSize = true;
            this.constint_nan_lbl.Location = new System.Drawing.Point(361, 298);
            this.constint_nan_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.constint_nan_lbl.Name = "constint_nan_lbl";
            this.constint_nan_lbl.Padding = new System.Windows.Forms.Padding(4);
            this.constint_nan_lbl.Size = new System.Drawing.Size(8, 21);
            this.constint_nan_lbl.TabIndex = 1205;
            this.constint_nan_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ylo_lbl
            // 
            this.ylo_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ylo_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ylo_lbl.Location = new System.Drawing.Point(-57, 583);
            this.ylo_lbl.Name = "ylo_lbl";
            this.ylo_lbl.Size = new System.Drawing.Size(136, 20);
            this.ylo_lbl.TabIndex = 1206;
            this.ylo_lbl.Text = "ylo";
            this.ylo_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ylo_lbl.UseMnemonic = false;
            this.ylo_lbl.Visible = false;
            // 
            // yhi_lbl
            // 
            this.yhi_lbl.BackColor = System.Drawing.Color.Transparent;
            this.yhi_lbl.Location = new System.Drawing.Point(-54, 352);
            this.yhi_lbl.Name = "yhi_lbl";
            this.yhi_lbl.Size = new System.Drawing.Size(133, 21);
            this.yhi_lbl.TabIndex = 1207;
            this.yhi_lbl.Text = "yhi";
            this.yhi_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yhi_lbl.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(368, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 1208;
            this.label2.Text = "ylo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.UseMnemonic = false;
            this.label2.Visible = false;
            // 
            // xlo_lbl
            // 
            this.xlo_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xlo_lbl.BackColor = System.Drawing.Color.Transparent;
            this.xlo_lbl.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.xlo_lbl.Location = new System.Drawing.Point(76, 600);
            this.xlo_lbl.Name = "xlo_lbl";
            this.xlo_lbl.Size = new System.Drawing.Size(136, 26);
            this.xlo_lbl.TabIndex = 1209;
            this.xlo_lbl.Text = "xlo";
            this.xlo_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xlo_lbl.UseMnemonic = false;
            this.xlo_lbl.Visible = false;
            // 
            // xhi_lbl
            // 
            this.xhi_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xhi_lbl.BackColor = System.Drawing.Color.Transparent;
            this.xhi_lbl.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.xhi_lbl.Location = new System.Drawing.Point(648, 600);
            this.xhi_lbl.Name = "xhi_lbl";
            this.xhi_lbl.Size = new System.Drawing.Size(136, 26);
            this.xhi_lbl.TabIndex = 1210;
            this.xhi_lbl.Text = "xlo";
            this.xhi_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xhi_lbl.UseMnemonic = false;
            this.xhi_lbl.Visible = false;
            // 
            // sc_posn_lbl
            // 
            this.sc_posn_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sc_posn_lbl.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.sc_posn_lbl.Location = new System.Drawing.Point(279, 600);
            this.sc_posn_lbl.Name = "sc_posn_lbl";
            this.sc_posn_lbl.Size = new System.Drawing.Size(237, 26);
            this.sc_posn_lbl.TabIndex = 1211;
            this.sc_posn_lbl.Text = "Spacecraft Position, s | km past TCA";
            this.sc_posn_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sc_posn_lbl.UseMnemonic = false;
            this.sc_posn_lbl.Visible = false;
            // 
            // cb3_posn_lbl
            // 
            this.cb3_posn_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb3_posn_lbl.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cb3_posn_lbl.Location = new System.Drawing.Point(15, 439);
            this.cb3_posn_lbl.Name = "cb3_posn_lbl";
            this.cb3_posn_lbl.Size = new System.Drawing.Size(55, 72);
            this.cb3_posn_lbl.TabIndex = 1212;
            this.cb3_posn_lbl.Text = "Solved\r\nP(t),\r\ns | km\r\npast\r\nPnom";
            this.cb3_posn_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb3_posn_lbl.UseMnemonic = false;
            this.cb3_posn_lbl.Visible = false;
            // 
            // tca_lbl
            // 
            this.tca_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tca_lbl.AutoSize = true;
            this.tca_lbl.BackColor = System.Drawing.Color.Transparent;
            this.tca_lbl.ForeColor = System.Drawing.Color.White;
            this.tca_lbl.Location = new System.Drawing.Point(517, 576);
            this.tca_lbl.Name = "tca_lbl";
            this.tca_lbl.Size = new System.Drawing.Size(28, 13);
            this.tca_lbl.TabIndex = 1213;
            this.tca_lbl.Text = "TCA";
            this.tca_lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.tca_lbl.Visible = false;
            // 
            // pnom_lbl
            // 
            this.pnom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnom_lbl.AutoSize = true;
            this.pnom_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pnom_lbl.ForeColor = System.Drawing.Color.White;
            this.pnom_lbl.Location = new System.Drawing.Point(80, 469);
            this.pnom_lbl.Name = "pnom_lbl";
            this.pnom_lbl.Size = new System.Drawing.Size(34, 13);
            this.pnom_lbl.TabIndex = 1214;
            this.pnom_lbl.Text = "Pnom";
            this.pnom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnom_lbl.Visible = false;
            // 
            // cb3_init_lbl
            // 
            this.cb3_init_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb3_init_lbl.AutoSize = true;
            this.cb3_init_lbl.BackColor = System.Drawing.Color.Transparent;
            this.cb3_init_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.cb3_init_lbl.Location = new System.Drawing.Point(120, 419);
            this.cb3_init_lbl.Name = "cb3_init_lbl";
            this.cb3_init_lbl.Size = new System.Drawing.Size(44, 13);
            this.cb3_init_lbl.TabIndex = 1215;
            this.cb3_init_lbl.Text = "CB3 Init";
            this.cb3_init_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb3_init_lbl.Visible = false;
            // 
            // sc_init_lbl
            // 
            this.sc_init_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sc_init_lbl.AutoSize = true;
            this.sc_init_lbl.BackColor = System.Drawing.Color.Transparent;
            this.sc_init_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.sc_init_lbl.Location = new System.Drawing.Point(551, 562);
            this.sc_init_lbl.Name = "sc_init_lbl";
            this.sc_init_lbl.Size = new System.Drawing.Size(38, 13);
            this.sc_init_lbl.TabIndex = 1216;
            this.sc_init_lbl.Text = "SC Init";
            this.sc_init_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sc_init_lbl.Visible = false;
            // 
            // diffs_lbl
            // 
            this.diffs_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diffs_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diffs_lbl.Location = new System.Drawing.Point(801, 415);
            this.diffs_lbl.Name = "diffs_lbl";
            this.diffs_lbl.Size = new System.Drawing.Size(41, 150);
            this.diffs_lbl.TabIndex = 1217;
            this.diffs_lbl.Text = "Log of\r\ndiffer-\r\nence\r\nbtw\r\nana-\r\nlyt-\r\nical\r\nand\r\nR-K\r\nsolu-\r\ntions";
            this.diffs_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diffs_lbl.Visible = false;
            // 
            // diff_yoctom_lbl
            // 
            this.diff_yoctom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_yoctom_lbl.AutoSize = true;
            this.diff_yoctom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_yoctom_lbl.Location = new System.Drawing.Point(780, 578);
            this.diff_yoctom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_yoctom_lbl.Name = "diff_yoctom_lbl";
            this.diff_yoctom_lbl.Size = new System.Drawing.Size(20, 13);
            this.diff_yoctom_lbl.TabIndex = 1218;
            this.diff_yoctom_lbl.Tag = "-8";
            this.diff_yoctom_lbl.Text = "ym";
            this.diff_yoctom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_yoctom_lbl.Visible = false;
            // 
            // diff_zeptom_lbl
            // 
            this.diff_zeptom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_zeptom_lbl.AutoSize = true;
            this.diff_zeptom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_zeptom_lbl.Location = new System.Drawing.Point(780, 565);
            this.diff_zeptom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_zeptom_lbl.Name = "diff_zeptom_lbl";
            this.diff_zeptom_lbl.Size = new System.Drawing.Size(20, 13);
            this.diff_zeptom_lbl.TabIndex = 1219;
            this.diff_zeptom_lbl.Tag = "-7";
            this.diff_zeptom_lbl.Text = "zm";
            this.diff_zeptom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_zeptom_lbl.Visible = false;
            // 
            // diff_attom_lbl
            // 
            this.diff_attom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_attom_lbl.AutoSize = true;
            this.diff_attom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_attom_lbl.Location = new System.Drawing.Point(780, 552);
            this.diff_attom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_attom_lbl.Name = "diff_attom_lbl";
            this.diff_attom_lbl.Size = new System.Drawing.Size(21, 13);
            this.diff_attom_lbl.TabIndex = 1220;
            this.diff_attom_lbl.Tag = "-6";
            this.diff_attom_lbl.Text = "am";
            this.diff_attom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_attom_lbl.Visible = false;
            // 
            // diff_femtom_lbl
            // 
            this.diff_femtom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_femtom_lbl.AutoSize = true;
            this.diff_femtom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_femtom_lbl.Location = new System.Drawing.Point(780, 539);
            this.diff_femtom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_femtom_lbl.Name = "diff_femtom_lbl";
            this.diff_femtom_lbl.Size = new System.Drawing.Size(18, 13);
            this.diff_femtom_lbl.TabIndex = 1221;
            this.diff_femtom_lbl.Tag = "-5";
            this.diff_femtom_lbl.Text = "fm";
            this.diff_femtom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_femtom_lbl.Visible = false;
            // 
            // diff_picom_lbl
            // 
            this.diff_picom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_picom_lbl.AutoSize = true;
            this.diff_picom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_picom_lbl.Location = new System.Drawing.Point(780, 521);
            this.diff_picom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_picom_lbl.Name = "diff_picom_lbl";
            this.diff_picom_lbl.Size = new System.Drawing.Size(21, 13);
            this.diff_picom_lbl.TabIndex = 1222;
            this.diff_picom_lbl.Tag = "-4";
            this.diff_picom_lbl.Text = "pm";
            this.diff_picom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_picom_lbl.Visible = false;
            // 
            // diff_nanom_lbl
            // 
            this.diff_nanom_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_nanom_lbl.AutoSize = true;
            this.diff_nanom_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_nanom_lbl.Location = new System.Drawing.Point(780, 508);
            this.diff_nanom_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_nanom_lbl.Name = "diff_nanom_lbl";
            this.diff_nanom_lbl.Size = new System.Drawing.Size(21, 13);
            this.diff_nanom_lbl.TabIndex = 1223;
            this.diff_nanom_lbl.Tag = "-3";
            this.diff_nanom_lbl.Text = "nm";
            this.diff_nanom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_nanom_lbl.Visible = false;
            // 
            // diff_microm_lbl
            // 
            this.diff_microm_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_microm_lbl.AutoSize = true;
            this.diff_microm_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_microm_lbl.Location = new System.Drawing.Point(780, 495);
            this.diff_microm_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_microm_lbl.Name = "diff_microm_lbl";
            this.diff_microm_lbl.Size = new System.Drawing.Size(21, 13);
            this.diff_microm_lbl.TabIndex = 1224;
            this.diff_microm_lbl.Tag = "-2";
            this.diff_microm_lbl.Text = "μm";
            this.diff_microm_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_microm_lbl.Visible = false;
            // 
            // diff_millim_lbl
            // 
            this.diff_millim_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_millim_lbl.AutoSize = true;
            this.diff_millim_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_millim_lbl.Location = new System.Drawing.Point(780, 483);
            this.diff_millim_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_millim_lbl.Name = "diff_millim_lbl";
            this.diff_millim_lbl.Size = new System.Drawing.Size(23, 13);
            this.diff_millim_lbl.TabIndex = 1225;
            this.diff_millim_lbl.Tag = "-1";
            this.diff_millim_lbl.Text = "mm";
            this.diff_millim_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_millim_lbl.Visible = false;
            // 
            // diff_m_lbl
            // 
            this.diff_m_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_m_lbl.AutoSize = true;
            this.diff_m_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_m_lbl.Location = new System.Drawing.Point(780, 469);
            this.diff_m_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_m_lbl.Name = "diff_m_lbl";
            this.diff_m_lbl.Size = new System.Drawing.Size(15, 13);
            this.diff_m_lbl.TabIndex = 1226;
            this.diff_m_lbl.Tag = "0";
            this.diff_m_lbl.Text = "m";
            this.diff_m_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_m_lbl.Visible = false;
            // 
            // diff_km_lbl
            // 
            this.diff_km_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_km_lbl.AutoSize = true;
            this.diff_km_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_km_lbl.Location = new System.Drawing.Point(780, 456);
            this.diff_km_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_km_lbl.Name = "diff_km_lbl";
            this.diff_km_lbl.Size = new System.Drawing.Size(21, 13);
            this.diff_km_lbl.TabIndex = 1227;
            this.diff_km_lbl.Tag = "1";
            this.diff_km_lbl.Text = "km";
            this.diff_km_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_km_lbl.Visible = false;
            // 
            // diff_megam_lbl
            // 
            this.diff_megam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_megam_lbl.AutoSize = true;
            this.diff_megam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_megam_lbl.Location = new System.Drawing.Point(780, 442);
            this.diff_megam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_megam_lbl.Name = "diff_megam_lbl";
            this.diff_megam_lbl.Size = new System.Drawing.Size(24, 13);
            this.diff_megam_lbl.TabIndex = 1228;
            this.diff_megam_lbl.Tag = "2";
            this.diff_megam_lbl.Text = "Mm";
            this.diff_megam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_megam_lbl.Visible = false;
            // 
            // diff_gigam_lbl
            // 
            this.diff_gigam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_gigam_lbl.AutoSize = true;
            this.diff_gigam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_gigam_lbl.Location = new System.Drawing.Point(780, 429);
            this.diff_gigam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_gigam_lbl.Name = "diff_gigam_lbl";
            this.diff_gigam_lbl.Size = new System.Drawing.Size(23, 13);
            this.diff_gigam_lbl.TabIndex = 1229;
            this.diff_gigam_lbl.Tag = "3";
            this.diff_gigam_lbl.Text = "Gm";
            this.diff_gigam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_gigam_lbl.Visible = false;
            // 
            // diff_teram_lbl
            // 
            this.diff_teram_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_teram_lbl.AutoSize = true;
            this.diff_teram_lbl.BackColor = System.Drawing.Color.Transparent;
            this.diff_teram_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_teram_lbl.Location = new System.Drawing.Point(780, 415);
            this.diff_teram_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_teram_lbl.Name = "diff_teram_lbl";
            this.diff_teram_lbl.Size = new System.Drawing.Size(22, 13);
            this.diff_teram_lbl.TabIndex = 1230;
            this.diff_teram_lbl.Tag = "4";
            this.diff_teram_lbl.Text = "Tm";
            this.diff_teram_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_teram_lbl.Visible = false;
            // 
            // diff_petam_lbl
            // 
            this.diff_petam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_petam_lbl.AutoSize = true;
            this.diff_petam_lbl.BackColor = System.Drawing.Color.Transparent;
            this.diff_petam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_petam_lbl.Location = new System.Drawing.Point(780, 402);
            this.diff_petam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_petam_lbl.Name = "diff_petam_lbl";
            this.diff_petam_lbl.Size = new System.Drawing.Size(22, 13);
            this.diff_petam_lbl.TabIndex = 1231;
            this.diff_petam_lbl.Tag = "5";
            this.diff_petam_lbl.Text = "Pm";
            this.diff_petam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_petam_lbl.Visible = false;
            // 
            // diff_exam_lbl
            // 
            this.diff_exam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_exam_lbl.AutoSize = true;
            this.diff_exam_lbl.BackColor = System.Drawing.Color.Transparent;
            this.diff_exam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_exam_lbl.Location = new System.Drawing.Point(780, 389);
            this.diff_exam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_exam_lbl.Name = "diff_exam_lbl";
            this.diff_exam_lbl.Size = new System.Drawing.Size(22, 13);
            this.diff_exam_lbl.TabIndex = 1232;
            this.diff_exam_lbl.Tag = "6";
            this.diff_exam_lbl.Text = "Em";
            this.diff_exam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_exam_lbl.Visible = false;
            // 
            // diff_zettam_lbl
            // 
            this.diff_zettam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_zettam_lbl.AutoSize = true;
            this.diff_zettam_lbl.BackColor = System.Drawing.Color.Transparent;
            this.diff_zettam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_zettam_lbl.Location = new System.Drawing.Point(780, 376);
            this.diff_zettam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_zettam_lbl.Name = "diff_zettam_lbl";
            this.diff_zettam_lbl.Size = new System.Drawing.Size(22, 13);
            this.diff_zettam_lbl.TabIndex = 1233;
            this.diff_zettam_lbl.Tag = "7";
            this.diff_zettam_lbl.Text = "Zm";
            this.diff_zettam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_zettam_lbl.Visible = false;
            // 
            // diff_yottam_lbl
            // 
            this.diff_yottam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diff_yottam_lbl.AutoSize = true;
            this.diff_yottam_lbl.BackColor = System.Drawing.Color.Transparent;
            this.diff_yottam_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff_yottam_lbl.Location = new System.Drawing.Point(780, 363);
            this.diff_yottam_lbl.Margin = new System.Windows.Forms.Padding(0);
            this.diff_yottam_lbl.Name = "diff_yottam_lbl";
            this.diff_yottam_lbl.Size = new System.Drawing.Size(22, 13);
            this.diff_yottam_lbl.TabIndex = 1234;
            this.diff_yottam_lbl.Tag = "8";
            this.diff_yottam_lbl.Text = "Ym";
            this.diff_yottam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diff_yottam_lbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(845, 622);
            this.Controls.Add(this.diff_yottam_lbl);
            this.Controls.Add(this.diff_zettam_lbl);
            this.Controls.Add(this.diff_exam_lbl);
            this.Controls.Add(this.diff_petam_lbl);
            this.Controls.Add(this.diff_teram_lbl);
            this.Controls.Add(this.diff_gigam_lbl);
            this.Controls.Add(this.diff_megam_lbl);
            this.Controls.Add(this.diff_km_lbl);
            this.Controls.Add(this.diff_m_lbl);
            this.Controls.Add(this.diff_millim_lbl);
            this.Controls.Add(this.diff_microm_lbl);
            this.Controls.Add(this.diff_nanom_lbl);
            this.Controls.Add(this.diff_picom_lbl);
            this.Controls.Add(this.diff_femtom_lbl);
            this.Controls.Add(this.diff_attom_lbl);
            this.Controls.Add(this.diff_zeptom_lbl);
            this.Controls.Add(this.diff_yoctom_lbl);
            this.Controls.Add(this.sc_init_lbl);
            this.Controls.Add(this.cb3_init_lbl);
            this.Controls.Add(this.pnom_lbl);
            this.Controls.Add(this.tca_lbl);
            this.Controls.Add(this.cb3_posn_lbl);
            this.Controls.Add(this.sc_posn_lbl);
            this.Controls.Add(this.xhi_lbl);
            this.Controls.Add(this.xlo_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yhi_lbl);
            this.Controls.Add(this.ylo_lbl);
            this.Controls.Add(this.constint_nan_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottom_right_gb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.xcb3_init);
            this.Controls.Add(this.x_cb3_init_tb);
            this.Controls.Add(this.log_lbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scinit_left_lbl);
            this.Controls.Add(this.xcb3_limit_right_tb);
            this.Controls.Add(this.sc_init_tb);
            this.Controls.Add(this.xcb0km_left_lbl);
            this.Controls.Add(this.xcb3_limit_left_tb);
            this.Controls.Add(this.excel_tb);
            this.Controls.Add(this.excel_btn);
            this.Controls.Add(this.outputs_lbl);
            this.Controls.Add(this.inputs_lbl);
            this.Controls.Add(this.go_btn);
            this.Controls.Add(this.delt_right_lbl);
            this.Controls.Add(this.delt_left_lbl);
            this.Controls.Add(this.delt_tb);
            this.Controls.Add(this.vfb_right_lbl);
            this.Controls.Add(this.vfb_left_lbl);
            this.Controls.Add(this.vfb_tb);
            this.Controls.Add(this.deltay_right_lbl);
            this.Controls.Add(this.deltay_left_lbl);
            this.Controls.Add(this.deltay_tb);
            this.Controls.Add(this.tmi_right_lbl);
            this.Controls.Add(this.tmr_left_lbl);
            this.Controls.Add(this.tmr_tb);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(dpdtrun_diagram);
            this.Controls.Add(this.top_left_gb);
            this.Controls.Add(this.diffs_lbl);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dP/dt Run";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tmr_tb;
        private System.Windows.Forms.Label tmr_left_lbl;
        private System.Windows.Forms.Label tmi_right_lbl;
        private System.Windows.Forms.Label deltay_right_lbl;
        private System.Windows.Forms.Label deltay_left_lbl;
        private System.Windows.Forms.TextBox deltay_tb;
        private System.Windows.Forms.Label vfb_right_lbl;
        private System.Windows.Forms.Label vfb_left_lbl;
        private System.Windows.Forms.TextBox vfb_tb;
        private System.Windows.Forms.Label delt_right_lbl;
        private System.Windows.Forms.Label delt_left_lbl;
        private System.Windows.Forms.TextBox delt_tb;
        private System.Windows.Forms.Button go_btn;
        private System.Windows.Forms.Label inputs_lbl;
        private System.Windows.Forms.Label outputs_lbl;
        private System.Windows.Forms.Button excel_btn;
        private System.Windows.Forms.TextBox excel_tb;
        private System.Windows.Forms.OpenFileDialog excel_ofd;
        private System.Windows.Forms.Label xcb0km_left_lbl;
        private System.Windows.Forms.TextBox xcb3_limit_left_tb;
        private System.Windows.Forms.TextBox xcb3_limit_right_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton xcb3_s_rb;
        private System.Windows.Forms.RadioButton xcb3_km_rb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton sc_init_s_rb;
        private System.Windows.Forms.RadioButton sc_km_rb;
        private System.Windows.Forms.Label scinit_left_lbl;
        private System.Windows.Forms.TextBox sc_init_tb;
        private System.Windows.Forms.Label log_lbl;
        private System.Windows.Forms.Label xcb3_init;
        private System.Windows.Forms.TextBox x_cb3_init_tb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton xcb3_init_s_rb;
        private System.Windows.Forms.RadioButton xcb3_init_km_rb;
        private System.Windows.Forms.GroupBox bottom_right_gb;
        private System.Windows.Forms.GroupBox top_left_gb;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label constint_nan_lbl;
        private Label ylo_lbl;
        private Label yhi_lbl;
        private Label label2;
        private Label xlo_lbl;
        private Label xhi_lbl;
        private Label sc_posn_lbl;
        private Label cb3_posn_lbl;
        private Label tca_lbl;
        private Label pnom_lbl;
        private Label cb3_init_lbl;
        private Label sc_init_lbl;
        private Label diffs_lbl;
        private Label diff_yoctom_lbl;
        private Label diff_zeptom_lbl;
        private Label diff_attom_lbl;
        private Label diff_femtom_lbl;
        private Label diff_picom_lbl;
        private Label diff_nanom_lbl;
        private Label diff_microm_lbl;
        private Label diff_millim_lbl;
        private Label diff_m_lbl;
        private Label diff_km_lbl;
        private Label diff_megam_lbl;
        private Label diff_gigam_lbl;
        private Label diff_teram_lbl;
        private Label diff_petam_lbl;
        private Label diff_exam_lbl;
        private Label diff_zettam_lbl;
        private Label diff_yottam_lbl;
    }
}

