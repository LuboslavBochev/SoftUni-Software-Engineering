using System;

namespace FunctionalProgramming
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());

            Person[] people = new Person[numPeople];

            for (int i = 0; i < numPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ");

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                people[i] = new Person();

                people[i].Name = name;
                people[i].Age = age;
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filterMethod = FilterMethod(filterAge, filter);
            Func<Person, string> formater = FilterFormat(format);

            PrintPeople(people, filterMethod, formater);
        }

        static Func<Person, string> FilterFormat(string format)
        {
            switch (format)
            {
                case "name":
                    return p => p.Name;

                case "age":
                    return p => p.Age.ToString();

                case "name age":
                    return p => $"{p.Name} - {p.Age}";
                default:
                    return null;
            }
        }

        static Func<Person, bool> FilterMethod(int filterAge, string filter)
        {
            switch (filter)
            {
                case "older": return person => person.Age >= filterAge;
                case "younger": return person => person.Age < filterAge;
                default:
                    return null;
            }
        }

        static void PrintPeople(Person[] people, Func<Person, bool> condition, Func<Person, string> formater)
        {
            foreach (var item in people)
            {
                if (condition(item))
                {
                    Console.WriteLine(formater(item));
                }
            }
        }
    }
}