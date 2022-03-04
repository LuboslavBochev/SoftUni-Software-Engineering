using System;

namespace Vehicle
{
    public class Car : Vehicle
    {
        private const double fuelConsumtionPerKm = 0.9;

        public Car(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + fuelConsumtionPerKm)
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
            this.FuelQuantity += liters;
        }
    }
}
