using System;

namespace Vehicle
{
    public class Car : Vehicle
    {
        private const double fuelConsumtionPerKm = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + fuelConsumtionPerKm, tankCapacity)
        {

        }

        public override string Drive(double distance)
        {
            double litersNeeds = this.LitersPerKm * distance;

            if (this.FuelQuantity >= litersNeeds)
            {
                this.FuelQuantity -= litersNeeds;
                return $"{GetType().Name} travelled {distance} km";
            }
            else return $"{GetType().Name} needs refueling";
        }

        public override void Refull(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            else if(liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
    }
}
