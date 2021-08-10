using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreEx_Associative_Arr_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> contestStatistics = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "no more time") break;

                string[] tokens = input.Split(" -> ");

                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contestStatistics.ContainsKey(contest)) // check if there is already this contest added
                {
                    contestStatistics.Add(contest, new Dictionary<string, int>());
                    contestStatistics[contest].Add(username, points);
                }

                if (!contestStatistics[contest].ContainsKey(username))
                {
                    contestStatistics[contest].Add(username, points);
                }

                else
                {
                    int previousPoint = contestStatistics[contest][username];

                    if (points > previousPoint) contestStatistics[contest][username] = points;
                }
            }

            int possition = 1;
            foreach (var contest in contestStatistics)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                foreach (var participant in contest.Value.OrderByDescending(points => points.Value).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"{possition}. {participant.Key} <::> {participant.Value}");
                    possition++;
                }
                possition = 1;
            }

            Dictionary<string, int> individualStatic = new Dictionary<string, int>();

            foreach (var item in contestStatistics)
            {
                foreach (var partic in item.Value)
                {
                    if (individualStatic.ContainsKey(partic.Key))
                    {
                        individualStatic[partic.Key] += partic.Value;
                    }

                    else individualStatic.Add(partic.Key, partic.Value);
                }
            }

            Console.WriteLine("Individual standings:");
            possition = 1;

            foreach (var item in individualStatic.OrderByDescending(value => value.Value).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{possition}. {item.Key} -> {item.Value}");
                possition++;
            }
        }
    }
}