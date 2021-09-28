using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carDetails[0];

                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);

                int cargoWeight = int.Parse(carDetails[3]);
                string cargoType = carDetails[4];

                Tire[] tires = new Tire[4];

                double tire1Pressure = double.Parse(carDetails[5]);
                int tire1Age = int.Parse(carDetails[6]);

                double tire2Pressure = double.Parse(carDetails[7]);
                int tire2Age = int.Parse(carDetails[8]);

                double tire3Pressure = double.Parse(carDetails[9]);
                int tire3Age = int.Parse(carDetails[10]);

                double tire4Pressure = double.Parse(carDetails[11]);
                int tire4Age = int.Parse(carDetails[12]);

                tires[0] = new Tire();
                tires[0].TirePressure = tire1Pressure;
                tires[0].TireAge = tire1Age;

                tires[1] = new Tire();
                tires[1].TirePressure = tire2Pressure;
                tires[1].TireAge = tire2Age;

                tires[2] = new Tire();
                tires[2].TirePressure = tire3Pressure;
                tires[2].TireAge = tire3Age;

                tires[3] = new Tire();
                tires[3].TirePressure = tire4Pressure;
                tires[3].TireAge = tire4Age;

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires);

                cars.Add(car);
            }
            string type = Console.ReadLine();

            foreach (var car in cars)
            {
                if (type == "fragile")
                {
                    if (car.Cargo.CargoType == type)
                    {
                        foreach (var tire in car.Tires)
                        {
                            if (tire.TirePressure < 1)
                            {
                                Console.WriteLine(car.Model);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (car.Cargo.CargoType == type && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
