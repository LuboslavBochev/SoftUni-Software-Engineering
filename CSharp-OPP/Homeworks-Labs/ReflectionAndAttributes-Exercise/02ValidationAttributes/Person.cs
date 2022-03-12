using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int minValue = 12;
        private const int maxValue = 90;

        public Person(string fullName, int age)
        {
            this.Name = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; private set; }

        [MyRange(minValue, maxValue)]
        public int Age { get; private set; }
    }
}
