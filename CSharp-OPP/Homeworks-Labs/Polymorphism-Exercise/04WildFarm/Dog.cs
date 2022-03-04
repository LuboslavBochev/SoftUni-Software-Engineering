using System;

namespace Farm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("Woof!");
            if (food == "Meat")
            {
                double increasedFood = quantity * AnimalConstants.dogWeight;
                this.Weight += increasedFood;
                this.FoodEaten += quantity;
            }
            else throw new ArgumentException($"Dog does not eat {food}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
