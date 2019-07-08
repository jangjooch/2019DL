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
    
    public partial class Form1 : Form
    {
        static int total_money;
        static int[] bag = { 0, 0, 0, 0 };
        int[] price = { 1300, 800, 600, 400 };
        private void Form1_Load(object sender, EventArgs e)
        {
            total_money = 0;
        }
        public Form1()
        {
            InitializeComponent();
        }        
        private void Button_1000_Click(object sender, EventArgs e)
        {
            total_money += 1000;
            Contain_add();
        }
        private void Button_500_Click(object sender, EventArgs e)
        {
            total_money += 500;
            Contain_add();
        }
        private void Button_100_Click(object sender, EventArgs e)
        {
            total_money += 100;
            Contain_add();
        }

        public void Contain_add()
        {
            string con = "Contain : ";
            con = con + total_money.ToString();
            label_contain.Text = con;
        }       
        private void Button_buy_Click(object sender, EventArgs e)
        {
            if (radio_coke.Checked)
            {
                buy_ok(0);
            }            
            else if (radio_fanta.Checked)
            {
                buy_ok(1);
                
            }
            else if (radio_coffee.Checked)
            {
                buy_ok(2);
               
            }
            else if (radio_water.Checked)
            {
                buy_ok(3);
                
            }
            Radio_Reset();
        }
        public void buy_ok(int item)
        {
            if (total_money < price[item])
            {
                MessageBox.Show("not enough money\nInput More money");
            }
            else
            {
                bag[item] += 1;
                total_money -= price[item];
                Contain_add();
                Bag_reset();
            }
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            Radio_Reset();
        }
        public void Radio_Reset()
        {
            radio_coke.Checked = false;
            radio_fanta.Checked = false;
            radio_coffee.Checked = false;
            radio_water.Checked = false;
        }
        public void Bag_reset()
        {
            label_coke.Text = "Coke : " + bag[0];
            label_fanta.Text = "Fanta : " + bag[1];
            label_coffee.Text = "Coffe : " + bag[2];
            label_water.Text = "Water : " + bag[3];
        }
        private void Button_form2_Click(object sender, EventArgs e)
        {
            string a = " COKE : "+bag[0] + "\n FANRA : "+bag[1]+
                "\n COFFEE : "+bag[2] + "\n WATER : " + bag[3];
            Console.WriteLine(a);
            Form2 form2 = new Form2(a);
            form2.ShowDialog();
            for(int i = 0; i < bag.Length; i++)
            {
                bag[i] = 0;
            }
            Bag_reset();
            Radio_Reset();
            total_money = 0;
            Contain_add();
        }
    }
}
