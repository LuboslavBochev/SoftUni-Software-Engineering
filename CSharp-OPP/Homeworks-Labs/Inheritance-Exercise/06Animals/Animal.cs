using System;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != "Female" && value != "Male")
                {
                    throw new ArgumentException("Invalid input!");
                }
                else this.gender = value;
            }
        }

        public virtual string Sound { get; set; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return this.GetType().Name + Environment.NewLine
                + $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine
                + $"{this.ProduceSound()}";
        }
    }
}
