using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_03
{
    class Selector
    {
        static int COKE = 600;  // 콜라
        static int FANTA = 550; // 환타
        static int COFFEE = 370;// 커피
        static int WATER = 420; // 물
        static String D1 = "콜라";
        static String D2 = "환타";
        static String D3 = "커피";
        static String D4 = "물";
        //static int money;       // 금액
        //static int t_money = 0;   // 임시 저장소

        public void SelectDrink(int money)
        { // 음료수 선택
            Changer changer = new Changer();
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
                        changer.ChangePay(money, COKE, D1);
                        break;
                    case 2:
                        changer.ChangePay(money, FANTA, D2);
                        break;
                    case 3:
                        changer.ChangePay(money, COFFEE, D3);
                        break;
                    case 4:
                        changer.ChangePay(money, WATER, D4);
                        break;
                    default:
                        Console.WriteLine("Switch error");
                        break;
                }
            }
        }
    }
}
