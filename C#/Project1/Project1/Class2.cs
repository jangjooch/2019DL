using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Class2
    {
        public void calculator()
        {
            string str = "haha\n";
            Console.Write("type string : ");
            string input01 = Console.ReadLine();
            Console.WriteLine(input01);
            try
            {
                int num = int.Parse(input01);
                Console.WriteLine(num > 0 ? "자연수 O" : "자연수 X\n");
                Console.WriteLine(num%2==0 ? "짝수" : "홀수"); 
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message+"\n");
            }
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            float[] floats = { 0.1f, 2.1f, 6.4f };
            Console.WriteLine(ints.Count());
            Console.WriteLine(ints.Length+"\n");
            foreach(int i in ints)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine("\n");
            int j = 0;
            foreach (int i in ints)
            {
                ints[j] = i * i;
                j = j + 1;
            }
            j = 0;
            foreach(int i in ints)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine("\n");

            Console.Write("input days(1~30)");
            string string_day = Console.ReadLine();
            int input_day=-1;
            try
            {
                input_day = int.Parse(string_day);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            input_day = input_day / 7;
            switch (input_day)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("TusDay");
                    break;
                case 3:
                    Console.WriteLine("WedDay");
                    break;
                case 4:
                    Console.WriteLine("Thrday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("wrong input");
                    break;
            }
            



        }
    }
}
