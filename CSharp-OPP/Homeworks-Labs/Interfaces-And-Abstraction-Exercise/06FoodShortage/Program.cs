using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberPeople; i++)
            {
                string[] details = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = details[0];
                int age = int.Parse(details[1]);

                if (details.Length == 4)
                {
                    Citizen citizen = new Citizen(name, age, details[2], details[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(name, age, details[2]);
                    buyers.Add(rebel);
                }
            }

            int totalFood = 0;

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End") break;

                IBuyer buyer = buyers.Find(buyer => buyer.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            totalFood = buyers.Sum(buyer => buyer.Food);
            Console.WriteLine(totalFood);
        }
    }
}
