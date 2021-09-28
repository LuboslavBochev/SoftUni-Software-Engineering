using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            Engine = new Engine();
            Cargo = new Cargo();
            Tires = new Tire[4];
        }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight,
            string cargoType, Tire[] tires)
            : this()
        {
            this.Model = model;

            this.Engine.EngineSpeed = engineSpeed;
            this.Engine.EnginePower = enginePower;

            this.Cargo.CargoWeight = cargoWeight;
            this.Cargo.CargoType = cargoType;

            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }
    }
}
