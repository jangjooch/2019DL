using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_02
{
    class Class3
    {
        class inside3
        {
            public void Method()
            {
                Console.WriteLine("class inside Class3");
            }
        }

        class Test
        {
            public int Multi(int a, int b)
            {
                return a * b;
            }
        }
        inside3 inside = new inside3();
        Test test = new Test();
    }
}
