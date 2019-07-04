using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_07
{
    class Changer
    {
        int money =0;
        int t_money=0;
        public void add_money(int m)
        {
            t_money = t_money + m;
        }
        public int InputCoin()
        {
            Console.Write("type money : ");
            string temp = Console.ReadLine();
            try
            {
                money = int.Parse(temp);
                money = money + t_money;
                t_money = money;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return money;
        }
        public void pay(int payment)
        {
            if(payment > money)
            {
                Console.WriteLine("not enough monry. u got : "+money);                
            }
            else
            {
                Console.WriteLine("done");
            }
        }
        public int changes()
        {
            return t_money;
        }
        public void ChangePay(int money, int s, String drink)
        {
            int temp;
            int m_1000, m_500, m_100, m_50, m_10;
            string sel;
            if (money < s)
            {
                Console.WriteLine("Not enough money u got " + t_money);
                Console.Write("will u pay more? : ");
                sel = Console.ReadLine();
                if (sel.Equals("y"))
                    money = InputCoin();
                else if (sel.Equals("n"))
                {
                    Console.WriteLine("End Vending Machine");
                }                
            }
            else
            {
                money = money - s;
                m_1000 = money / 1000;
                temp = money % 1000;
                m_500 = temp / 500;     // 500
                temp = temp % 500;
                m_100 = temp / 100;     // 100
                temp = temp % 100;
                m_50 = temp / 50;     // 100
                temp = temp % 50;
                m_10 = temp / 10;       // 10
                Console.WriteLine("Selected drink is " + drink + ", and change is " + money);
                Console.WriteLine("1000 : " + m_1000 + " 500 : " + m_500 + " 100 : " + m_100 + " 50 : " + m_50 + " 10 : " + m_10);
                t_money = money;
            }
        }
    }
}
