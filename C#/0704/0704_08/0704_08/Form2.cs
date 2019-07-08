using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0704_08
{
    public partial class Form2 : Form
    {
        string res = null;
        public Form2(string re)
        {
            //int[] bag = Form
            res = re;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Recipt.Text = res;
        }

        private void Button_confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
