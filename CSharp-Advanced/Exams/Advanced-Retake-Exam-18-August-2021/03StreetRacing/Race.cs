using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private Dictionary<string, Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.participants = new Dictionary<string, Car>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count
        {
            get
            {
                return this.participants.Count;
            }
        }

        public void Add(Car car)
        {
            if (!this.participants.ContainsKey(car.LicensePlate))
            {
                if (this.Capacity > 0 && car.HorsePower <= this.MaxHorsePower)
                {
                    this.participants.Add(car.LicensePlate, car);
                    this.Capacity--;
                }
            }
        }

        public bool Remove(string licensePlate)
        {
            if (this.participants.ContainsKey(licensePlate))
            {
                this.participants.Remove(licensePlate);
                this.Capacity++;
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (this.participants.ContainsKey(licensePlate))
            {
                return this.participants[licensePlate];
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.participants.Count != 0)
            {
                return this.participants.OrderByDescending(car => car.Value.HorsePower).First().Value;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var participant in this.participants)
            {
                str.AppendLine(participant.Value.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
