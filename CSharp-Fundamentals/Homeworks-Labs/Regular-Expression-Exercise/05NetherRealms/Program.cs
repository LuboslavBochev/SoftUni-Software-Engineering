using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegularEx_4
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            SortedDictionary<string, Dictionary<int, double>> deamonsBook = new SortedDictionary<string, Dictionary<int, double>>();

            for (int i = 0; i < input.Length; i++)
            {
                string deamonName = input[i];

                int health = GetHealth(deamonName);
                double damage = GetDamage(deamonName);

                if (!deamonsBook.ContainsKey(deamonName))
                {
                    deamonsBook.Add(deamonName, new Dictionary<int, double>());
                    deamonsBook[deamonName].Add(health, damage);
                }
            }

            foreach (var item in deamonsBook)
            {
                Console.Write(item.Key + " - ");
                foreach (var value in item.Value)
                {
                    Console.Write($"{value.Key} health, {value.Value:f2} damage");
                }
                Console.WriteLine();
            }
        }

        static double GetDamage(string deamonName)
        {
            double damage = 0.0;

            string pattern = @"(?<damage>(?:(?:\-|\+*)\d+(?:\.\d*)?|\.\d+))";

            MatchCollection matchedNums = Regex.Matches(deamonName, pattern);

            if (matchedNums.Count > 0)
            {
                foreach (var item in matchedNums)
                {
                    damage += double.Parse(item.ToString());
                }

                pattern = @"(?<alter>[*\/])";

                MatchCollection matchedMulDiv = Regex.Matches(deamonName, pattern);

                if (matchedMulDiv.Count > 0)
                {
                    foreach (var item in matchedMulDiv)
                    {
                        string symbolToAlter = item.ToString();

                        if (symbolToAlter == "*")
                        {
                            damage *= 2;
                        }
                        else
                        {
                            damage /= 2;
                        }
                    }
                }
            }

            return damage;
        }

        static int GetHealth(string deamonName)
        {
            int health = 0;

            string pattern = @"[A-Za-z]*[^\d\.\+\-\*\/\s]+";

            MatchCollection matchedDeamon = Regex.Matches(deamonName, pattern);

            for (int i = 0; i < matchedDeamon.Count; i++)
            {
                if (matchedDeamon[i].Length > 1)
                {
                    char[] toSplitChars = matchedDeamon[i].Value.ToCharArray();

                    for (int j = 0; j < toSplitChars.Length; j++)
                    {
                        health += toSplitChars[j];
                    }
                }

                else health += char.Parse(matchedDeamon[i].Value);
            }

            return health;
        }
    }
}