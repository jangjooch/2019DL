using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_07
{
    class Zapangi
    {
        static void Main(string[] args)
        {
            Console.WriteLine("select beverage");
            Console.Write("1. water, 2.coke, 3.coffee, 4.juice\n");
            Selector selector = new Selector();
            int money = 0;
            while (true)
            {
                if (money == 0)
                {
                    money = selector.InputCoin();
                }
                selector.SelectDrink(money);
                Console.Write("Try More? : ");
                string exit = Console.ReadLine();
                money = selector.get_change();
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
