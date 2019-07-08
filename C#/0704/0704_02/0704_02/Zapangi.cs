﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_02
{
    class Zapangi
    {
        static int COKE = 600;  // 콜라
        static int FANTA = 550; // 환타
        static int COFFEE = 370;// 커피
        static int WATER = 420; // 물
        static String D1 = "콜라";
        static String D2 = "환타";
        static String D3 = "커피";
        static String D4 = "물";
        static int money;       // 금액
        static int t_money = 0;   // 임시 저장소

        public static int InputCoin()
        {
            Console.WriteLine("금액을 입력하세요: ");
            money = int.Parse(Console.ReadLine());
            money += t_money;   // 거스름돈과 임시 저장소의 
            t_money = money;    // 가격을 같게
            Console.WriteLine(">>현재 자판기에는" + money + "원이 있습니다.");
            return money;
        }

        public static void SelectDrink(int money)
        { // 음료수 선택
            int sel;
            Console.WriteLine("음료를 선택하세요: ");
            sel = int.Parse(Console.ReadLine());

            if (sel < 1 || sel > 4)
            {// 없는 음료 선택시 SelectDrink()호출
                Console.WriteLine("Error input select agin 1~4");
                SelectDrink(money);
            }

            else
            {                          // 음료수 선택 switch문

                switch (sel)
                {
                    case 1:
                        ChangePay(money, COKE, D1);
                        break;
                    case 2:
                        ChangePay(money, FANTA, D2);
                        break;
                    case 3:
                        ChangePay(money, COFFEE, D3);
                        break;
                    case 4:
                        ChangePay(money, WATER, D4);
                        break;
                    default:
                        Console.WriteLine("Switch error");
                        break;
                }
            }
        }

        public static void ChangePay(int money, int s, String drink)
        { // 거스름돈
            int temp;
            int m_1000, m_500, m_100, m_50, m_10;
            char sel;

            if (money < s)
            {      // 소지금보다 음료수가 비쌀경우
                Console.WriteLine("잔액이 부족합니다. < drink");
                Console.WriteLine("금액을 더 넣으시겠습니까(y/n)? ");
                sel = char.Parse(Console.ReadLine());

                if (sel == 'y')                      // 추가 입금
                    InputCoin();
                else if (sel == 'n')
                {               // 프로그램 종료
                    Console.WriteLine("자판기 종료");
                    System.Environment.Exit(0);
                }
                else
                    SelectDrink(money); // 중첩 조건문의 dangling else 설명(block처리하기전)
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

                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("뽑으신 음료수는 " + drink + "이며 거스름돈은  " + money + "원 입니다.");
                Console.WriteLine("1000원 : " + m_1000 + ", ");
                Console.WriteLine("500원 : " + m_500 + ", ");
                Console.WriteLine("100원 : " + m_100 + ", ");
                Console.WriteLine("50원 : " + m_50 + ", ");
                Console.WriteLine("10원 : " + temp);
                Console.WriteLine("---------------------------------------- -------");
                Console.WriteLine();
                t_money = money;
            }
        }

        public static void Main(string[] arg)
        {
            char exit;          // 종료 체킹을 위한 변수
            Console.WriteLine("음료수 자판기 ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("1.콜라(600), 2.환타(550), 3.커피(370), 4.물(420)");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();

            money = 0;          // 체킹을 위한 초기값

            while (true)
            {
                if (money == 0)
                {
                    money = InputCoin();
                }

                SelectDrink(money);
                Console.WriteLine("음료수를 추가 선택 하시겠습니까(y/n)? ");
                exit = char.Parse(Console.ReadLine());
                money = t_money;

                if (exit == 'n' || exit == 'N')
                {   // 종료 체킹

                    Console.WriteLine("음료수 선택 종료");
                    break;                           //System.exit(0); 와의 차이점
                }
                Console.WriteLine();
            }
        }
    }
}
