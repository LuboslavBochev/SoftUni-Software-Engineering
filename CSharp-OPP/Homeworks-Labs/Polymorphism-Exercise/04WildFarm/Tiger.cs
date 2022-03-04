using System;

namespace Farm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("ROAR!!!");
            if (food == "Meat")
            {
                double increasedFood = quantity * AnimalConstants.tigerWeight;
                this.Weight += increasedFood;
                this.FoodEaten += quantity;
            }
            else throw new ArgumentException($"Tiger does not eat {food}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
