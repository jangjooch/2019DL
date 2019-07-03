using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_02
{
    class Class2
    {
        private string name; // 인스턴스 변수
        private string pw; // 인스턴스 변수 public 이냐 private이냐는 상관없음.
        public string addr;

        public static string jobCode = "001"; // 클래스 변수. static으로 클래스간 공유
        // Class2.jobCode = "100"; 이러한 형식으로 클래스간 공통적인 사항이다.

        public Class2(string n = "NULL", string p="NULL",string a = "NULL")
        {
            name = n;
            pw = p;
            addr = a;
        }
        public void print()
        {
            Console.WriteLine("JOB = "+jobCode+"\t Name = " + name+"\t PW = " + pw+"\t addr = "+addr);
        }

        
    }
}
