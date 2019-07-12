using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0711_Delegate_Example
{
    public delegate void onClick(string what);
    // onClick이 델리게이트 이름
    // 호출하는 메소드의 반환형은 void이다.
    // 호출하는 파라미터는 string형 이다.
    // 즉, onClick이 대리할 수 있는 조건은 void반환형이며, 매개변수로 string형을 하나 가진다.
    class TestDele
    {
        public void func(string s)
        {
            Console.WriteLine(s);
        }
        public void KeyBoradClick(string what)
        {
            Console.WriteLine("Clicked KeyBorad's {0} Key", what);
        }
        public void MouseClick(string what)
        {
            Console.WriteLine("Clicked Mouse's {0} Button", what);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            TestDele testDele = new TestDele();
            onClick dm01 = new onClick(testDele.MouseClick);
            dm01("Left"); // == MouseClick("Left");
            // Delegate dm01가 onClick의 MouseClick에 대한 대리권한을 가졌다.
            // 이는 dm01가 MouseClick에 대한 포인터를 가졌다는 의미로
            // dm01을 사용함으로서 MouseClick을 사용할 수 있다.
            dm01 = new onClick(testDele.KeyBoradClick);
            // 이렇게 초기화가 가능하다.
            dm01("Space");
            dm01 = testDele.func;
            // 이렇게 이미 객체가 생성이 되어있는 상태라면 이와 같이 생성이 가능하다.
            dm01("func (string)");
            Console.WriteLine();

            onClick dm02 = new onClick(testDele.KeyBoradClick);
            onClick dm03 = new onClick(testDele.MouseClick);
            Console.WriteLine("dm01에 dm01, dm02, dm03 권한 부여");
            dm01 = dm01 + dm02 + dm03;
            // 위와 같은 방법으로 dm01는 기존의 func에 대한 권한에 더하여
            // KeyBoradClick과 MouseClick의 권한 2가지를 더하여 사용할 수 있다.
            // 연산자 중복을 통한 overloading 이다.
            dm01("Combine");
            Console.WriteLine("\n dm02 권한 삭제");
            dm01 = dm01 - dm02;
            dm01("Selected");

            Console.WriteLine();
            onClick ob;
            ob = delegate (string str)
            {
                // 입력 메소드. 즉흥적으로 생성이 가능하다.
                // 이렇게 함으로서 간단한 함수를 생성이 가능하다.
                Console.WriteLine("str = {0}", str);
            };
            ob("Creating Method at Delegate");
        }
    }
}
