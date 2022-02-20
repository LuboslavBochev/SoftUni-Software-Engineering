using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthday> birthdays = new List<IBirthday>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End") break;

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(tokens[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    birthdays.Add(citizen);
                }
                else if(tokens[0] == "Pet")
                {
                    Pet pet = new Pet(tokens[1], tokens[2]);
                    birthdays.Add(pet);
                }
            }
            string yearToShow = Console.ReadLine();

            birthdays.ForEach(obj =>
            {
                if(obj.Birthday.EndsWith(yearToShow))
                {
                    Console.WriteLine(obj.Birthday);
                }
            });
        }
    }
}
