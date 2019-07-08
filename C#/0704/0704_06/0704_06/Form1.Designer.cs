namespace _0704_06
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
            this.button_1000 = new System.Windows.Forms.Button();
            this.button_500 = new System.Windows.Forms.Button();
            this.button_100 = new System.Windows.Forms.Button();
            this.total_money = new System.Windows.Forms.TextBox();
            this.radio_coke = new System.Windows.Forms.RadioButton();
            this.radio_coffee = new System.Windows.Forms.RadioButton();
            this.radio_water = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_1000
            // 
            this.button_1000.Location = new System.Drawing.Point(12, 12);
            this.button_1000.Name = "button_1000";
            this.button_1000.Size = new System.Drawing.Size(75, 23);
            this.button_1000.TabIndex = 1;
            this.button_1000.Text = "1000";
            this.button_1000.UseVisualStyleBackColor = true;
            this.button_1000.Click += new System.EventHandler(this.Button_1000_Click);
            // 
            // button_500
            // 
            this.button_500.Location = new System.Drawing.Point(93, 12);
            this.button_500.Name = "button_500";
            this.button_500.Size = new System.Drawing.Size(75, 23);
            this.button_500.TabIndex = 2;
            this.button_500.Text = "500";
            this.button_500.UseVisualStyleBackColor = true;
            this.button_500.Click += new System.EventHandler(this.Button_500_Click);
            // 
            // button_100
            // 
            this.button_100.Location = new System.Drawing.Point(174, 12);
            this.button_100.Name = "button_100";
            this.button_100.Size = new System.Drawing.Size(75, 23);
            this.button_100.TabIndex = 3;
            this.button_100.Text = "100";
            this.button_100.UseVisualStyleBackColor = true;
            this.button_100.Click += new System.EventHandler(this.Button_100_Click);
            // 
            // total_money
            // 
            this.total_money.Location = new System.Drawing.Point(255, 14);
            this.total_money.Name = "total_money";
            this.total_money.Size = new System.Drawing.Size(100, 21);
            this.total_money.TabIndex = 4;
            this.total_money.TextChanged += new System.EventHandler(this.Total_money_TextChanged);
            // 
            // radio_coke
            // 
            this.radio_coke.AutoSize = true;
            this.radio_coke.Location = new System.Drawing.Point(12, 196);
            this.radio_coke.Name = "radio_coke";
            this.radio_coke.Size = new System.Drawing.Size(86, 16);
            this.radio_coke.TabIndex = 5;
            this.radio_coke.TabStop = true;
            this.radio_coke.Text = "Coke(1300)";
            this.radio_coke.UseVisualStyleBackColor = true;
            this.radio_coke.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radio_coffee
            // 
            this.radio_coffee.AutoSize = true;
            this.radio_coffee.Location = new System.Drawing.Point(12, 218);
            this.radio_coffee.Name = "radio_coffee";
            this.radio_coffee.Size = new System.Drawing.Size(93, 16);
            this.radio_coffee.TabIndex = 6;
            this.radio_coffee.TabStop = true;
            this.radio_coffee.Text = "Coffee(1000)";
            this.radio_coffee.UseVisualStyleBackColor = true;
            // 
            // radio_water
            // 
            this.radio_water.AutoSize = true;
            this.radio_water.Location = new System.Drawing.Point(12, 240);
            this.radio_water.Name = "radio_water";
            this.radio_water.Size = new System.Drawing.Size(82, 16);
            this.radio_water.TabIndex = 7;
            this.radio_water.TabStop = true;
            this.radio_water.Text = "Water(600)";
            this.radio_water.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Buy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radio_water);
            this.Controls.Add(this.radio_coffee);
            this.Controls.Add(this.radio_coke);
            this.Controls.Add(this.total_money);
            this.Controls.Add(this.button_100);
            this.Controls.Add(this.button_500);
            this.Controls.Add(this.button_1000);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_1000;
        private System.Windows.Forms.Button button_500;
        private System.Windows.Forms.Button button_100;
        private System.Windows.Forms.TextBox total_money;
        private System.Windows.Forms.RadioButton radio_coke;
        private System.Windows.Forms.RadioButton radio_coffee;
        private System.Windows.Forms.RadioButton radio_water;
        private System.Windows.Forms.Button button1;
    }
}

