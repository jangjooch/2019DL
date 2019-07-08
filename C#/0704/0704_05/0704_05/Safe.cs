using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0704_05
{
    class Safe
    {
        private static int total_money;
        private static int[] bag = { 0, 0, 0, 0 };
        private static string[] label = { "Coke", "Fanta", "Coffee", "Water" };
        public static int Total_money { get => total_money; set => total_money = value; }
        public static int[] Bag { get => bag; set => bag = value; }
        public static string[] Label { get => label; set => label = value; }
    }
}
