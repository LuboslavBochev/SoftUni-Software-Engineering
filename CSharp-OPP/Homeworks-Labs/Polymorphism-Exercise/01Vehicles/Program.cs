using System;

namespace Vehicle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carDetails = Console.ReadLine().Split(" ");
            string[] truckDetails = Console.ReadLine().Split(" ");

            int numberCommands = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]));
            Vehicle truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]));

            for (int i = 0; i < numberCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");

                string command = tokens[0];
                string vehicleType = tokens[1];

                if(vehicleType == nameof(Car))
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
                else
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
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
