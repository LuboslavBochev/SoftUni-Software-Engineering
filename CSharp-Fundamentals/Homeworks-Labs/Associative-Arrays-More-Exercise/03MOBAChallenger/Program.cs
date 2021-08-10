using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreEx_Associative_Arr_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> statistic = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "Season end") break;

                string[] tokens = command.Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length > 2)
                {
                    string playerName = tokens[0];
                    string position = tokens[1];
                    int skillPoints = int.Parse(tokens[2]);

                    if (!statistic.ContainsKey(playerName))
                    {
                        statistic.Add(playerName, new Dictionary<string, int>());
                        statistic[playerName].Add(position, skillPoints);
                    }

                    else
                    {
                        if (statistic[playerName].ContainsKey(position)) // update skill points if previous are less than current
                        {
                            int prSkillRate = statistic[playerName][position];

                            if (skillPoints > prSkillRate) statistic[playerName][position] = skillPoints;
                        }

                        else statistic[playerName].Add(position, skillPoints);
                    }
                }

                else
                {
                    string playerOne = tokens[0];
                    string playerTwo = tokens[1];

                    if (statistic.ContainsKey(playerOne) && statistic.ContainsKey(playerTwo))
                    {
                        bool haveSame = false;

                        foreach (var item in statistic[playerOne])
                        {
                            if (statistic[playerTwo].ContainsKey(item.Key))
                            {
                                haveSame = true;
                                break;
                            }
                        }

                        if (haveSame)
                        {
                            int player1Points = statistic[playerOne].Values.Sum();
                            int player2Points = statistic[playerTwo].Values.Sum();

                            if (player1Points > player2Points)
                            {
                                statistic.Remove(playerTwo);
                            }

                            else if (player2Points > player1Points)
                            {
                                statistic.Remove(playerOne);
                            }
                        }
                    }
                }
            }

            foreach (var item in statistic.OrderByDescending(total => total.Value.Values.Sum()).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");

                foreach (var possitions in item.Value.OrderByDescending(skillPoints => skillPoints.Value).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"- {possitions.Key} <::> {possitions.Value}");
                }
            }

        }
    }
}