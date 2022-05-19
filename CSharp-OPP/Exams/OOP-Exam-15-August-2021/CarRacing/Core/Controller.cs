using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRacer> racerRepository;
        private IMap map;

        public Controller()
        {
            this.carRepository = new CarRepository();
            this.racerRepository = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            this.carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar car = this.carRepository.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            switch (type)
            {
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            this.racerRepository.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racerRepository.FindBy(racerOneUsername);
            IRacer racerTwo = this.racerRepository.FindBy(racerTwoUsername);

            if (racerOne == null) throw new ArgumentException(ExceptionMessages.RacerCannotBeFound, racerOneUsername);
            if (racerTwo == null) throw new ArgumentException(ExceptionMessages.RacerCannotBeFound, racerTwoUsername);

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            foreach (var racer in this.racerRepository.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                str.AppendLine(racer.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
