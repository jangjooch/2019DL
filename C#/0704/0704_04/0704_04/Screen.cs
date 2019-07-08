using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_04
{
    class Screen
    {
        public void Welcome()
        {
            Console.WriteLine("select beverage");
            Console.Write("1. coke(600), 2.coffee(550), 3.fanta(370), 4.water(420)\n");
            int money = 0;
            Selector selector = new Selector();
            Changer changer = new Changer();
            //Safe safe = new Safe();
            while (true)
            {
                if (money == 0)
                {
                    money = changer.InputCoin();
                }
                selector.SelectDrink(money);
                Console.Write("Try More? : ");
                string exit = Console.ReadLine();
                money = Safe.Total_money;
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
