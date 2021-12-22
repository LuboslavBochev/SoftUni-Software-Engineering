using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.racers.Count; }

        public void Add(Racer racer)
        {
            if (this.Capacity > 0)
            {
                this.racers.Add(racer);
                this.Capacity--;
            }
        }

        public bool Remove(string name)
        {
            Racer racer = this.racers.Find(racer => racer.Name == name);

            if (racer != null)
            {
                this.racers.Remove(racer);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return this.racers.OrderByDescending(racer => racer.Age).First();
        }

        public Racer GetRacer(string name)
        {
            Racer racer = this.racers.Find(racer => racer.Name == name);

            if (racer != null)
            {
                return racer;
            }
            return null;
        }

        public Racer GetFastestRacer()
        {
            return this.racers.OrderByDescending(racer => racer.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.racers)
            {
                str.AppendLine(racer.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
