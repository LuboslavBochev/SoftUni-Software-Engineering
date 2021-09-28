using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine() { }
        public Engine(string model, int enginePower)
        {
            this.Model = model;
            this.EnginePower = enginePower;
        }
        public Engine(string model, int enginePower, int displacement)
            : this(model, enginePower)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int enginePower, string efficiency)
            : this(model, enginePower)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int enginePower, int displacement, string efficiency)
            : this(model, enginePower)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int EnginePower { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"  {Model}:");
            str.AppendLine($"    Power: {EnginePower}");
            str.AppendLine($"    Displacement: {(Displacement == 0 ? "n/a" : Displacement.ToString())}");
            str.AppendLine($"    Efficiency: {(Efficiency == null ? "n/a" : Efficiency.ToString())}");

            return str.ToString();
        }
    }
}
