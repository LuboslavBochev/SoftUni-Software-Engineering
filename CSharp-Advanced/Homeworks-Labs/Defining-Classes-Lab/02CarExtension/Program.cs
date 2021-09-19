using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "BMW";
            car.Model = "X3";
            car.Year = 2001;

            car.FuelQuantity = 200;
            car.FuelConsumption = 2;

            car.Drive(5);
            car.WhoAmI();
        }
    }
}
