using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using은 import, include와 비슷한 역할
// 메모리는 .Net에서 관리하므로 사람이 따로 할 의무는 없음

namespace Project1
{
    class Class001
    {
        static void Main(string[] args)
        {
            Class001 write = new Class001();
            Class1 Dating = new Class1();
            Class2 cal = new Class2();
            Class3 key = new Class3();
            Class4 dal = new Class4();
            write.write();
            Dating.dateing();
            cal.calculator();
            key.Key();
        }
        public void write()
        {
            Console.WriteLine("haha"); // cw 탭 탭 으로 단축키 가능
            System.Console.WriteLine("ha");
            // System : 기본 제공 네임스페이스 -> 클래스 묶음
            // namespace : 충돌을 방지하기 위함.
            // Console : 클래스
            // WriteLine : 메소드
            // namespace -> class -> method
            string str01 = "Name";
            System.Console.WriteLine(str01);
            System.Console.WriteLine(str01.Length);
            System.Console.WriteLine(str01.Length.GetType());
            string input01 = System.Console.ReadLine();
            try // 입력받은 거을 int화 할 수 있으면 그대로 출력
            {
                int input01_int = Int32.Parse(input01);
                System.Console.WriteLine("this is the parsed Int from input01 => " + input01_int);
            }
            catch (FormatException) // int화 하지 못하면 이하 출력
            {
                Console.WriteLine("Unable to parse into int type");
            }
            Console.WriteLine("1" + 1 + 1); // 처음에 string이 있으므로 위에 있는 것들도 string 취급한다. output : 111
            Console.WriteLine(1 + 1 + 1);   //
            Console.WriteLine(1 + 1 + "1"); // 처음에 int가 있으므로 실행되다
                                            // string은 그냥 string형으로 판단 출력한다. output : 21
            Console.WriteLine('1' + 'a'); // string을 싱글 쿼테이션을 주면
                                          // 아스키 코드값이 출력된다. output : 11의 아스키값
            Console.WriteLine("1" + 'a'); // 앞에 더블 쿼테이션을 주었기에 string으로 인식하고 뒤의 것도 string으로 인식
            Console.WriteLine('a');     // 하지만 싱글쿼테이션이 혼자 있는 경우에는 string으로 받아들인다.
            Console.WriteLine("123456\b"); // backspace. 지워짐.
            Console.WriteLine("123456\a"); // 알림음
            Console.WriteLine("123\"456"); // " 출력을 위해선 \"
            Console.WriteLine("123\\456"); // \ 출력을 위해선 \\
            Console.WriteLine("{0:C}", 123456789); // 통화 표시를 위함. output : \123.456.789
            Console.WriteLine("{0: C}", 123456789); // 떨어져 있으면 문자 C 춮력
            Console.WriteLine("{0:C} |\t| {1: C}", 123456789, 987654321);
            Console.WriteLine("{0:D}", 123); // 데시발 표시위함.
            Console.WriteLine("{0:E}", 123456789); // 고정 소수점
            Console.WriteLine("{0:G}", -123.5); // 
            Console.WriteLine("{0:F}", -123789); // 소수점 2자리까지
            Console.WriteLine("{0:N}", 123789); // 천단위로 끊음.
            Console.WriteLine("{0,20:N}", 123789); // 20의 사이즈에 채워 넣는다.
            Console.WriteLine("{0:P}", 123789); // 퍼센트

            
        }
        
        
            
    }
}


