using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END") break;

                Person person = new Person(input[0], int.Parse(input[1]), input[2]);

                people.Add(person);
            }

            int currentPersonPosition = int.Parse(Console.ReadLine()) - 1;

            Person chosenPerson = people[currentPersonPosition];

            people.RemoveAt(currentPersonPosition);

            if (people.All(person => person.CompareTo(chosenPerson) < 0))
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int equalPeople = 1;
                int notEqual = 0;

                foreach (var person in people)
                {
                    if (person.CompareTo(chosenPerson) == 0)
                    {
                        equalPeople++;
                    }
                    else notEqual++;
                }
                Console.WriteLine($"{equalPeople} {notEqual} {people.Count + 1}");
            }
        }
    }
}
