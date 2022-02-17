using System;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

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
            str.AppendLine($"{this.Color} {GetType().Name} {this.Model}");
            str.AppendLine(Start());
            str.AppendLine(Stop());
            return str.ToString().TrimEnd();
        }
    }
}
