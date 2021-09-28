using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numEngines; i++)
            {
                int enginePower = 0;
                string engineModel = string.Empty;
                int displacement = 0;
                string efficiency = string.Empty;

                string[] engineDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (engineDetails.Length == 3)
                {
                    engineModel = engineDetails[0];
                    enginePower = int.Parse(engineDetails[1]);
                    try
                    {
                        displacement = int.Parse(engineDetails[2]);
                        engines.Add(new Engine(engineModel, enginePower, displacement));
                    }
                    catch (SystemException)
                    {
                        efficiency = engineDetails[2];
                        engines.Add(new Engine(engineModel, enginePower, efficiency));
                    }
                }
                else if (engineDetails.Length == 4)
                {
                    engineModel = engineDetails[0];
                    enginePower = int.Parse(engineDetails[1]);
                    displacement = int.Parse(engineDetails[2]);
                    efficiency = engineDetails[3];

                    engines.Add(new Engine(engineModel, enginePower, displacement, efficiency));
                }
                else
                {
                    engineModel = engineDetails[0];
                    enginePower = int.Parse(engineDetails[1]);

                    engines.Add(new Engine(engineModel, enginePower));
                }
            }

            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carDetails[0];
                string engineModel = carDetails[1];

                Engine engine = GetEngine(engines, engineModel);

                if (carDetails.Length == 3)
                {
                    try
                    {
                        int weight = int.Parse(carDetails[2]);
                        cars.Add(new Car(carModel, engine, weight));
                    }
                    catch (SystemException)
                    {
                        string color = carDetails[2];
                        cars.Add(new Car(carModel, engine, color));
                    }
                }
                else if (carDetails.Length == 4)
                {
                    int weight = int.Parse(carDetails[2]);
                    string color = carDetails[3];

                    cars.Add(new Car(carModel, engine, weight, color));
                }
                else
                {
                    carModel = carDetails[0];
                    engineModel = carDetails[1];

                    cars.Add(new Car(carModel, engine));
                }
            }
            cars.ForEach(Console.WriteLine);
        }

        static Engine GetEngine(List<Engine> engines, string engineModel)
        {
            Engine newEngine = new Engine();

            foreach (var engine in engines)
            {
                if (engine.Model == engineModel)
                {
                    newEngine.Model = engine.Model;
                    newEngine.EnginePower = engine.EnginePower;
                    newEngine.Efficiency = engine.Efficiency;
                    newEngine.Displacement = engine.Displacement;
                    break;
                }
            }
            return newEngine;
        }
    }
}
