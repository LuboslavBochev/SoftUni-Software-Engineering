using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (input != "Statistics")
            {
                string[] vloggersData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = vloggersData[0];
                string command = vloggersData[1];

                if (command == "joined" || command == "followed")
                {
                    if (command == "joined")
                    {
                        if (!vloggers.ContainsKey(vloggerName))
                        {
                            vloggers.Add(vloggerName, new Dictionary<string, SortedSet<string>>());

                            vloggers[vloggerName].Add("followed", new SortedSet<string>());
                            vloggers[vloggerName].Add("following", new SortedSet<string>());
                        }
                    }
                    else
                    {
                        string secondVlogger = vloggersData[2];

                        if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(secondVlogger))
                        {
                            if (vloggerName != secondVlogger)
                            {
                                vloggers[vloggerName]["following"].Add(secondVlogger);

                                vloggers[secondVlogger]["followed"].Add(vloggerName);
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            int counter = 0;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedData = vloggers.OrderByDescending(followed => followed.Value["followed"].Count).ThenBy(following => following.Value["following"].Count).ToDictionary(k => k.Key, v => v.Value);

            foreach (var vlogger in sortedData)
            {
                int followedCount = vlogger.Value["followed"].Count;
                int followingCount = vlogger.Value["following"].Count;

                Console.WriteLine($"{++counter}. {vlogger.Key} : {followedCount} followers, {followingCount} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followed"].OrderBy(name => name))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}