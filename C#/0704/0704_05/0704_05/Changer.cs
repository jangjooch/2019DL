using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_05
{
    class Changer
    {
        //public static int t_money;
        Selector selector = new Selector();
        public void ChangePay(int money, int s, String drink)
        { // 거스름돈
            int temp;
            int m_1000, m_500, m_100, m_50, m_10;
            char sel;
            //Safe safe = new Safe();
            if (money < s)
            {      // 소지금보다 음료수가 비쌀경우
                Console.WriteLine("잔액이 부족합니다.\n" +
                    " 잔액 : " + Safe.Total_money +"구매하려는 금액 : " + s );
                Console.Write("금액을 더 넣으시겠습니까(y/n)? : ");
                sel = char.Parse(Console.ReadLine());
                if (sel == 'y')                      // 추가 입금
                    InputCoin();
                else if (sel == 'n')
                {               // 프로그램 종료                    
                    Console.WriteLine("\n자판기 종료");
                    Console.WriteLine("구매 현황");
                    for (int i = 0; i < Safe.Bag.Length; i++)
                    {
                        Console.WriteLine(Safe.Label[i] + " : " + Safe.Bag[i]);
                    }
                    Console.WriteLine("잔돈 : " + Safe.Total_money);
                    System.Environment.Exit(0);
                }
                else
                    selector.SelectDrink(money); // 중첩 조건문의 dangling else 설명(block처리하기전)
            }
            else
            {                      // 거스름돈 계산(계산 방식에 따른 잔돈갯수 설명:조건문과 동일)
                money -= s;
                m_1000 = money / 1000;  // 1000 거스름돈 계산 시 temp 사용하는 이유
                temp = money % 1000;
                m_500 = temp / 500;     // 500
                temp = temp % 500;
                m_100 = temp / 100;     // 100
                temp = temp % 100;
                m_50 = temp / 50;     // 50
                temp = temp % 50;
                m_10 = temp / 10;     // 10     
                // 10원 계산할때 유의 할것(나머지 계산 필요X)
                switch (drink)
                {
                    case "콜라":
                        Safe.Bag[0] += 1;
                        break;
                    case "물":
                        Safe.Bag[3] += 1;
                        break;
                    case "환타":
                        Safe.Bag[1] += 1;
                        break;
                    case "커피":
                        Safe.Bag[2] += 1;
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("뽑으신 음료수는 " + drink + "이며 거스름돈은  " + money + "원 입니다.");
                Console.WriteLine("1000원 : " + m_1000 + ", ");
                Console.WriteLine("500원 : " + m_500 + ", ");
                Console.WriteLine("100원 : " + m_100 + ", ");
                Console.WriteLine("50원 : " + m_50 + ", ");
                Console.WriteLine("10원 : " + m_10);
                Console.WriteLine("---------------------------------------- -------");
                Console.WriteLine();
                Safe.Total_money = money;
            }
        }
        public int InputCoin()
        {
            Boolean right = true;
            int money = 0;
            do
            {
                try
                {
                    Console.Write("금액을 입력하세요: ");
                    money = int.Parse(Console.ReadLine());
                    right = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }                                 
            } while (right);
            money += Safe.Total_money;   // 거스름돈과 임시 저장소의             
            Safe.Total_money = money;    // 가격을 같게
            Console.WriteLine(">>현재 자판기에는 " + money + "원이 있습니다.");
            return money;
        }
    }
}
