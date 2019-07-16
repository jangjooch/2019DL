using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExOne
{
    public delegate void MyDelegate();

    public class EventClass
    {
        public event MyDelegate myevent;

        public void func()
        {
            myevent();
            // func()을 통하여 myevent를 생성
        }
    }

    class Program
    {
        static void EventCallFunc1()
        {
            Console.WriteLine(
            "EventCallFunc1() 메서드가 호출되었다!!!");
        }
        static void EventCallFunc2()
        {
            Console.WriteLine(
            "EventCallFunc2() 메서드가 호출되었다!!!");
        }        

        static void Main(string[] args)
        {
            // Delegate임으로 메소드를 +, -를 통하여 정리가 가능하다.
            EventClass ec = new EventClass();
            // myevent에 이벤트들 추가.
            ec.myevent += new MyDelegate(EventCallFunc1);
            ec.myevent += new MyDelegate(EventCallFunc2);
            ec.func();

            Console.WriteLine("##델리게이트 삭제 후##");

            ec.myevent -= new MyDelegate(EventCallFunc1);
            ec.func();

            
        }
    }
}
