using System;

namespace PizzaEncapsulation
{
    public class Topping
    {
        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var type = value.ToLower();
                if (type != "meat" && type != "veggies" && type != "cheese" && type != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [1..50].");
                }
                else this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double modifier = 0;

            var type = this.name.ToLower();

            if (type == "meat")
            {
                modifier = 1.2;
            }
            if (type == "veggies")
            {
                modifier = 0.8;
            }
            if (type == "cheese")
            {
                modifier = 1.1;
            }
            if (type == "sauce")
            {
                modifier = 0.9;
            }
            return 2 * modifier * this.Weight;
        }
    }
}
