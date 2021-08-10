using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreEx_Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            // Example with nested dictionaries

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (true)
            {

                string inputs = Console.ReadLine();

                if (inputs == "end of contests")
                {
                    break;
                }

                string[] tokens = inputs.Split(":");

                string contest = tokens[0];
                string password = tokens[1];

                contests.Add(contest, password);
            }
            // second part of the task

            Dictionary<string, Dictionary<string, int>> candidateContestsResult = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "end of submissions") break;

                string[] tokens = input.Split("=>");

                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                // check if the contest is valid

                if (contests.ContainsKey(contest) && contests[contest] == password) // if contest exist in contest(the dictionary)
                {
                    if (candidateContestsResult.ContainsKey(username) && candidateContestsResult[username].ContainsKey(contest))
                    {
                        int previousPoint = candidateContestsResult[username][contest]; // get privious points in username in the current contest

                        if (points > previousPoint) // update the points if previous are less than the points
                        {
                            candidateContestsResult[username][contest] = points;
                        }
                    }

                    else // if username doesn't exist
                    {
                        if (!candidateContestsResult.ContainsKey(username))
                        {
                            candidateContestsResult.Add(username, new Dictionary<string, int>());
                        }
                        candidateContestsResult[username].Add(contest, points);
                    }
                }
            }

            string bestUser = string.Empty;
            int bestResult = int.MinValue;

            foreach (var item in candidateContestsResult) // check who is the best user via points
            {
                if (item.Value.Values.Sum() > bestResult)
                {
                    bestResult = item.Value.Values.Sum();
                    bestUser = item.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestResult} points.");


            Console.WriteLine("Ranking: ");
            foreach (var item in candidateContestsResult.OrderBy(name => name.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var contest in item.Value.OrderByDescending(value => value.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}