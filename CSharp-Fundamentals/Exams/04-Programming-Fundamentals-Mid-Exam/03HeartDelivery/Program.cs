using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> initialnums = Console.ReadLine().Split("@").Select(int.Parse).ToList();


            string commands = string.Empty;
            int currentIndex = 0;

            while ((commands = Console.ReadLine()) != "Love!")
            {

                string[] tokens = commands.Split(" ");

                string command = tokens[0];
                int lenght = int.Parse(tokens[1]);

                if (currentIndex + lenght >= initialnums.Count)
                {
                    currentIndex = 0;
                    lenght = 0;
                }

                if (command == "Jump")
                {

                    if (initialnums[currentIndex + lenght] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex + lenght} already had Valentine's day.");

                        currentIndex += lenght;
                        continue;
                    }

                    initialnums[currentIndex + lenght] -= 2;

                    if (initialnums[currentIndex + lenght] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex + lenght} has Valentine's day.");
                    }

                    currentIndex += lenght;
                }
            }

            bool successful = true;

            int countHouses = 0;

            for (int i = 0; i < initialnums.Count; i++)
            {
                if (initialnums[i] != 0)
                {
                    successful = false;
                    countHouses++;
                }
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            if (successful)
            {
                Console.WriteLine("Mission was successful.");
            }

            else
            {
                Console.WriteLine($"Cupid has failed {countHouses} places.");
            }
        }
    }
}