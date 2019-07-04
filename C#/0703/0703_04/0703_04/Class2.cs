using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703_04
{
    class Animal
    {
        public virtual void Eat() // override를 위한 virtual
        {
            Console.WriteLine("something is eating");
        }
    }
    class Dog:Animal
    {
        public override void Eat() // override
        {
            Console.WriteLine("Oh that's dog : override");
        }
    }
    class Cat : Animal
    {
        public new void Eat() // hidding -> 이렇게 된다면 
        {
            Console.WriteLine("Wow it's cat : hidding");
        }
    }
    // 새도잉 : 특정 영역에서 이름이 겹친 다른 변수를 가리키는 것
    // 하이딩 : 부모 클래스와 자식 클래스에 
    // 동일한 이름의 멤버를 만들때 발생

    // 메소드는 변수와 달리 오버라이딩을 할것인가 하이딩을 할것인지 명확하게 정해야함.
    class Class2
    {
        List<Animal> animals = new List<Animal>() { new Dog(), new Cat(), new Dog(), new Cat(), new Animal() };
        public void print()
        {
            foreach (var item in animals)
            {
                item.Eat();
            }
        }
    }
}
