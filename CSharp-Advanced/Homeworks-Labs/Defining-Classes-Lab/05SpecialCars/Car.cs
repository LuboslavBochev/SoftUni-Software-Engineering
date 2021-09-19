namespace CarManufacturer
{
    public class Car
    {
        public Car() { }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, int engineIndex, int tireIndex)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TireIndex = tireIndex;
            this.EngineIndex = engineIndex;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public int TireIndex { get; set; }

        public int EngineIndex { get; set; }

        public double Drive(double distance, double fuelConsumption, double fuelQuantity, int horsePower, double sumPressure)
        {
            if (this.Year >= 2017 && horsePower > 330 && sumPressure > 9 && sumPressure < 10)
            {
                double litersBurned = (distance / 100) * fuelConsumption;
                FuelQuantity -= litersBurned;
            }

            return FuelQuantity;
        }
    }
}
