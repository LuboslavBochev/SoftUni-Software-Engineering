using System;

namespace Farm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("Hoot Hoot");

            if(food == "Meat")
            {
                double increasedFood = quantity * AnimalConstants.owlWeight;
                this.Weight += increasedFood;
                this.FoodEaten += quantity;
            }
            else throw new ArgumentException($"Owl does not eat {food}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
