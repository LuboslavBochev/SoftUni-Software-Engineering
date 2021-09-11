using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numInput = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrope = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numInput; i++)
            {
                string[] clothes = Console.ReadLine().Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = clothes[0];

                if (!wardrope.ContainsKey(color))
                {
                    wardrope.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < clothes.Length; j++)
                {
                    if (!wardrope[color].ContainsKey(clothes[j]))
                    {
                        wardrope[color].Add(clothes[j], 0);
                    }
                    wardrope[color][clothes[j]]++;
                }
            }

            string[] toFindElement = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string toFindColor = toFindElement[0];
            string toFindCloth = toFindElement[1];

            foreach (var color in wardrope)
            {
                if (color.Value.Count > 0)
                {
                    Console.WriteLine($"{color.Key} clothes:");

                    foreach (var cloth in color.Value)
                    {
                        if (toFindCloth == cloth.Key && toFindColor == color.Key)
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        }
                        else Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}