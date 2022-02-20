using System;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        private int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        private string Group
        {
            get => this.group;
            set
            {
                this.group = value;
            }
        }

        public int Food { get => this.food; private set => this.food = value; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
