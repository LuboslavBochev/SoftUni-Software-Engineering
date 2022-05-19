using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double fuelAvailable = 65;
        private const double fuelConsuptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, fuelAvailable, fuelConsuptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
        }
    }
}
