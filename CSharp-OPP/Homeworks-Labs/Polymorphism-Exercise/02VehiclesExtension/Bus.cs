using System;

namespace Vehicle
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionPerKm = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {

        }

        public override string Drive(double distance)
        {
            double litersNeeded = (this.LitersPerKm + fuelConsumptionPerKm) * distance;

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
            this.FuelQuantity += liters;
        }

        public string DriveEmpty(double distance)
        {
            double litersNeeded = this.LitersPerKm * distance;

            if (this.FuelQuantity >= litersNeeded)
            {
                this.FuelQuantity -= litersNeeded;
                return $"{GetType().Name} travelled {distance} km";
            }
            else return $"{GetType().Name} needs refueling";
        }
    }
}
