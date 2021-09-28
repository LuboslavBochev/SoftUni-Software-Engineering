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

            Person george = new Person();

            george.Name = "George";
            george.Age = 18;

            Person sam = new Person();

            sam.Name = "Sam";
            sam.Age = 43;

            Person rob= new Person("Rob", 20);
        }
    }
}
