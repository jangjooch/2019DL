using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_07
{
    class Selector
    {
        static int WATER = 500;
        static int COKE = 600;
        static int COFFEE = 1000;
        static int JUICE = 1300;
        static string D1 = "water";
        static string D2 = "coke";
        static string D3 = "coffee";
        static string D4 = "juice";
        Changer changer = new Changer();
        public  void SelectDrink(int money)
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
                    changer.ChangePay(money, WATER, D1);
                    break;
                case 2:
                    changer.ChangePay(money, COKE, D2);
                    break;
                case 3:
                    changer.ChangePay(money, COFFEE, D3);
                    break;
                case 4:
                    changer.ChangePay(money, JUICE, D4);
                    break;
                default:
                    Console.WriteLine("switch error");
                    break;
            }
        }
        public int InputCoin()
        {
            Console.Write("type money : ");
            string temp = Console.ReadLine();
            int money=0;
            try
            {
                money = int.Parse(temp);
                changer.add_money(money);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return money;
        }
        public int get_change()
        {
            return changer.changes();
        }
    }
}
