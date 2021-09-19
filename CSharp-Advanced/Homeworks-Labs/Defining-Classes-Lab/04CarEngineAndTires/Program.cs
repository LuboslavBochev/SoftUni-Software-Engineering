using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
               new Tire(2001, 2.3),
               new Tire(2002, 2.5),
               new Tire(2003, 2),
               new Tire(2004, 2.2),
            };

            var engine = new Engine(500, 3000);

            var car = new Car("BMW", "X5", 2001, 250, 1, engine, tires);
        }
    }
}
