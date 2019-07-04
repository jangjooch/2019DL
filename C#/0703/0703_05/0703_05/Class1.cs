using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_05
{
    interface Star 
    {
        // 인터페이스는 말 그대로 형태를 잡는 것이다.
        // 또한 다중 상속을 위하여 사용하는 것이다.
        void Attack();
        void Defense();
    }
    class Terran : Star
    {
        public void Attack()
        {
            Console.WriteLine("Terran Attack");
        }
        public void Defense()
        {
            Console.WriteLine("Terran Defense");
        }
    }
    class Protoss
    {
        public void Attack()
        {
            Console.WriteLine("Protoss Attack");
        }
        public void Defense()
        {
            Console.WriteLine("Protoss Defense");
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {
            Terran t = new Terran();
            t.Attack();
            Protoss p = new Protoss();
            p.Defense();
        }
    }
}
