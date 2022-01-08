using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog john = new Dog();
            john.Eat();
            john.Bark();

            Cat mike = new Cat();
            mike.Eat();
            mike.Meow();
        }
    }
}
