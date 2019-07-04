using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_03
{
    class Animal
    {
        private void Private()
        {
            Console.WriteLine("call private");
        }
        protected void Protected()
        {
            Console.WriteLine("call protected");
        }
        public void Public()
        {
            Console.WriteLine("call public");
        }
        public int Age { get; set; }
        public Animal()
        {
            Console.WriteLine("something is created");
            this.Age = 0;
        }
        public void Eat()
        {
            Console.WriteLine("is eating");
        }
        public void Sleep()
        {
            Console.WriteLine("is sleeping");
        }
        public void Sound()
        {
            Console.WriteLine("someone is making sound");
        }
        ~Animal()
        {
            Console.WriteLine("something is disappearing");
        }
    }
    class Bird : Animal
    {
        public Bird()
        {
            //base.Private(); private은 자식에서도 못 부른다.
            base.Protected(); // protected는 자식에서는 접근이 가능하다.
            Console.WriteLine("bird is created");
        }
        ~Bird()
        {
            Console.WriteLine("bird is disappearing");
        }
        public string Color { get; set; }
        public void Sound() // Overriding
        {
            base.Sound();
            Console.WriteLine("by using base. we call the Animal's Sound");
            Console.WriteLine("bird is singing");            
        }
    }
}
