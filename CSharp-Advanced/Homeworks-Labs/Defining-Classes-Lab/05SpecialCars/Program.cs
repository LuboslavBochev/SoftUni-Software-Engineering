using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            List<List<Tire>> tires = new List<List<Tire>>();
            List<List<Engine>> engines = new List<List<Engine>>();

            Func<List<Tire>, double> mySum = list =>
            {
                double sum = 0;
                foreach (var item in list)
                {
                    sum += item.Pressure;
                }
                return sum;
            };

            while (true) // Tires
            {
                string command = Console.ReadLine();

                if (command == "No more tires") break;

                tires = GetTires(command, tires);
            }

            while (true) // Engines
            {
                string command = Console.ReadLine();

                if (command == "Engines done") break;

                engines = GetEngines(command, engines);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special") break;

                string[] carDetails = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carDetails[0];
                string model = carDetails[1];
                int year = int.Parse(carDetails[2]);
                double fuelQuantity = double.Parse(carDetails[3]);
                double fuelConsumption = double.Parse(carDetails[4]);
                int engineIndex = int.Parse(carDetails[5]);
                int tireIndex = int.Parse(carDetails[6]);

                Car specialCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tireIndex);

                cars.Add(specialCar);
            }

            foreach (var item in cars)
            {
                int horsePower = engines[item.EngineIndex][0].HorsePower;

                double pressureSum = mySum(tires[item.TireIndex]);

                bool showCar = item.Year >= 2017 && horsePower > 330 && pressureSum > 9 && pressureSum < 10;

                if (showCar)
                {
                    Console.WriteLine("Make: " + item.Make);
                    Console.WriteLine("Model: " + item.Model);
                    Console.WriteLine("Year: " + item.Year);
                    Console.WriteLine("HorsePowers: " + horsePower);
                    Console.WriteLine("FuelQuantity: " + item.Drive(20, item.FuelConsumption, item.FuelQuantity, horsePower, pressureSum));
                }
            }
        }
        static List<List<Tire>> GetTires(string command, List<List<Tire>> tires)
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Tire> allTires = new List<Tire>();

            for (int i = 0; i < tokens.Length; i += 2)
            {
                Tire tire = new Tire();

                tire.Year = int.Parse(tokens[i]);
                tire.Pressure = double.Parse(tokens[i + 1]);
                allTires.Add(tire);
            }
            tires.Add(allTires);

            return tires;
        }
        static List<List<Engine>> GetEngines(string command, List<List<Engine>> engines)
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Engine> allEngines = new List<Engine>();

            for (int i = 0; i < tokens.Length; i += 2)
            {
                Engine engine = new Engine();

                engine.HorsePower = int.Parse(tokens[i]);
                engine.CubicCapacity = double.Parse(tokens[i + 1]);
                allEngines.Add(engine);
            }
            engines.Add(allEngines);

            return engines;
        }
    }
}
