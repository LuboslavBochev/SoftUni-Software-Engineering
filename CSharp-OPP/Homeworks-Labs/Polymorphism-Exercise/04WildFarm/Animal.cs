using System;

namespace Farm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        protected string Name { get; private set; }

        protected double Weight { get; set; }

        protected int FoodEaten { get; set; }

        public abstract void ProduceSound(string food, int quantity);
    }
}
