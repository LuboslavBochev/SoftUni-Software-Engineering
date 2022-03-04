using System;

namespace Farm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("Cluck");
            double increasedFood = quantity * AnimalConstants.henWeight;
            this.Weight += increasedFood;
            this.FoodEaten += quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
