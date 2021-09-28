using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);

                family.AddMember(new Person(name, age));
            }
            family.people = family.AboveThirty(family.people);

            family.people.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
