using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
            }
        }

        public bool TookPlace
        {
            get => this.tookPlace;
            set => this.tookPlace = value;
        }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder str = new StringBuilder();

            string tookPlace = this.tookPlace ? "Yes" : "No";

            str.AppendLine($"The {this.RaceName} race has:");
            str.AppendLine($"Participants: {this.pilots.Count}");
            str.AppendLine($"Number of laps: {this.NumberOfLaps}");
            str.AppendLine($"Took place: {tookPlace}");

            return str.ToString().TrimEnd();
        }
    }
}
