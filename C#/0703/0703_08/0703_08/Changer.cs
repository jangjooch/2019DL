using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_08
{
    class Changer
    {
        public static int t_money = 0;
        Selector selector = new Selector();
        public void ChangePay(int money, int s, String drink)
        {
            int temp;
            int m_1000, m_500, m_100, m_50, m_10;
            string sel;
            if (money < s)
            {
                Console.WriteLine("Not enough money");
                Console.Write("will u pay more?");
                sel = Console.ReadLine();
                if (sel.Equals("y"))
                    money = InputCoin();
                else if (sel.Equals("n"))
                {
                    Console.WriteLine("End Vending Machine");
                }
                else
                {
                    selector.SelectDrink(money);
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
        public int InputCoin()
        {
            Console.Write("type money");
            string temp = Console.ReadLine();
            int m = 0;
            try
            {
                m = int.Parse(temp);
                t_money += m;                
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return t_money;
        }
    }
}
