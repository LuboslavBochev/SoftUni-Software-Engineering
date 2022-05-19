namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double fuelAvailable = 80;
        private const double fuelConsuptionPerRace = 10;

        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, fuelAvailable, fuelConsuptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
        }
    }
}
