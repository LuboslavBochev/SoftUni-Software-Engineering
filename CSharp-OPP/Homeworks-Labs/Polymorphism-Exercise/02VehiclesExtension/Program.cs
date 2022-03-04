using System;

namespace Vehicle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carDetails = Console.ReadLine().Split(" ");
            string[] truckDetails = Console.ReadLine().Split(" ");
            string[] busDetails = Console.ReadLine().Split(" ");

            int numberCommands = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]), double.Parse(carDetails[3]));
            Vehicle truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]), double.Parse(truckDetails[3]));
            Vehicle bus = new Bus(double.Parse(busDetails[1]), double.Parse(busDetails[2]), double.Parse(busDetails[3]));

            for (int i = 0; i < numberCommands; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(" ");

                    string vehicleType = tokens[1];
                    string command = tokens[0];

                    if (vehicleType == nameof(Car))
                    {
                        if (command == "Drive")
                        {
                            Console.WriteLine(car.Drive(double.Parse(tokens[2])));
                        }
                        else
                        {
                            car.Refull(double.Parse(tokens[2]));
                        }
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        if (command == "Drive")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(tokens[2])));
                        }
                        else
                        {
                            truck.Refull(double.Parse(tokens[2]));
                        }
                    }
                    else
                    {
                        if (command == "Drive")
                        {
                            Console.WriteLine(bus.Drive(double.Parse(tokens[2])));
                        }
                        else if (command == "DriveEmpty")
                        {
                            Console.WriteLine(((Bus)bus).DriveEmpty(double.Parse(tokens[2])));
                        }
                        else
                        {
                            bus.Refull(double.Parse(tokens[2]));
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
