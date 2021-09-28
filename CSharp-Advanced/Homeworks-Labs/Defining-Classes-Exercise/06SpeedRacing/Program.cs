using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            Action<List<Car>> print = cars => cars.ForEach(car => Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}"));

            for (int i = 0; i < numberCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carDetails[0];
                double fuelAmount = double.Parse(carDetails[1]);
                double fuelPerKm = double.Parse(carDetails[2]);

                Car car = new Car(model, fuelAmount, fuelPerKm);

                cars.Add(car);
            }

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "End") break;

                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Drive")
                {
                    string model = tokens[1];
                    int amountKm = int.Parse(tokens[2]);

                    foreach (var car in cars)
                    {
                        if (car.Model == model)
                        {
                            car.Drive(model, amountKm);
                            break;
                        }
                    }
                }
            }
            print(cars);
        }
    }
}
