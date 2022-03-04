using System;

namespace Farm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            :base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
