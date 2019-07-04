using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_01
{
    public class Class1
    {
        static int WATER = 500;
        static int COKE = 600;
        static int COFFEE = 1000;
        static int JUICE = 1300;
        static string D1 = "water";
        static string D2 = "coke";
        static string D3 = "coffee";
        static string D4 = "juice";
        static int money;
        static int t_money = 0;
        static int InputCoin()
        {
            Console.Write("type money");
            string temp = Console.ReadLine();
            try
            {
                money = int.Parse(temp);
                money = money + t_money;
                t_money = money;
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return money;
        }
        static void ChangePay(int money, int s, String drink)
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
                    SelectDrink(money);
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
                Console.WriteLine("1000 : "+m_1000+" 500 : "+m_500 + " 100 : "+m_100 + " 50 : "+m_50+" 10 : "+m_10);
                t_money = money;
            }
        }
        static void SelectDrink(int money)
        {
            string sel_str;
            int sel = 0;
            Console.Write("select : ");
            sel_str = Console.ReadLine();
            try
            {
                sel = int.Parse(sel_str);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            switch (sel)
            {
                case 1:
                    ChangePay(money, WATER, D1);
                    break;
                case 2:
                    ChangePay(money, COKE, D2);
                    break;
                case 3:
                    ChangePay(money, COFFEE, D3);
                    break;
                case 4:
                    ChangePay(money, JUICE, D4);
                    break;
                default:
                    Console.WriteLine("switch error");
                    break;
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("select beverage");
            Console.Write("1. water, 2.coke, 3.coffee, 4.juice\n");
            money = 0;
            while (true)
            {
                if (money == 0)
                {
                    money = InputCoin();
                }
                SelectDrink(money);
                Console.Write("Try More? : ");
                string exit = Console.ReadLine();
                money = t_money;
                if (exit.Equals("n"))
                {
                    Console.WriteLine("select finish");
                    break;
                }
                Console.WriteLine();
            }
        }
        
    }
    
}
