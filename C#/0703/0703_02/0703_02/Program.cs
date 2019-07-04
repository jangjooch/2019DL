using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_02
{
    class BoxC
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 0)
                {
                    x = value;
                }
                else
                {
                    Console.WriteLine("type over 0");
                }
            }
        }
        private int y;
        public int Y { get => y; set => y = value; }
    } 
    class BoxB
    {
        private int w;
        private int h;
        
        public BoxB(int w,int h)
        {
            if (w > 0 || h > 0)
            {
                this.W = w;
                this.H = h;
            }
            else
            {
                Console.WriteLine("input over 0");
            }
        }

        public int H { get => h; set => h = value; }
        // 우클릭 -> 빠른 작업
        public int W { get => w; set => w = value; }

        public void Area()
        {
            Console.WriteLine(W * H);
        }
    }
    class BoxA
    {
        public int w;
        public int h;
        public BoxA(int w,int h)
        {
            this.w = w;
            this.h = h;
        }
        public int Area()
        {
            return w * h;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BoxA a = new BoxA(2, 3);
            a.Area();
            BoxB b = new BoxB(2, 3);
            int num = b.H;
            Console.WriteLine(num);
            b.H = 5;
            num = b.H; // 이렇게 getter와 setter를 단순화 할 수 있다.
            Console.WriteLine(num);
        }
    }
}
