using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Bmw";
            car.Model = "X5";
            car.Year = 2002;

            Console.WriteLine(car.Make + car.Model + car.Year);
        }
    }
}
