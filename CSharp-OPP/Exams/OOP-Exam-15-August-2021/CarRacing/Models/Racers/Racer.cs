using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int driverExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.driverExperience;
            protected set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.driverExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                if(value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }
        }

        public virtual void Race()
        {
            this.car.Drive();
        }

        public bool IsAvailable()
        {
            double reducedFuel = this.car.FuelAvailable - this.car.FuelConsumptionPerRace;

            if(reducedFuel < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.GetType().Name}: {this.Username}");
            str.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            str.AppendLine($"--Driving experience: {this.DrivingExperience}");
            str.AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");

            return str.ToString().TrimEnd();
        }
    }
}
