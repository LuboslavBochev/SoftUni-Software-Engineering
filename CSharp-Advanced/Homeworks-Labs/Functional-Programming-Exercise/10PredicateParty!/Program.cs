using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, string, string, bool> chooseCriteria = ChooseCriteria;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!") break;

                string[] tokens = command.Split(" ");
                string criteria = tokens[1];
                string toCompare = tokens[2];

                if (tokens[0] == "Double")
                {
                    peopleList = DoublePeople(peopleList, criteria, toCompare, chooseCriteria);
                }
                else
                {
                    peopleList = RemovePeople(peopleList, criteria, toCompare, chooseCriteria);
                }
            }
            if (peopleList.Count > 0)
                Console.WriteLine(string.Join(", ", peopleList) + " are going to the party!");

            else Console.WriteLine("Nobody is going to the party!");
        }

        static List<string> RemovePeople(List<string> peopleList, string criteria, string toCompare, Func<string, string, string, bool> chooseCriteria)
        {
            List<string> newList = peopleList.Select(x => x).ToList();

            foreach (var person in newList)
            {
                if (chooseCriteria(criteria, toCompare, person))
                {
                    peopleList.Remove(person);
                }
            }
            return peopleList;
        }

        static List<string> DoublePeople(List<string> peopleList, string criteria, string toCompare, Func<string, string, string, bool> chooseCriteria)
        {
            List<string> newList = peopleList.Select(x => x).ToList();

            foreach (var person in peopleList)
            {
                if (chooseCriteria(criteria, toCompare, person))
                {
                    int personIndex = person.IndexOf(person);
                    if (personIndex == newList.Count - 1)
                    {
                        newList.Add(person);
                    }
                    else newList.Insert(personIndex + 1, person);
                }
            }
            return newList;
        }
        static bool ChooseCriteria(string criteria, string toCompare, string person)
        {
            if (criteria == "StartsWith") return person.StartsWith(toCompare);
            else if (criteria == "EndsWith") return person.EndsWith(toCompare);
            else
            {
                return person.Length == int.Parse(toCompare);
            }
        }
    }
}
