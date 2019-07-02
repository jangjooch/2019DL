using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Class3
    {
        public void Key()
        {
            Console.WriteLine("type <- or ->");
            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.RightArrow:
                    Console.WriteLine("->");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("<-");
                    break;
                default:
                    Console.WriteLine("type other things");
                    break;
            }
            string[] string_arr01 = { "apple", "pear", "watermelon", " orange" };
            foreach (var str in string_arr01)
            {
                Console.Write(str + "\t");
            }
            Console.WriteLine("");
            // dangling else
            int a = 2;
            int b = 5;
            if (a > 3)
                if (a > 5)
                    Console.WriteLine("\n" + a);
                else
                    Console.WriteLine("\n" + b);
            // 이상태에서는 출력 되지 않는다. why? 블록이 없으므로 else가 가장 가까운 if의 것으로 인식되므로.
            if (a > 3)
            {
                if (a > 5)
                {
                    Console.WriteLine("\n" + a);
                }
            }
            else
            {
                Console.WriteLine(b);
            }
            // 고로 햇갈리지 않도록 블록을 생활화한다.
            for(int i = 1; i < 6; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            // 직각 삼각형

            for(int i = 0; i < 6; i++)
            {
                for(int j = 5 - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                for(int k = 0; k <(i*2)+1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            // 정삼각형
            int routine = 6;
            for (int i = 0; i < routine; i++)
            {
                for (int j = routine -1 - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < (i * 2) + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            // 태두리 01
            for (int i = 0; i < routine; i++)
            {
                for (int j = routine - 1 - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = 0; k < (i * 2) - 1; k++)
                {
                    Console.Write(" ");
                }
                if (i == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("*\n");
                }
            }
            // 테두리 02
            for (int i = 0; i < routine; i++)
            {
                for (int j = routine - 1 - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < (i * 2) + 1; k++)
                {
                    if (k == 0)
                    {
                        Console.Write("*");
                    }
                    else if (k==(i*2))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            // 마름모
            int dia = 12;
            for (int i = 0; i < dia; i++)
            {
                if (i < (dia / 2)){
                    for (int j = (dia/2) - 1 - i; j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < (i * 2) + 1; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = i - ( dia / 2 ) ; j > 0 ; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = (dia - i ) * 2 - 1 ; k >0 ; k--)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                
            }
            // 마름모 태두리
            for (int i = 0; i < dia; i++)
            {
                if (i < (dia / 2))
                {
                    for (int j = (dia / 2) - 1 - i; j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < (i * 2) + 1; k++)
                    {
                        if (k==0||k==(i*2))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        //Console.Write("*");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = i - (dia / 2); j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = (dia - i) * 2 - 1; k > 0; k--)
                    {
                        if (k == (dia - i) * 2 - 1 || k == 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        //Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
