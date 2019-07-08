using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0704_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int t_money;
        private void Form1_Load(object sender, EventArgs e)
        {
            t_money = 0;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button_1000_Click(object sender, EventArgs e)
        {
            t_money += 1000;
            total_money.Text = t_money.ToString();
        }

        private void Button_500_Click(object sender, EventArgs e)
        {
            t_money += 500;
            total_money.Text = t_money.ToString();
        }

        private void Button_100_Click(object sender, EventArgs e)
        {
            t_money += 100;
            total_money.Text = t_money.ToString();
        }

        private void Total_money_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radio_coke.Checked)
            {
                t_money -= 1300;
                total_money.Text = t_money.ToString();
                radio_coke.Checked = false;
            }
            else if (radio_coffee.Checked)
            {
                t_money -= 1000;
                total_money.Text = t_money.ToString();
                radio_coffee.Checked = false;
            }
            else if (radio_water.Checked)
            {
                t_money -= 600;
                total_money.Text = t_money.ToString();
                radio_water.Checked = false;
            }
            
        }
    }
}
