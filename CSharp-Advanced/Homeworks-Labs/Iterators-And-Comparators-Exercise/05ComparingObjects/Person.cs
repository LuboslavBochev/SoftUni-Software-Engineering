using System;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) == 0 && this.age.CompareTo(other.age) == 0 && this.town.CompareTo(other.town) == 0)
            {
                return 0;
            }
            else return -1;
        }
    }
}
