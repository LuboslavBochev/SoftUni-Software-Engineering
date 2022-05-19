using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            if (!racerOne.IsAvailable()) return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            if (!racerTwo.IsAvailable()) return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            racerOne.Race();
            racerTwo.Race();

            double racingBehaviorMultiplierRacerOne = this.GetRacingMultiplier(racerOne);
            double racingBehaviorMultiplierRacerTwo = this.GetRacingMultiplier(racerTwo);

            return this.CheckWinner(racerOne, racerTwo, racingBehaviorMultiplierRacerOne, racingBehaviorMultiplierRacerTwo);
        }

        private string CheckWinner(IRacer racerOne, IRacer racerTwo, double racingBehaviorMultiplierRacerOne, double racingBehaviorMultiplierRacerTwo)
        {
            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierRacerOne;
            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierRacerTwo;

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }

        private double GetRacingMultiplier(IRacer racer)
        {
            switch (racer.RacingBehavior)
            {
                case "strict":
                    return 1.2;

                case "aggressive":
                    return 1.1;
            }
            return 0;
        }
    }
}
