﻿namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 1000;
        private const decimal cakePrice = 5;

        public Cake(string name)
            :base(name, 0, 0, 0)
        {

        }

        public override double Grams { get => grams; }

        public override double Calories { get => calories; }

        public override decimal Price { get => cakePrice; }
    }
}
