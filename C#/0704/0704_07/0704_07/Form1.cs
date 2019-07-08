using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0704_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "Button";
            for(int i = 0; i < 4; i++)
            {
                Button button = new Button();
                Controls.Add(button);
                button.Location = new Point(100, 10 + (20 + 10) * i);
                button.Text = "Created " + i;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "text Changed";
        }
    }
}
