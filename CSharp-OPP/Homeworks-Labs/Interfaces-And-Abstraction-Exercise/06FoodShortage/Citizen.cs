using System;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;
        private int food;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.birthday = birthday;
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

        private string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }

        private string Birthday
        {
            get => this.birthday;
            set
            {
                this.birthday = value;
            }
        }

        public int Food { get => this.food; private set => this.food = value; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
