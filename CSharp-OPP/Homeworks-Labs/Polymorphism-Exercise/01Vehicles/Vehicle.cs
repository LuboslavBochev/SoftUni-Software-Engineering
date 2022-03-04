using System;

namespace Vehicle
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
        }

        public double FuelQuantity { get; protected set; }

        protected double LitersPerKm { get; private set; }

        public abstract string Drive(double distance);

        public abstract void Refull(double liters);
    }
}
