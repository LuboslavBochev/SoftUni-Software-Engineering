using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();

            int year = int.Parse(Console.ReadLine());
            double quantity = double.Parse(Console.ReadLine());
            double consumption = double.Parse(Console.ReadLine());

            Car car = new Car();
            Car car2 = new Car(make, model, year);
            Car car3 = new Car(make, model, year, quantity, consumption);
        }
    }
}
