using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0702_01
{
    class Changer
    {
        int money_input;
        int saved;
        int[] price = { 500, 800, 1100, 1500 };        
        public int return_change()
        {
            return saved;
        }
        public void get_money(int money)
        {       
            saved = saved + money;
        }
        public void input(int money)
        {
            money_input = money;
            get_money(money_input);
        }

    }
}
