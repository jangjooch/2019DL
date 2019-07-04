using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_05
{
    interface Kal
    {
        void kal();
    }
    interface Steak
    {
        void steak();
    }
    class dish : Kal, Steak // 이렇듯 인터페이스는 다중 상속이 가능하다.
    {
        public void kal()
        {
            Console.WriteLine("kal");
        }
        public void steak()
        {
            Console.WriteLine("steak");
        }
    }
    class Class2
    {
    }
}
