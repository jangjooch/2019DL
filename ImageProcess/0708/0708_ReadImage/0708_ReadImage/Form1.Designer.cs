namespace _0708_ReadImage
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
            this.button_Open = new System.Windows.Forms.Button();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(591, 12);
            this.button_Open.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(70, 64);
            this.button_Open.TabIndex = 0;
            this.button_Open.Text = "Image Read";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "ofdOpen";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 421);
            this.Controls.Add(this.button_Open);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
    }
}

