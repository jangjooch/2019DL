using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaOverload0704
{
    class Point
    {
        private int x, y;
        public 	Point(int a, int b)
        {
            // 생성자
            x = a;
            y = b;
        }
        public Point()
        {
            // 생성자 중복
            x = 0;
            y = 0;
        }
        public void Show()
        {
            Console.WriteLine(
                "x={0}, y={1}", x, y) ;
        }
        public static Point operator+(Point pf, Point ps)
        {
            // operator+ 를 통하여 +에 대한 연산자 오버로드를 한다.
            // 즉 class Point에 대한 +연산자 작용에 대하여 재정의 하는 것이다.
            // 매개인자 Point들의 포인터를 받기떄문에 이를 통하여 계산이 가능하다.
            // 이것은 또한 반환형이 Point이기 때문에 Point를 재정의 할때 사용한다.
            // 즉 Point a = Point b + Point c; 를 가능케 한다.
            Point temp = new Point(pf.x+ps.x, pf.y + ps.y) ;
            return temp;
        }
        public static string operator-(Point pf, Point ps)
        {
            double distance = ((pf.x - ps.x) ^ 2) + ((pf.y - ps.y) ^ 2);
            string distancestr = distance.ToString();            
            return distancestr;
        }
};   


    class Program
    {
        static void Main(string[] args)
        {
            Point p1  = new Point(1,2) ;
            Point p2  = new Point(3,4) ;
            Point p3 = p1 + p2;
            p3.Show();
            Console.WriteLine("distance between : "+ (p1-p2));
        }
    }
}
