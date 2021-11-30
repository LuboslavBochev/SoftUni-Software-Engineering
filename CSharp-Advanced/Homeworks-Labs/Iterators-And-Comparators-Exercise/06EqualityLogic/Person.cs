using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            var result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age - other.age;
            }

            return result;
        }

        public override bool Equals(object otherPerson)
        {
            var other = otherPerson as Person;
            return this.name == other.name && this.age == other.age;
        }

        public override int GetHashCode()
        {
            var hashCode = this.name.Length * 10000;
            hashCode = this.name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.age * 10000;

            return hashCode;
        }
    }
}
