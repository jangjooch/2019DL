namespace _0704_08
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
            this.Group_item = new System.Windows.Forms.GroupBox();
            this.Group_bag = new System.Windows.Forms.GroupBox();
            this.radio_coke = new System.Windows.Forms.RadioButton();
            this.radio_fanta = new System.Windows.Forms.RadioButton();
            this.radio_coffee = new System.Windows.Forms.RadioButton();
            this.radio_water = new System.Windows.Forms.RadioButton();
            this.button_buy = new System.Windows.Forms.Button();
            this.button_1000 = new System.Windows.Forms.Button();
            this.button_500 = new System.Windows.Forms.Button();
            this.button_100 = new System.Windows.Forms.Button();
            this.label_contain = new System.Windows.Forms.Label();
            this.label_coke = new System.Windows.Forms.Label();
            this.label_fanta = new System.Windows.Forms.Label();
            this.label_coffee = new System.Windows.Forms.Label();
            this.label_water = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_form2 = new System.Windows.Forms.Button();
            this.Group_item.SuspendLayout();
            this.Group_bag.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_item
            // 
            this.Group_item.Controls.Add(this.button_reset);
            this.Group_item.Controls.Add(this.button_buy);
            this.Group_item.Controls.Add(this.radio_water);
            this.Group_item.Controls.Add(this.radio_coffee);
            this.Group_item.Controls.Add(this.radio_fanta);
            this.Group_item.Controls.Add(this.radio_coke);
            this.Group_item.Location = new System.Drawing.Point(306, 12);
            this.Group_item.Name = "Group_item";
            this.Group_item.Size = new System.Drawing.Size(200, 124);
            this.Group_item.TabIndex = 0;
            this.Group_item.TabStop = false;
            this.Group_item.Text = "List";
            // 
            // Group_bag
            // 
            this.Group_bag.Controls.Add(this.label_water);
            this.Group_bag.Controls.Add(this.label_coffee);
            this.Group_bag.Controls.Add(this.label_fanta);
            this.Group_bag.Controls.Add(this.label_coke);
            this.Group_bag.Location = new System.Drawing.Point(306, 142);
            this.Group_bag.Name = "Group_bag";
            this.Group_bag.Size = new System.Drawing.Size(200, 109);
            this.Group_bag.TabIndex = 0;
            this.Group_bag.TabStop = false;
            this.Group_bag.Text = "Bag";
            // 
            // radio_coke
            // 
            this.radio_coke.AutoSize = true;
            this.radio_coke.Location = new System.Drawing.Point(6, 20);
            this.radio_coke.Name = "radio_coke";
            this.radio_coke.Size = new System.Drawing.Size(86, 16);
            this.radio_coke.TabIndex = 0;
            this.radio_coke.TabStop = true;
            this.radio_coke.Text = "Coke(1300)";
            this.radio_coke.UseVisualStyleBackColor = true;
            // 
            // radio_fanta
            // 
            this.radio_fanta.AutoSize = true;
            this.radio_fanta.Location = new System.Drawing.Point(6, 42);
            this.radio_fanta.Name = "radio_fanta";
            this.radio_fanta.Size = new System.Drawing.Size(82, 16);
            this.radio_fanta.TabIndex = 1;
            this.radio_fanta.TabStop = true;
            this.radio_fanta.Text = "Fanta(800)";
            this.radio_fanta.UseVisualStyleBackColor = true;
            // 
            // radio_coffee
            // 
            this.radio_coffee.AutoSize = true;
            this.radio_coffee.Location = new System.Drawing.Point(6, 64);
            this.radio_coffee.Name = "radio_coffee";
            this.radio_coffee.Size = new System.Drawing.Size(87, 16);
            this.radio_coffee.TabIndex = 2;
            this.radio_coffee.TabStop = true;
            this.radio_coffee.Text = "Coffee(600)";
            this.radio_coffee.UseVisualStyleBackColor = true;
            // 
            // radio_water
            // 
            this.radio_water.AutoSize = true;
            this.radio_water.Location = new System.Drawing.Point(6, 86);
            this.radio_water.Name = "radio_water";
            this.radio_water.Size = new System.Drawing.Size(82, 16);
            this.radio_water.TabIndex = 3;
            this.radio_water.TabStop = true;
            this.radio_water.Text = "Water(400)";
            this.radio_water.UseVisualStyleBackColor = true;
            // 
            // button_buy
            // 
            this.button_buy.Location = new System.Drawing.Point(119, 20);
            this.button_buy.Name = "button_buy";
            this.button_buy.Size = new System.Drawing.Size(75, 60);
            this.button_buy.TabIndex = 4;
            this.button_buy.Text = "BUY";
            this.button_buy.UseVisualStyleBackColor = true;
            this.button_buy.Click += new System.EventHandler(this.Button_buy_Click);
            // 
            // button_1000
            // 
            this.button_1000.Location = new System.Drawing.Point(12, 12);
            this.button_1000.Name = "button_1000";
            this.button_1000.Size = new System.Drawing.Size(103, 36);
            this.button_1000.TabIndex = 0;
            this.button_1000.Text = "1000";
            this.button_1000.UseVisualStyleBackColor = true;
            this.button_1000.Click += new System.EventHandler(this.Button_1000_Click);
            // 
            // button_500
            // 
            this.button_500.Location = new System.Drawing.Point(12, 54);
            this.button_500.Name = "button_500";
            this.button_500.Size = new System.Drawing.Size(103, 38);
            this.button_500.TabIndex = 1;
            this.button_500.Text = "500";
            this.button_500.UseVisualStyleBackColor = true;
            this.button_500.Click += new System.EventHandler(this.Button_500_Click);
            // 
            // button_100
            // 
            this.button_100.Location = new System.Drawing.Point(12, 98);
            this.button_100.Name = "button_100";
            this.button_100.Size = new System.Drawing.Size(103, 38);
            this.button_100.TabIndex = 2;
            this.button_100.Text = "100";
            this.button_100.UseVisualStyleBackColor = true;
            this.button_100.Click += new System.EventHandler(this.Button_100_Click);
            // 
            // label_contain
            // 
            this.label_contain.AutoSize = true;
            this.label_contain.Location = new System.Drawing.Point(133, 67);
            this.label_contain.Name = "label_contain";
            this.label_contain.Size = new System.Drawing.Size(66, 12);
            this.label_contain.TabIndex = 3;
            this.label_contain.Text = "Contain : 0";
            // 
            // label_coke
            // 
            this.label_coke.AutoSize = true;
            this.label_coke.Location = new System.Drawing.Point(6, 17);
            this.label_coke.Name = "label_coke";
            this.label_coke.Size = new System.Drawing.Size(52, 12);
            this.label_coke.TabIndex = 5;
            this.label_coke.Text = "Coke : 0";
            // 
            // label_fanta
            // 
            this.label_fanta.AutoSize = true;
            this.label_fanta.Location = new System.Drawing.Point(6, 40);
            this.label_fanta.Name = "label_fanta";
            this.label_fanta.Size = new System.Drawing.Size(54, 12);
            this.label_fanta.TabIndex = 4;
            this.label_fanta.Text = "Fanta : 0";
            // 
            // label_coffee
            // 
            this.label_coffee.AutoSize = true;
            this.label_coffee.Location = new System.Drawing.Point(6, 63);
            this.label_coffee.Name = "label_coffee";
            this.label_coffee.Size = new System.Drawing.Size(59, 12);
            this.label_coffee.TabIndex = 6;
            this.label_coffee.Text = "Coffee : 0";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(6, 84);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(54, 12);
            this.label_water.TabIndex = 7;
            this.label_water.Text = "Water : 0";
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(119, 86);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 5;
            this.button_reset.Text = "RESET";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.Button_reset_Click);
            // 
            // button_form2
            // 
            this.button_form2.Location = new System.Drawing.Point(12, 256);
            this.button_form2.Name = "button_form2";
            this.button_form2.Size = new System.Drawing.Size(75, 23);
            this.button_form2.TabIndex = 4;
            this.button_form2.Text = "Form2";
            this.button_form2.UseVisualStyleBackColor = true;
            this.button_form2.Click += new System.EventHandler(this.Button_form2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 291);
            this.Controls.Add(this.button_form2);
            this.Controls.Add(this.label_contain);
            this.Controls.Add(this.button_100);
            this.Controls.Add(this.button_500);
            this.Controls.Add(this.button_1000);
            this.Controls.Add(this.Group_bag);
            this.Controls.Add(this.Group_item);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Group_item.ResumeLayout(false);
            this.Group_item.PerformLayout();
            this.Group_bag.ResumeLayout(false);
            this.Group_bag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_item;
        private System.Windows.Forms.Button button_buy;
        private System.Windows.Forms.RadioButton radio_water;
        private System.Windows.Forms.RadioButton radio_coffee;
        private System.Windows.Forms.RadioButton radio_fanta;
        private System.Windows.Forms.RadioButton radio_coke;
        private System.Windows.Forms.GroupBox Group_bag;
        private System.Windows.Forms.Button button_1000;
        private System.Windows.Forms.Button button_500;
        private System.Windows.Forms.Button button_100;
        private System.Windows.Forms.Label label_water;
        private System.Windows.Forms.Label label_coffee;
        private System.Windows.Forms.Label label_fanta;
        private System.Windows.Forms.Label label_coke;
        private System.Windows.Forms.Label label_contain;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_form2;
    }
}

