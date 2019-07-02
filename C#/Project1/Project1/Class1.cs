using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Class1
    {
        public void dateing()
        {
            Console.WriteLine(System.DateTime.Now + "\n");
            Console.WriteLine(System.DateTime.Now.Month + "\n");
            Console.WriteLine(System.DateTime.Now.Month + 12 + "\n"); // 월이 int로 반환되기 때문에 가능함. 단 월을 고려하지 않아 12를 초과 가능
            Console.WriteLine(System.DateTime.Now.AddMonths(6) + "\n"); // 이렇게 하면 월이라는 개념 안에서 더해질 수 있다.
            Console.WriteLine("{0:D}\n", System.DateTime.Now); // 한글
            Console.WriteLine("{0:d}\n", System.DateTime.Now); // 숫자만
            Console.WriteLine("{0:M}\n", System.DateTime.Now); // 월일
            Console.WriteLine("{0:R}\n", System.DateTime.Now); // 영문
            Console.WriteLine("{0:U}\n", System.DateTime.Now);
            Console.WriteLine("{0:u}\n", System.DateTime.Now);
            Console.WriteLine("{0:G}\n", System.DateTime.Now); // 오전 오후 표시
            Console.WriteLine("{0:g}\n", System.DateTime.Now); // 오전 오후 표시. 단 초 제외
            Console.WriteLine("{0:Y}\n", System.DateTime.Now); // 년도 월 까지만 표시
            /* 데이터 타입
             * .net         c++, Java
             * int32        int
             * int64        long
             * double       double
             * single       float
             * char         char
             * string       string
             * boolean      bool
             */

            string year = "2019";
            string month = "07";
            string day = "01";
            int iyear = System.Convert.ToInt32(year);
            int imonth = System.Convert.ToInt32(month); // 07 같은 앞의 앞자리 0은 가능함.
            Console.WriteLine(iyear + "\t" + imonth);
            object myDT = System.DateTime.Now; // 모든 자료형 atuo와 같은 사용법. var은 데이터의 자동 형변환이 일어남.
            Console.WriteLine(myDT);

        }
        // 날짜
        

    }
}
