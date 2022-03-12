using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Pesho", 25);

            bool isValid = Validator.IsValid(person);
            Console.WriteLine(isValid);
        }
    }
}


