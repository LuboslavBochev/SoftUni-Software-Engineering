using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skis;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.skis = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.skis.Count;
            }
        }

        public void Add(Ski ski)
        {
            if (this.Capacity > 0)
            {
                this.skis.Add(ski);
                this.Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            int index = 0;

            if (this.Count != 0)
            {
                foreach (var ski in this.skis)
                {
                    if (ski.Manufacturer == manufacturer && ski.Model == model)
                    {
                        this.skis.RemoveAt(index);
                        this.Capacity++;
                        return true;
                    }
                    index++;
                }
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.Count != 0)
            {
                return this.skis.OrderByDescending(ski => ski.Year).First();
            }
            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            int index = 0;

            if (this.Count != 0)
            {
                foreach (var ski in this.skis)
                {
                    if (ski.Manufacturer == manufacturer && ski.Model == model)
                    {
                        return this.skis[index];
                    }
                    index++;
                }
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in this.skis)
            {
                str.AppendLine(ski.ToString());
            }
            return str.ToString();
        }
    }
}
