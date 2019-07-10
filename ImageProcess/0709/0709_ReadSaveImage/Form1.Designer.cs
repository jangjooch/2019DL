namespace _0709_ReadSaveImage
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
            this.menuStrip_file = new System.Windows.Forms.MenuStrip();
            this.MeauItem_main = new System.Windows.Forms.ToolStripMenuItem();
            this.MeauItem_open = new System.Windows.Forms.ToolStripMenuItem();
            this.MeauItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.MeauItem_togray = new System.Windows.Forms.ToolStripMenuItem();
            this.MeauItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.MenuItem_adjust = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_brightness_add = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_brightness_subtract = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_contrast_increase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_contrast_decrease = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_file.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_file
            // 
            this.menuStrip_file.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip_file.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeauItem_main,
            this.MenuItem_adjust});
            this.menuStrip_file.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_file.Name = "menuStrip_file";
            this.menuStrip_file.Size = new System.Drawing.Size(487, 28);
            this.menuStrip_file.TabIndex = 0;
            this.menuStrip_file.Text = "File";
            // 
            // MeauItem_main
            // 
            this.MeauItem_main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeauItem_open,
            this.MeauItem_save,
            this.MeauItem_togray,
            this.MeauItem_exit});
            this.MeauItem_main.Name = "MeauItem_main";
            this.MeauItem_main.Size = new System.Drawing.Size(45, 24);
            this.MeauItem_main.Text = "&File";
            // 
            // MeauItem_open
            // 
            this.MeauItem_open.Name = "MeauItem_open";
            this.MeauItem_open.Size = new System.Drawing.Size(180, 24);
            this.MeauItem_open.Text = "&Open";
            this.MeauItem_open.Click += new System.EventHandler(this.MeauItem_open_Click);
            // 
            // MeauItem_save
            // 
            this.MeauItem_save.Name = "MeauItem_save";
            this.MeauItem_save.Size = new System.Drawing.Size(180, 24);
            this.MeauItem_save.Text = "&Save";
            this.MeauItem_save.Click += new System.EventHandler(this.MeauItem_save_Click);
            // 
            // MeauItem_togray
            // 
            this.MeauItem_togray.Name = "MeauItem_togray";
            this.MeauItem_togray.Size = new System.Drawing.Size(180, 24);
            this.MeauItem_togray.Text = "&ToGray";
            this.MeauItem_togray.Click += new System.EventHandler(this.MeauItem_togray_Click);
            // 
            // MeauItem_exit
            // 
            this.MeauItem_exit.Name = "MeauItem_exit";
            this.MeauItem_exit.Size = new System.Drawing.Size(180, 24);
            this.MeauItem_exit.Text = "&Exit";
            this.MeauItem_exit.Click += new System.EventHandler(this.MeauItem_exit_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "ofdOpen";
            // 
            // MenuItem_adjust
            // 
            this.MenuItem_adjust.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessToolStripMenuItem,
            this.contrastToolStripMenuItem});
            this.MenuItem_adjust.Name = "MenuItem_adjust";
            this.MenuItem_adjust.Size = new System.Drawing.Size(111, 24);
            this.MenuItem_adjust.Text = "&Adjustments";
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_brightness_add,
            this.MenuItem_brightness_subtract});
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.brightnessToolStripMenuItem.Text = "&Brightness";
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_contrast_increase,
            this.MenuItem_contrast_decrease});
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.contrastToolStripMenuItem.Text = "&Contrast";
            // 
            // MenuItem_brightness_add
            // 
            this.MenuItem_brightness_add.Name = "MenuItem_brightness_add";
            this.MenuItem_brightness_add.Size = new System.Drawing.Size(180, 24);
            this.MenuItem_brightness_add.Text = "&Add";
            this.MenuItem_brightness_add.Click += new System.EventHandler(this.MenuItem_brightness_add_Click);
            // 
            // MenuItem_brightness_subtract
            // 
            this.MenuItem_brightness_subtract.Name = "MenuItem_brightness_subtract";
            this.MenuItem_brightness_subtract.Size = new System.Drawing.Size(180, 24);
            this.MenuItem_brightness_subtract.Text = "&Subtract";
            this.MenuItem_brightness_subtract.Click += new System.EventHandler(this.MenuItem_brightness_subtract_Click);
            // 
            // MenuItem_contrast_increase
            // 
            this.MenuItem_contrast_increase.Name = "MenuItem_contrast_increase";
            this.MenuItem_contrast_increase.Size = new System.Drawing.Size(180, 24);
            this.MenuItem_contrast_increase.Text = "&Increase";
            this.MenuItem_contrast_increase.Click += new System.EventHandler(this.IncreaseToolStripMenuItem_Click);
            // 
            // MenuItem_contrast_decrease
            // 
            this.MenuItem_contrast_decrease.Name = "MenuItem_contrast_decrease";
            this.MenuItem_contrast_decrease.Size = new System.Drawing.Size(180, 24);
            this.MenuItem_contrast_decrease.Text = "&Decrease";
            this.MenuItem_contrast_decrease.Click += new System.EventHandler(this.MenuItem_contrast_decrease_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 393);
            this.Controls.Add(this.menuStrip_file);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip_file.ResumeLayout(false);
            this.menuStrip_file.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_file;
        private System.Windows.Forms.ToolStripMenuItem MeauItem_main;
        private System.Windows.Forms.ToolStripMenuItem MeauItem_open;
        private System.Windows.Forms.ToolStripMenuItem MeauItem_save;
        private System.Windows.Forms.ToolStripMenuItem MeauItem_togray;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.ToolStripMenuItem MeauItem_exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_adjust;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_brightness_add;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_brightness_subtract;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_contrast_increase;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_contrast_decrease;
    }
}

