using System;

namespace Vehicle
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionPerKm = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override string Drive(double distance)
        {
            double litersNeeded = this.LitersPerKm * distance;

            if (this.FuelQuantity >= litersNeeded)
            {
                this.FuelQuantity -= litersNeeded;
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
            else if (liters + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters * 0.95;
        }
    }
}
