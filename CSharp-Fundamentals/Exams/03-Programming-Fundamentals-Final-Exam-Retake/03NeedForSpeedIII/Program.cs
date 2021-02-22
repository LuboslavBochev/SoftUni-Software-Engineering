using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam_More
{
    class Program
    {
        static void Main(string[] args)
        {

            int numCars = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < numCars; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                string name = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                if (!cars.ContainsKey(name))
                {
                    cars.Add(name, new List<int>() { mileage, fuel });
                }
            }

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Stop") break;

                string[] tokens = commands.Split(" : ");

                string command = tokens[0];
                string carName = tokens[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (cars[carName][1] >= fuel)
                    {
                        cars[carName][0] += distance;
                        cars[carName][1] -= fuel;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[carName][0] >= 100000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }

                else if (command == "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);
                    int dif = 75 - fuel;

                    cars[carName][1] += fuel;

                    if (cars[carName][1] >= 75)
                    {
                        cars[carName][1] = 75;

                        Console.WriteLine($"{carName} refueled with {dif} liters");
                    }
                    else Console.WriteLine($"{carName} refueled with {fuel} liters");
                }

                else
                {
                    int kilometers = int.Parse(tokens[2]);

                    cars[carName][0] -= kilometers;

                    if (cars[carName][0] < 10000)
                    {
                        cars[carName][0] = 10000;
                    }
                    else Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                }
            }

            foreach (var item in cars.OrderByDescending(mileage => mileage.Value[0]).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}