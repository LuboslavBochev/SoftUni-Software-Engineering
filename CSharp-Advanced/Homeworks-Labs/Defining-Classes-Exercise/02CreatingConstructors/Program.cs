using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person();

            peter.Name = "Peter";
            peter.Age = 20;

            Person rob = new Person(20);

            Person bob = new Person("Robert", 32);
        }
    }
}
