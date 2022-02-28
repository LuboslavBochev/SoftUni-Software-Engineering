using System;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.favouriteFood = favouriteFood;
        }

        public string Name { get; protected set; }

        public string favouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.favouriteFood}";
        }
    }
}
