using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> foods = new Dictionary<string, int>();

            AddFoods(foods);

            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int liquidValue = liquids.Peek();
                int ingredientValue = ingredients.Peek();
                int mixingValues = liquidValue + ingredientValue;

                if (CheckFoodTable(mixingValues, foods))
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    ingredients.Push(ingredientValue + 3);
                }
            }
            if (foods.All(food => food.Value != 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(string.Join(", ", liquids));
            }

            if (ingredients.Count == 0) Console.WriteLine("Ingredients left: none");
            else
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", ingredients));
            }
            foreach (var food in foods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }

        private static bool CheckFoodTable(int mixingValues, Dictionary<string, int> foods)
        {
            bool isThere = true;

            if (mixingValues == 25)
            {
                foods["Bread"]++;
            }
            else if (mixingValues == 50)
            {
                foods["Cake"]++;
            }
            else if (mixingValues == 75)
            {
                foods["Pastry"]++;
            }
            else if (mixingValues == 100)
            {
                foods["Fruit Pie"]++;
            }
            else // none of these
            {
                return !isThere;
            }
            return isThere;
        }

        private static void AddFoods(Dictionary<string, int> foods)
        {
            foods.Add("Bread", 0);
            foods.Add("Cake", 0);
            foods.Add("Fruit Pie", 0);
            foods.Add("Pastry", 0);
        }
    }
}