using System;

namespace Vehicle
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionPerKm = 1.6;

        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + fuelConsumptionPerKm)
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
            this.FuelQuantity += liters * 0.95;
        }
    }
}
