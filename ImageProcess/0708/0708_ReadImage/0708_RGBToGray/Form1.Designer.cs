namespace _0708_RGBToGray
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
            this.button_open = new System.Windows.Forms.Button();
            this.button_gray = new System.Windows.Forms.Button();
            this.open_picture = new System.Windows.Forms.OpenFileDialog();
            this.button_brighter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(515, 12);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.SizeChanged += new System.EventHandler(this.Button_open_SizeChanged);
            this.button_open.Click += new System.EventHandler(this.Button_open_Click);
            // 
            // button_gray
            // 
            this.button_gray.Location = new System.Drawing.Point(515, 41);
            this.button_gray.Name = "button_gray";
            this.button_gray.Size = new System.Drawing.Size(75, 23);
            this.button_gray.TabIndex = 1;
            this.button_gray.Text = "To Gray";
            this.button_gray.UseVisualStyleBackColor = true;
            this.button_gray.Click += new System.EventHandler(this.Button_gray_Click);
            // 
            // open_picture
            // 
            this.open_picture.FileName = "openFile";
            // 
            // button_brighter
            // 
            this.button_brighter.Location = new System.Drawing.Point(515, 70);
            this.button_brighter.Name = "button_brighter";
            this.button_brighter.Size = new System.Drawing.Size(75, 23);
            this.button_brighter.TabIndex = 2;
            this.button_brighter.Text = "Brighter";
            this.button_brighter.UseVisualStyleBackColor = true;
            this.button_brighter.Click += new System.EventHandler(this.Button_brighter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 377);
            this.Controls.Add(this.button_brighter);
            this.Controls.Add(this.button_gray);
            this.Controls.Add(this.button_open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_gray;
        private System.Windows.Forms.OpenFileDialog open_picture;
        private System.Windows.Forms.Button button_brighter;
    }
}

