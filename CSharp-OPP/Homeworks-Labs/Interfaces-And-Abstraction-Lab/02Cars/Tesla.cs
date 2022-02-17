using System;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery { get => this.battery; set => this.battery = value; }
        public string Model { get => this.model; set => this.model = value; }
        public string Color { get => this.color; set => this.color = value; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries");
            str.AppendLine(Start());
            str.AppendLine(Stop());
            return str.ToString().TrimEnd();
        }
    }
}
