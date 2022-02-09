using System;

namespace PizzaEncapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] detailsDough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (pizzaName.Length == 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                Dough dough = new Dough(detailsDough[1], detailsDough[2], int.Parse(detailsDough[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);

                while (true)
                {
                    string[] detailsTopping = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (detailsTopping[0] == "END") break;

                    Topping topping = new Topping(detailsTopping[1], int.Parse(detailsTopping[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
