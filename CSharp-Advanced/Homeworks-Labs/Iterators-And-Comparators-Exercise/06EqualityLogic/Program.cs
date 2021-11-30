using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedsetPeople = new SortedSet<Person>();
            HashSet<Person> hashsetPeople = new HashSet<Person>();

            int personNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < personNumber; i++)
            {
                string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(values[0], int.Parse(values[1]));

                sortedsetPeople.Add(person);
                hashsetPeople.Add(person);
            }
            Console.WriteLine(sortedsetPeople.Count);
            Console.WriteLine(hashsetPeople.Count);
        }
    }
}
