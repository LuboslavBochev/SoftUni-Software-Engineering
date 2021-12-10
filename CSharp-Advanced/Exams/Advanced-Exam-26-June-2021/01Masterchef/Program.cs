using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExams
{
    public class Ingradient
    {
        public Ingradient(string dishName, int count)
        {
            this.DishName = dishName;
            this.Count = count;
        }

        public string DishName { get; set; }

        public int Count { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Ingradient> meals = new Dictionary<int, Ingradient>();

            meals = FillDict(meals);

            Queue<int> ingradients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (ingradients.Count != 0 && freshnessLevel.Count != 0)
            {
                int ingradient = ingradients.Peek();
                int freshness = freshnessLevel.Peek();

                int totalFreshness = ingradient * freshness;

                if (ingradient == 0)
                {
                    ingradients.Dequeue();
                }

                else if (meals.ContainsKey(totalFreshness))
                {
                    meals[totalFreshness].Count++;

                    ingradients.Dequeue();
                    freshnessLevel.Pop();
                }

                else
                {
                    freshnessLevel.Pop();
                    ingradients.Dequeue();

                    ingradients.Enqueue(ingradient + 5);
                }
            }

            if (!CheckSuccess(meals))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingradients.Count != 0)
                Console.WriteLine($"Ingredients left: {ingradients.Sum()}");

            meals = meals.OrderBy(x => x.Value.DishName).Where(x => x.Value.Count != 0).ToDictionary(key => key.Key, val => val.Value);

            foreach (var meal in meals)
            {
                Console.WriteLine($" # {meal.Value.DishName} --> {meal.Value.Count}");
            }
        }

        public static bool CheckSuccess(Dictionary<int, Ingradient> meals)
        {
            foreach (var meal in meals)
            {
                if (meal.Value.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static Dictionary<int, Ingradient> FillDict(Dictionary<int, Ingradient> meals)
        {
            meals.Add(150, new Ingradient("Dipping sauce", 0));
            meals.Add(250, new Ingradient("Green salad", 0));
            meals.Add(300, new Ingradient("Chocolate cake", 0));
            meals.Add(400, new Ingradient("Lobster", 0));

            return meals;
        }
    }
}