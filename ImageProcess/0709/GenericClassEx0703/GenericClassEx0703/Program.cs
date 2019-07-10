using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassEx0703
{
    class FirstGeneric<T1,  T2>
    {
        private T1[] values;
        private int index;

        public FirstGeneric(int len)
        { // Constructor
            values = new T2[len];
            index = 0;
        }

        public void add(params T[] args)
        {
            foreach (T e in args)
                values[index++] = e;
        }

        public void print()
        {
            foreach (T e in values)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main()
        {
            /*
            FirstGeneric<Int32> gInteger = 
                new FirstGeneric<Int32>(10);
            */

            FirstGeneric<int, float> gInteger =
            new FirstGeneric<int , float>(10);

            FirstGeneric<int> gInteger =
            new FirstGeneric<int>(10);
            FirstGeneric<Double> gDouble = 
                new FirstGeneric<Double>(10);

            gInteger.add(1, 2);
            gInteger.add(1, 2, 3, 4, 5, 6, 7);
            gInteger.add(0);
            gInteger.print();



            gDouble.add(10.0, 20.0, 30.0);
            gDouble.print();
        }
    }
}
