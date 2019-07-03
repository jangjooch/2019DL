using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_02
{
    class Class4
    {
        private string name;
        private int price;
        public Class4(string s = "NULL", int n = 0)
        {
            this.name = s;
            this.price = n;
        }
        ~Class4(){
            Console.WriteLine("Class4 소멸자");
        }


    }
}
