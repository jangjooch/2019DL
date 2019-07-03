using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702
{
    class grocery
    {
        public string[] items = { "apple", "orange", "pear" };
        public int[] prices = { 500, 1100, 1300 };
        private int changes = 0;
        public string bag = "in bag : ";
        public void setChanges(int money)
        {
            changes = money;
        }
        public int getChanges()
        {
            return changes;
        }
        public void addChanges(int money)
        {
            changes = changes + money;
        }
        public void money_ok(int choice)
        {
            if (changes > prices[choice-1])
            {
                changes = changes - prices[choice-1];
                bag = bag + items[choice-1] + " ";
            }
            else
            {
                Console.WriteLine("not enough money : " + changes);
            }
        }
        public void buy(int choice)
        {
            if (choice == 1)
            {
                money_ok(choice);
            }
            else if (choice == 2)
            {
                money_ok(choice);
            }
            else if (choice == 3)
            {
                money_ok(choice);
            }
            else
            {
                Console.WriteLine("no Item");
            }
        }
        public string shop_finish()
        {
            return bag;
        }
        
    }
}
