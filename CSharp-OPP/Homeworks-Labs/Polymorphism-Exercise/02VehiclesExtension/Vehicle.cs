using System;

namespace Vehicle
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if(value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else this.fuelQuantity = value;
            }
        }

        protected double TankCapacity { get; set; }

        protected double LitersPerKm { get; private set; }

        public abstract string Drive(double distance);

        public abstract void Refull(double liters);
    }
}
