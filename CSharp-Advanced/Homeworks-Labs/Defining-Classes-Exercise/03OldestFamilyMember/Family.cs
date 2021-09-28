using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> people { get; set; }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public void GetOldestMember(List<Person> people)
        {
            Person oldestPerson = people.OrderByDescending(p => p.Age).First();
           
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
