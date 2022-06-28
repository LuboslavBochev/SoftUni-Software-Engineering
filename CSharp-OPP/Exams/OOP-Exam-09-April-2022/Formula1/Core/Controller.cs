using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly FormulaOneCarRepository carRepository;
        private readonly RaceRepository raceRepository;
        private readonly PilotRepository pilotRepository;

        public Controller()
        {
            this.carRepository = new FormulaOneCarRepository();
            this.raceRepository = new RaceRepository();
            this.pilotRepository = new PilotRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);

            if(pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar formulaOneCar = this.carRepository.FindByName(carModel);

            if(formulaOneCar == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(formulaOneCar);
            this.carRepository.Remove(formulaOneCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, formulaOneCar.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);

            if(pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(this.carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            IFormulaOneCar formulaOneCar;

            switch (type)
            {
                case "Ferrari":
                    formulaOneCar = new Ferrari(model, horsepower, engineDisplacement);
                    break;

                case "Williams":
                    formulaOneCar = new Williams(model, horsepower, engineDisplacement);
                    break;

                default:
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            this.carRepository.Add(formulaOneCar);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if(this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            this.pilotRepository.Add(new Pilot(fullName));

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            this.raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder str = new StringBuilder();

            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                str.AppendLine(pilot.ToString());
            }
            return str.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder str = new StringBuilder();

            foreach (var race in this.raceRepository.Models.Where(r => r.TookPlace))
            {
                str.AppendLine(race.RaceInfo());
            }
            return str.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            List<IPilot> sortedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            if(sortedPilots.Count < 3) throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            
            if(race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            IPilot firstPilot = sortedPilots[0];
            IPilot secondPilot = sortedPilots[1];
            IPilot thirdPilot = sortedPilots[2];

            firstPilot.WinRace();

            StringBuilder str = new StringBuilder();

            str.AppendLine($"Pilot {firstPilot.FullName} wins the {race.RaceName} race.");
            str.AppendLine($"Pilot {secondPilot.FullName} is second in the {race.RaceName} race.");
            str.AppendLine($"Pilot {thirdPilot.FullName} is third in the {race.RaceName} race.");

            return str.ToString().TrimEnd();
        }
    }
}
