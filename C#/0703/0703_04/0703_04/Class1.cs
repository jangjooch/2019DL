using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_04
{

    class Parents
    {
        public int a = 50;
        public void A()
        {
            Console.WriteLine("parents");
        }
    }
    class Child : Parents
    {
        public int a = 0;
        public void A()
        {
            Console.WriteLine("child");
        }
    }
        
    class Class1
    {
        static void Main(string[] args)
        {
            int num = 100;
            Console.WriteLine("num");
            Console.WriteLine();
            Child C01 = new Child();
            Console.WriteLine(C01.a);
            Child C02 = new Child();
            Console.WriteLine(((Parents)C02).a); // 업케스팅되어 부모의 것이 출력된다.
            C01.A();
            ((Parents)C01).A(); // 동일하게 업케스팅되어 부모의 것 출력
            // 새도잉 : 특정 영역에서 이름이 겹친 다른 변수를 가리키는 것
            // 하이딩 : 부모 클래스와 자식 클래스에 
            // 동일한 이름의 멤버를 만들때 발생

            // 메소드는 변수와 달리 오버라이딩을 할것인가 하이딩을 할것인지 명확하게 정해야함.
            Console.WriteLine();
            Class2 class2 = new Class2();
            class2.print();
        }
    }
}
