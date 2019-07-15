namespace _0709_ReadSaveImageAdvanced
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_brightness = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_brightness_add = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_brightness_subtract = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_contrast_increase = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_contrast_decrease = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inverse = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_gamma = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_gamma_larger = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_gamma_between = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastLUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_contrast_lut_increase = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_contrast_lut_increase_smooth = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_contrast_lut_decrease = new System.Windows.Forms.ToolStripMenuItem();
            this.parabolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_parabola_cap = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_parabola_cup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_histogram = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramStretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_strectching_basic = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adjustmentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(439, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toGrayToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toGrayToolStripMenuItem
            // 
            this.toGrayToolStripMenuItem.Name = "toGrayToolStripMenuItem";
            this.toGrayToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.toGrayToolStripMenuItem.Text = "&ToGray";
            this.toGrayToolStripMenuItem.Click += new System.EventHandler(this.ToGrayToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // adjustmentsToolStripMenuItem
            // 
            this.adjustmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_brightness,
            this.contrastToolStripMenuItem,
            this.menu_inverse,
            this.menu_gamma,
            this.contrastLUTToolStripMenuItem,
            this.parabolaToolStripMenuItem,
            this.menu_histogram,
            this.histogramStretchingToolStripMenuItem});
            this.adjustmentsToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.adjustmentsToolStripMenuItem.Name = "adjustmentsToolStripMenuItem";
            this.adjustmentsToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.adjustmentsToolStripMenuItem.Text = "&Adjustments";
            // 
            // menu_brightness
            // 
            this.menu_brightness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_brightness_add,
            this.menu_brightness_subtract});
            this.menu_brightness.Name = "menu_brightness";
            this.menu_brightness.Size = new System.Drawing.Size(231, 24);
            this.menu_brightness.Text = "&Brightness";
            // 
            // menu_brightness_add
            // 
            this.menu_brightness_add.Name = "menu_brightness_add";
            this.menu_brightness_add.Size = new System.Drawing.Size(137, 24);
            this.menu_brightness_add.Text = "&Add";
            this.menu_brightness_add.Click += new System.EventHandler(this.Menu_brightness_add_Click);
            // 
            // menu_brightness_subtract
            // 
            this.menu_brightness_subtract.Name = "menu_brightness_subtract";
            this.menu_brightness_subtract.Size = new System.Drawing.Size(137, 24);
            this.menu_brightness_subtract.Text = "&Subtract";
            this.menu_brightness_subtract.Click += new System.EventHandler(this.Menu_brightness_subtract_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_contrast_increase,
            this.menu_contrast_decrease});
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.contrastToolStripMenuItem.Text = "&Contrast";
            // 
            // menu_contrast_increase
            // 
            this.menu_contrast_increase.Name = "menu_contrast_increase";
            this.menu_contrast_increase.Size = new System.Drawing.Size(141, 24);
            this.menu_contrast_increase.Text = "Increase";
            this.menu_contrast_increase.Click += new System.EventHandler(this.Menu_contrast_increase_Click);
            // 
            // menu_contrast_decrease
            // 
            this.menu_contrast_decrease.Name = "menu_contrast_decrease";
            this.menu_contrast_decrease.Size = new System.Drawing.Size(141, 24);
            this.menu_contrast_decrease.Text = "Decrease";
            this.menu_contrast_decrease.Click += new System.EventHandler(this.Menu_contrast_decrease_Click);
            // 
            // menu_inverse
            // 
            this.menu_inverse.Name = "menu_inverse";
            this.menu_inverse.Size = new System.Drawing.Size(231, 24);
            this.menu_inverse.Text = "&Inverse";
            this.menu_inverse.Click += new System.EventHandler(this.Menu_inverse_Click);
            // 
            // menu_gamma
            // 
            this.menu_gamma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_gamma_larger,
            this.menu_gamma_between});
            this.menu_gamma.Name = "menu_gamma";
            this.menu_gamma.Size = new System.Drawing.Size(231, 24);
            this.menu_gamma.Text = "&Gamma";
            // 
            // menu_gamma_larger
            // 
            this.menu_gamma_larger.Name = "menu_gamma_larger";
            this.menu_gamma_larger.Size = new System.Drawing.Size(196, 24);
            this.menu_gamma_larger.Text = " 1 < gamma";
            this.menu_gamma_larger.Click += new System.EventHandler(this.Menu_gamma_larger_Click);
            // 
            // menu_gamma_between
            // 
            this.menu_gamma_between.Name = "menu_gamma_between";
            this.menu_gamma_between.Size = new System.Drawing.Size(196, 24);
            this.menu_gamma_between.Text = " 0 < gamma < 1";
            this.menu_gamma_between.Click += new System.EventHandler(this.Menu_gamma_between_Click);
            // 
            // contrastLUTToolStripMenuItem
            // 
            this.contrastLUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_contrast_lut_increase,
            this.menu_contrast_lut_increase_smooth,
            this.menu_contrast_lut_decrease});
            this.contrastLUTToolStripMenuItem.Name = "contrastLUTToolStripMenuItem";
            this.contrastLUTToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.contrastLUTToolStripMenuItem.Text = "&Contrast_LUT";
            // 
            // menu_contrast_lut_increase
            // 
            this.menu_contrast_lut_increase.Name = "menu_contrast_lut_increase";
            this.menu_contrast_lut_increase.Size = new System.Drawing.Size(200, 24);
            this.menu_contrast_lut_increase.Text = "Increase";
            this.menu_contrast_lut_increase.Click += new System.EventHandler(this.Menu_contrast_lut_increase_Click);
            // 
            // menu_contrast_lut_increase_smooth
            // 
            this.menu_contrast_lut_increase_smooth.Name = "menu_contrast_lut_increase_smooth";
            this.menu_contrast_lut_increase_smooth.Size = new System.Drawing.Size(200, 24);
            this.menu_contrast_lut_increase_smooth.Text = "Increase(smooth)";
            this.menu_contrast_lut_increase_smooth.Click += new System.EventHandler(this.Menu_contrast_lut_increase_smooth_Click);
            // 
            // menu_contrast_lut_decrease
            // 
            this.menu_contrast_lut_decrease.Name = "menu_contrast_lut_decrease";
            this.menu_contrast_lut_decrease.Size = new System.Drawing.Size(200, 24);
            this.menu_contrast_lut_decrease.Text = "Decrease";
            this.menu_contrast_lut_decrease.Click += new System.EventHandler(this.Menu_contrast_lut_decrease_Click);
            // 
            // parabolaToolStripMenuItem
            // 
            this.parabolaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_parabola_cap,
            this.menu_parabola_cup});
            this.parabolaToolStripMenuItem.Name = "parabolaToolStripMenuItem";
            this.parabolaToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.parabolaToolStripMenuItem.Text = "&Parabola";
            // 
            // menu_parabola_cap
            // 
            this.menu_parabola_cap.Name = "menu_parabola_cap";
            this.menu_parabola_cap.Size = new System.Drawing.Size(106, 24);
            this.menu_parabola_cap.Text = "Cap";
            this.menu_parabola_cap.Click += new System.EventHandler(this.Menu_parabola_cap_Click);
            // 
            // menu_parabola_cup
            // 
            this.menu_parabola_cup.Name = "menu_parabola_cup";
            this.menu_parabola_cup.Size = new System.Drawing.Size(106, 24);
            this.menu_parabola_cup.Text = "Cup";
            this.menu_parabola_cup.Click += new System.EventHandler(this.Menu_parabola_cup_Click);
            // 
            // menu_histogram
            // 
            this.menu_histogram.Name = "menu_histogram";
            this.menu_histogram.Size = new System.Drawing.Size(231, 24);
            this.menu_histogram.Text = "&Histogram_show";
            this.menu_histogram.Click += new System.EventHandler(this.Menu_histogram_Click);
            // 
            // histogramStretchingToolStripMenuItem
            // 
            this.histogramStretchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_strectching_basic,
            this.rateToolStripMenuItem,
            this.equalizationToolStripMenuItem});
            this.histogramStretchingToolStripMenuItem.Name = "histogramStretchingToolStripMenuItem";
            this.histogramStretchingToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.histogramStretchingToolStripMenuItem.Text = "&Histogram_Stretching";
            // 
            // menu_strectching_basic
            // 
            this.menu_strectching_basic.Name = "menu_strectching_basic";
            this.menu_strectching_basic.Size = new System.Drawing.Size(180, 24);
            this.menu_strectching_basic.Text = "Basic";
            this.menu_strectching_basic.Click += new System.EventHandler(this.Menu_strectching_basic_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "openFileDialog1";
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.rateToolStripMenuItem.Text = "Rate";
            this.rateToolStripMenuItem.Click += new System.EventHandler(this.RateToolStripMenuItem_Click);
            // 
            // equalizationToolStripMenuItem
            // 
            this.equalizationToolStripMenuItem.Name = "equalizationToolStripMenuItem";
            this.equalizationToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.equalizationToolStripMenuItem.Text = "Equalization";
            this.equalizationToolStripMenuItem.Click += new System.EventHandler(this.EqualizationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 370);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_brightness;
        private System.Windows.Forms.ToolStripMenuItem menu_brightness_add;
        private System.Windows.Forms.ToolStripMenuItem menu_brightness_subtract;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_contrast_increase;
        private System.Windows.Forms.ToolStripMenuItem menu_contrast_decrease;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.ToolStripMenuItem menu_inverse;
        private System.Windows.Forms.ToolStripMenuItem menu_gamma;
        private System.Windows.Forms.ToolStripMenuItem menu_gamma_larger;
        private System.Windows.Forms.ToolStripMenuItem menu_gamma_between;
        private System.Windows.Forms.ToolStripMenuItem contrastLUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_contrast_lut_increase;
        private System.Windows.Forms.ToolStripMenuItem menu_contrast_lut_decrease;
        private System.Windows.Forms.ToolStripMenuItem menu_contrast_lut_increase_smooth;
        private System.Windows.Forms.ToolStripMenuItem parabolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_parabola_cap;
        private System.Windows.Forms.ToolStripMenuItem menu_parabola_cup;
        private System.Windows.Forms.ToolStripMenuItem menu_histogram;
        private System.Windows.Forms.ToolStripMenuItem histogramStretchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_strectching_basic;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationToolStripMenuItem;
    }
}

