using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702
{
    class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting\n");

            Customer man = new Customer();
            bool going = true;
            do
            {
                string action = "";
                Console.Write("(1.add, 2.select, 3.done)type action : ");
                action = Console.ReadLine();
                if (action == "1")
                {
                    man.pay();
                }
                else if(action == "2")
                {
                    man.select();
                }
                else if(action == "3")
                {
                    man.done();
                    going = false;
                }
                else
                {
                    Console.WriteLine("wrong action");
                }
                Console.WriteLine();
                
            } while (going);
        }
    }
}
