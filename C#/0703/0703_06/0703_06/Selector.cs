using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_06
{
    class Selector
    {
        Machine market = new Machine();
        public string[] items = { "apple", "orange", "pear" };
        public int[] prices = { 500, 1100, 1300 };
        public void select()
        {                 
            bool ok = true;
            int choice = 0;
            do
            {
                Console.Write("1. apple(500), 2. orange(1100), 3. pear(1300) : ");
                string s_choice = Console.ReadLine();
                try
                {
                    choice = int.Parse(s_choice);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (choice > 0 && choice < 4)
                {
                    Console.WriteLine("fine selection");
                    ok = false;
                }
                else
                {
                    Console.WriteLine("cant accept try again. 1 - 3");
                }
            } while (ok);
            if (choice == 1)
            {
                market.buy(1);
            }
            else if (choice == 2)
            {
                market.buy(2);
            }
            else
            {
                market.buy(3);
            }
        }
        public void done()
        {
            string having = market.shop_finish();
            int changes = market.getChanges();
            //Console.WriteLine("list : " + having + "\nchanges : " + changes);
            string[] stuff = having.Split(' ');
            int[] many = { 0, 0, 0 };
            foreach (string str in stuff)
            {
                if (str.Equals("apple"))
                {
                    many[0]++;
                }
                else if (str.Equals("orange"))
                {
                    many[1]++;
                }
                else if (str.Equals("pear"))
                {
                    many[2]++;
                }
            }
            Console.WriteLine("apple : " + many[0] + "\torange : " + many[1] + "\tpear" + many[2]);
        }
        public void pay()
        {
            Console.Write("input money : ");
            string type = Console.ReadLine();
            int money = 0;
            try
            {
                money = int.Parse(type);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            market.addChanges(money);
        }
    }
}
