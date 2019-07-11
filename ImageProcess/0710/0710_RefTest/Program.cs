using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0710_RefTest
{
    class Program
    {
        static void Swap(int ptr_a, int ptr_b)
        {
            Console.WriteLine("PTR_A : " + ptr_a+" PTR_B : "+ptr_b);
            int temp = ptr_a;
            ptr_a = ptr_b;
            ptr_b = temp;
            Console.WriteLine("After in Swap PTR_A : {0}, PTR_B : {1}", ptr_a, ptr_b);
        }
        static void Ref_Swap(ref int ptr_a, ref int ptr_b)
        {
            // ref를 통해서 인자로 받은 것의 주솟값을 받아오는 것이다.
            // ref를 통해 받은 것이므로 굳이 int *a 같은 방법을 쓰지 않아도 된다.
            // Ref_Swap이 실행될 때 ref 매개변수를 통해 해당 주소의 값을 가져오고
            // Ref_Swap이 끝날때 저절로 ref 매개변수를 통해 연결된 주소를 해제한다.
            Console.WriteLine("PTR_A : " + ptr_a + " PTR_B : " + ptr_b);
            int temp = ptr_a;
            ptr_a = ptr_b;
            ptr_b = temp;
            Console.WriteLine("After in Ref_Swap PTR_A : {0}, Ref_PTR_B : {1}", ptr_a, ptr_b);
        }
        static void manyNum(params int[] val)
        {
            // params를 통해 배열 val을 가져온다.
            foreach (int n in val)
            {
                Console.Write("n = {0}, ",n);
            }
            Console.WriteLine("\n");
        }
        static void Generic_Swap<T>(ref T ptr_a, ref T ptr_b)
        {
            // T라는 데이터 타입을 만들어 사용하는 것이다.
            // 그렇기에 T타입의 형태가 정해지지 않았기에
            // T temp = 0;와 같은 형태의 초기화를 하면 안된다.
            Console.WriteLine("PTR_A : " + ptr_a + " PTR_B : " + ptr_b);
            T temp = ptr_a;
            ptr_a = ptr_b;
            ptr_b = temp;
            Console.WriteLine("After in Swap PTR_A : {0}, PTR_B : {1}", ptr_a, ptr_b);
        }
        static void Main(string[] args)
        {
            int a = 3, b = 5;
            Swap(a, b);
            int[] nums = { 100,200,300,400 };
            Console.WriteLine("After out Swap PTR_A : {0}, PTR_B : {1}\n\n", a, b);
            // call by value 인지라 main의 것은 변화가 안됨.
            Ref_Swap(ref a, ref b);
            Console.WriteLine("After out Ref_Swap PTR_A : {0}, PTR_B : {1}\n\n", a, b);
            // call by reference
            manyNum(10, 20, 30);
            // 매개변수가 params int[] val로 되어있기 때문에 얼마나 많은 수의 int형이
            // 매개변수로 전달되든 전부 int[] val에 저장되어 사용되어 질 수 있다.
            manyNum(nums);
            // 물론 위처럼 사용될 수 있지만 기본적인 형태는 배열이기에 매개변수로 배열을 주어도 된다.

            // 제너릭
            double double01 = 3.14, double02 = 5.31;
            Generic_Swap<double>(ref double01, ref double02);
            Console.WriteLine("After out Generic_Swap PTR_A : {0}, PTR_B : {1}\n", double01, double02);
            Generic_Swap<int>(ref a, ref b);
            // 이와 같이 제네릭 함수를 사용하기에 타입형을 정해주어 메소드를 사용해야 한다.
            Console.WriteLine("After out Generic_Swap PTR_A : {0}, PTR_B : {1}", a, b);
            
        }
    }
}
