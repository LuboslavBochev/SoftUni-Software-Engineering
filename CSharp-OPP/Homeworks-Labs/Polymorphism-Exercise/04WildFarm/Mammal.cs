using System;

namespace Farm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion)
            :base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
