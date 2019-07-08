using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_03
{
    class Screen
    {
        public void Welcome()
        {
            Console.WriteLine("select beverage");
            Console.Write("1. water, 2.coke, 3.coffee, 4.juice\n");
            int money = 0;
            Selector selector = new Selector();
            Changer changer = new Changer();
            while (true)
            {
                if (money == 0)
                {
                    money = changer.InputCoin();
                }
                selector.SelectDrink(money);
                Console.Write("Try More? : ");
                string exit = Console.ReadLine();
                money = Changer.t_money;
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
