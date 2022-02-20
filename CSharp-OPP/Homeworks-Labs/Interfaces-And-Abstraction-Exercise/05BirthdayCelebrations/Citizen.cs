using System;

namespace BorderControl
{
    public class Citizen : IId, IBirthday
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

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

        public int Age
        {
            get => this.age;
            private set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                this.id = value;
            }
        }

        public string Birthday
        {
            get => this.birthday;
            private set
            {
                this.birthday = value;
            }
        }
    }
}
