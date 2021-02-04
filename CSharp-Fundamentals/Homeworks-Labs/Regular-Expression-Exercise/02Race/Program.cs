using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Regular_More_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> participants = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> racersInfo = new Dictionary<string, int>();

            string namePatern = @"([A-Z]|[a-z])";
            string distancePatern = @"\d";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race") break;

                MatchCollection matchedNames = Regex.Matches(input, namePatern);
                MatchCollection matchedDistance = Regex.Matches(input, distancePatern);

                string name = string.Join("", matchedNames);
                int totalDistance = GetDistance(matchedDistance);

                if (participants.Contains(name))
                {
                    if (!racersInfo.ContainsKey(name))
                    {
                        racersInfo.Add(name, totalDistance);
                    }
                    else
                    {
                        racersInfo[name] += totalDistance;
                    }
                }
            }

            int count = 1;
            foreach (var item in racersInfo.OrderByDescending(distance => distance.Value).Take(3))
            {
                string place = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                Console.WriteLine($"{count}{place} place: {item.Key}");
                count++;
            }
        }

        static int GetDistance(MatchCollection matchedDistance)
        {
            int distance = 0;

            foreach (Match item in matchedDistance)
            {
                distance += int.Parse(item.Value.ToString());
            }
            return distance;
        }
    }
}