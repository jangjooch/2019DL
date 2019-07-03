using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_02
{
    class Class1
    {
        class Hidden
        {
            private Hidden()
            {

            }
        }
        class Sample
        {
            public static int value;
            static Sample()// 정적 생성자도 생성 가능
            {
                value = 10;
                Console.WriteLine("정적 생성자");
            }
        }
        class Test01
        {
            public void Method()
            {
                Console.WriteLine("inside class");
            }
        }
        class Test02 :Class1
        {
            public int Multi(int a,int b)
            {
                return a * b;
            }
            public void TMethod()
            {
                Class1.Main(new string[] { "" }); // 이렇게 메인에 접근이 가능하다.
            }
        }
        protected static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine(rand.Next(100, 1000)); // .Next() 범위지정
            Console.WriteLine(rand.NextDouble()); // .NextDouble() 0~1까지의 임의의 소수점 난수
            Console.WriteLine((int)(rand.NextDouble()*10)); // double은 int보다 컸기에 강제 형변환 가능
            Console.WriteLine();
            int[] arr_int01 = new int[10]; // 배열
            long[] arr_long01 = new long[10];
            string[] arr_string01 = new string[10];

            List<int> list_int01 = new List<int>(); // 리스트
            List<int> list_int02 = new List<int>() { 1, 2, 3, 4};

            foreach(var item in list_int02)
            {
                Console.WriteLine("Count : " + list_int02.Count + "\tItem : "+item);
            }
            for(int i = 0; i < 10; i++)
            {
                list_int01.Add(rand.Next(1, 10));
            }
            Console.WriteLine();
            foreach (var item in list_int01)
            {
                Console.WriteLine("Count : " + list_int01.Count + "\tItem : " + item);
            }
            Console.WriteLine();
            list_int01.Remove(list_int01[0]); // Remove는 해당 int를 가장 처음 발견한 것 지움
            list_int01.RemoveAt(list_int01.Count - 1); // RemoveAt은 해당 인덱스의 것 지움
            foreach (var item in list_int01)
            {
                Console.WriteLine("Count : " + list_int01.Count + "\tItem : " + item);
            }
            Console.WriteLine();
            Console.WriteLine(Math.Ceiling(53.4)); // 소수점 이하 올림
            Console.WriteLine(Math.Floor(53.4)); // 소수점 이하 삭제
            Console.WriteLine();

            Class2 man01 = new Class2("Jang","pw","Anyang");
            Class2 man02 = new Class2();
            Class2 man03 = new Class2()
            {
                addr = "Busan"
            };// public 인스턴스에 한에서 다형성 생성 가능
            man02.addr = "Seoul";
            man01.print();
            Class2.jobCode = "100";
            man01.print();
            man02.print();
            Console.WriteLine("\nClass3\n");
            Class3 class3 = new Class3();
            Test01 test01 = new Test01();// 내부클래스는 해당 내부클래스가 
                                         // 생성된 클래스 내부에서만 사용이 가능하다.
            test01.Method();
            // Hidden hidden = new Hidden();
            // private 생성자이기에 생성자 접근이 불가능 하다.
            Sample sample = new Sample(); // static생성자는 접근이 가능하지만 
                                          //  Console.WriteLine(sample.value); 정적으로 생성된 것은 접근이 불가능하다.

            Class4 class4 = new Class4();

        }
    }
}
