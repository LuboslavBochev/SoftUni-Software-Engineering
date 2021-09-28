using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConPerKm;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(string carModel, int amountKm)
        {
            double fuelAmountAfterDrive = this.FuelAmount - (amountKm * this.FuelConsumptionPerKilometer);

            if(fuelAmountAfterDrive >= 0)
            {
                FuelAmount -= amountKm * this.FuelConsumptionPerKilometer;
                TravelledDistance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
