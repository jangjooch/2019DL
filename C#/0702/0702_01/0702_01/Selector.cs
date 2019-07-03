using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_01
{
    class Selector
    {
        string[] name = { "water", "small coke", "sprite", "juice" };
        Changer changer = new Changer();
        int money_input;
        

        public void pay()
        {
            try
            {
                Console.Write("insert money");
                string temp = Console.ReadLine();
                money_input = int.Parse(temp);

            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message); ;
            }
            changer.input(money_input);
            try
            {
                foreach(string str in name)
                {
                    int i = 1;
                    Console.Write(i+str+" ");
                    i++;
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message); ;
            }
        }

    }
}
