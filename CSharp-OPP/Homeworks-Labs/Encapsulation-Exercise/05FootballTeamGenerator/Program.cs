using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Team> teams = new List<Team>();

            //while (true)
            //{
            //    try
            //    {
            //        string[] commands = Console.ReadLine().Split(";");

            //        string command = commands[0];

            //        if (command == "END") break;

            //        if (command == "Team")
            //        {
            //            Team team = new Team(commands[1]);
            //            teams.Add(team);
            //        }
            //        else if (command == "Add")
            //        {
            //            string teamName = commands[1];

            //            if (!teams.Exists(team => team.TeamName == teamName))
            //            {
            //                Console.WriteLine($"Team {teamName} does not exist.");
            //                continue;
            //            }

            //            string playerName = commands[2];
            //            int endurance = int.Parse(commands[3]);
            //            int sprint = int.Parse(commands[4]);
            //            int dribble = int.Parse(commands[5]);
            //            int passing = int.Parse(commands[6]);
            //            int shooting = int.Parse(commands[7]);

            //            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            //            foreach (var team in teams)
            //            {
            //                if (team.TeamName == teamName)
            //                {
            //                    team.AddPlayer(player);
            //                    break;
            //                }
            //            }
            //        }
            //        else if (command == "Remove")
            //        {
            //            string teamName = commands[1];

            //            if (!teams.Exists(team => team.TeamName == teamName))
            //            {
            //                Console.WriteLine($"Team {teamName} does not exist.");
            //                continue;
            //            }

            //            string playerName = commands[2];

            //            teams.ForEach(team =>
            //            {
            //                if (team.TeamName == teamName)
            //                {
            //                    team.RemovePlayer(playerName);
            //                }
            //            });
            //        }
            //        else if (command == "Rating")
            //        {
            //            string teamName = commands[1];

            //            if (!teams.Exists(team => team.TeamName == teamName))
            //            {
            //                Console.WriteLine($"Team {teamName} does not exist.");
            //                continue;
            //            }

            //            foreach (var team in teams)
            //            {
            //                if (team.TeamName == teamName)
            //                {
            //                    Console.WriteLine($"{team.TeamName} - {team.Rating}");
            //                }
            //            }
            //        }
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}
