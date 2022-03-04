using System;

namespace Farm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
        {

        }

        public override void ProduceSound(string food, int quantity)
        {
            Console.WriteLine("Squeak");
            if(food == "Vegetable" || food == "Fruit")
            {
                double increasedFood = quantity * AnimalConstants.mouseWeight;
                this.Weight += increasedFood;
                this.FoodEaten += quantity;
            }
            else throw new ArgumentException($"Mouse does not eat {food}!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} " + base.ToString();
        }
    }
}
