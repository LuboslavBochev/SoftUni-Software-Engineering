using System;

namespace Farm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("Meow");
            if (food == "Vegetable" || food == "Meat")
            {
                double increasedFood = quantity * AnimalConstants.catWeight;
                this.Weight += increasedFood;
                this.FoodEaten += quantity;
            }
            else throw new ArgumentException($"Cat does not eat {food}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
