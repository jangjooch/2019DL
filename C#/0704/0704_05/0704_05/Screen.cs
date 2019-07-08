using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_05
{
    class Screen
    {
        public void Welcome()
        {
            Console.WriteLine("select beverage");
            Console.Write("1.coke(600), 2.coffee(550), 3.fanta(420), 4.water(370)\n");
            int money = 0;
            Selector selector = new Selector();
            Changer changer = new Changer();
            //Safe safe = new Safe();
            while (true)
            {
                if (money == 0)
                {
                    money = changer.InputCoin();
                    if (money < 370)
                    {
                        Console.WriteLine("살 수 있는 것이 없습니다.");
                        Console.Write("금액을 더 넣으시겠습니까? : ");
                        string answer = Console.ReadLine();
                        if (answer.Equals("n"))
                        {
                            Console.WriteLine("\n자판기 종료");
                            break;
                        }
                        else
                        {
                            money = changer.InputCoin();
                            continue;
                        }
                    }
                }
                else if (money < 370)
                {
                    Console.WriteLine("살 수 있는 것이 없습니다.");
                    Console.Write("금액을 더 넣으시겠습니까? : ");
                    string answer = Console.ReadLine();
                    if (answer.Equals("n"))
                    {
                        Console.WriteLine("\n자판기 종료");
                        Console.WriteLine("구매 현황");                        
                        for(int i = 0; i < Safe.Bag.Length; i++)
                        {
                            Console.WriteLine(Safe.Label[i] + " : " + Safe.Bag[i]);
                            Console.WriteLine("잔돈 : " + Safe.Total_money);
                        }
                        break;
                    }
                    else
                    {
                        money = changer.InputCoin();
                        continue;
                    }
                }                
                selector.SelectDrink(money);
                Console.Write("Try More? : ");
                string exit = Console.ReadLine();
                money = Safe.Total_money;
                if (exit.Equals("n"))
                {
                    Console.WriteLine("\n자판기 종료");
                    Console.WriteLine("구매 현황");
                    for (int i = 0; i < Safe.Bag.Length; i++)
                    {
                        Console.WriteLine(Safe.Label[i] + " : " + Safe.Bag[i]);
                    }
                    Console.WriteLine("잔돈 : " + Safe.Total_money);
                    break;
                }
                Console.WriteLine();
            }
        }        
    }
}
