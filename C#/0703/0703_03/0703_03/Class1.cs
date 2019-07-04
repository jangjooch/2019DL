using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_03
{
    class Dog
    {
        public int Age { get; set; } // 단축키 : prop
        public string Color { get; set; }
        public Dog() // 생성자 단축키 ctor
        {
            this.Age = 0;
        }
        public void Eat()
        {
            Console.WriteLine("dog is eating");
        }
        public void Sleep()
        {
            Console.WriteLine("dog is sleeping");
        }
        public void Bark()
        {
            Console.WriteLine("dog is barkking");
        }
    }
    class Cat
    {
        public int  Age{ get; set; }
        public Cat()
        {
            this.Age=0;
        }
        public void Eat()
        {
            Console.WriteLine("cat is eating");
        }
        public void Sleep()
        {
            Console.WriteLine("cat is sleeping");
        }
        public void Bark()
        {
            Console.WriteLine("cat is barkking");
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>() { new Dog(),new Dog(), new Dog()};
            List<Cat> cats = new List<Cat>() { new Cat(), new Cat()};
            List<Bird> birds = new List<Bird>() { new Bird(), new Bird() };
            foreach (var item in dogs)
            {                
                item.Eat();
            }
            foreach (var item in cats)
            {
                item.Sleep();
            }
            foreach (var item in birds)
            {
                item.Sound();
            }
            Animal ani = new Animal();
            //ani.Priavte(); 이렇듯 private과 protected는 부르지 못한다.
            //ani.Protected();
            ani.Public();
            
        }
    }
}
