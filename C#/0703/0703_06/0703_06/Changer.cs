using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_06
{
    class Changer
    {
        static void Main(string[] args)
        {
            Selector vend = new Selector();
            Console.WriteLine("Hello Welcome");
            Console.WriteLine("plz insert money");
            vend.pay();
            do
            {
                vend.select();
                Console.Write("will u get the changes? : ");
                string answer = Console.ReadLine();
                if (answer.Equals("y"))
                {
                    vend.done();
                    break;
                }
                else if(answer.Equals("n"))
                {
                    Console.Write("will u pay more? : ");
                    answer = Console.ReadLine();
                    while (true)
                    {
                        if (answer.Equals("y"))
                        {
                            vend.pay();
                            break;
                        }
                        else if (answer.Equals("n"))
                        {
                            break;
                        }
                    }
                }


            } while (true);
        }
    }
}
