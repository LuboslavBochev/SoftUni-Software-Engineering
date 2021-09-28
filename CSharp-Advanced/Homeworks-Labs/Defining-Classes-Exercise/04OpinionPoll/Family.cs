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

        public List<Person> AboveThirty(List<Person> people)
        {
            return people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
        }
    }
}
