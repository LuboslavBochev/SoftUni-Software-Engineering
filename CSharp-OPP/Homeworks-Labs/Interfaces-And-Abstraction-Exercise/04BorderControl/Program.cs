using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> identifications = new List<IId>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End") break;

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 3)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    identifications.Add(citizen);
                }
                else
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    identifications.Add(robot);
                }
            }
            string fakeIdLastDigits = Console.ReadLine();

            identifications.ForEach(obj =>
            {
                if(obj.Id.EndsWith(fakeIdLastDigits))
                {
                    Console.WriteLine(obj.Id);
                }
            });
        }
    }
}
