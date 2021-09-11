using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestCredentials = new Dictionary<string, string>();

            string inputContests = Console.ReadLine();

            while (inputContests != "end of contests")
            {
                string[] contestAndPass = inputContests.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = contestAndPass[0];
                string password = contestAndPass[1];

                if (!password.Contains(":") && !password.Contains("=") && !password.Contains(">"))
                {
                    contestCredentials.Add(contest, password);
                }

                inputContests = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> userContestRanking = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions") break;

                string[] elements = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = elements[0];
                string password = elements[1];

                if (contestCredentials.ContainsKey(contest) && contestCredentials[contest] == password)
                {
                    string userName = elements[2];
                    int points = int.Parse(elements[3]);

                    if (!userContestRanking.ContainsKey(userName))
                    {
                        userContestRanking.Add(userName, new Dictionary<string, int>());
                    }

                    if (!userContestRanking[userName].ContainsKey(contest))
                    {
                        userContestRanking[userName].Add(contest, 0);
                    }

                    if (userContestRanking[userName][contest] < points)
                    {
                        userContestRanking[userName][contest] = points;
                    }
                }
            }

            KeyValuePair<string, Dictionary<string, int>> bestCandidate = userContestRanking.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();

            int bestScore = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestScore} points.");
            Console.WriteLine("Ranking: ");

            foreach (var student in userContestRanking.OrderBy(name => name.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var result in student.Value.OrderByDescending(points => points.Value))
                {
                    Console.WriteLine($"#  {result.Key} -> {result.Value}");
                }
            }
        }
    }
}