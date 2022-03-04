using System;

namespace Farm
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
