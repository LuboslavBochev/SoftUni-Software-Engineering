using System;
using System.Collections.Generic;

namespace PizzaEncapsulation
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        private double DoughCalories
        {
            get => this.dough.CalculateCalories();
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value == string.Empty || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else this.name = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 0.0;

            calories += this.DoughCalories;
            foreach (var topping in this.toppings)
            {
                calories += topping.CalculateCalories();
            }
            return calories;
        }

        public int GetNumberOfToppings()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if(this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            this.toppings.Add(topping);
        }
    }
}
