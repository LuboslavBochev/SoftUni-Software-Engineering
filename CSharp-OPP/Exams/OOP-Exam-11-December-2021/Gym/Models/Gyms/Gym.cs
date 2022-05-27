using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

        public double EquipmentWeight => this.equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
            this.Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.Name} is a {GetType().Name}:");
            str.Append("Athletes: ");
            if (this.athletes.Count > 0)
            {
                for (int i = 0; i < this.athletes.Count; i++)
                {
                    if(i + 1 == this.athletes.Count)
                    {
                        str.AppendLine(this.athletes[i].FullName);
                    }
                    else str.Append(this.athletes[i].FullName + ", ");
                }
            }
            else str.AppendLine("No athletes");
            str.AppendLine($"Equipment total count: {this.equipment.Count}");
            str.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return str.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            if (this.athletes.Contains(athlete))
            {
                this.Capacity++;
                this.athletes.Remove(athlete);
                return true;
            }
            return false;
        }
    }
}
