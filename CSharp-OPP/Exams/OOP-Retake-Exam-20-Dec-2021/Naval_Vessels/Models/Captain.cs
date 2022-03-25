using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }

        public int CombatExperience // with the initial value of 0, could be increased by 10.
        {
            get => this.combatExperience;
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get => this.vessels; private set => this.vessels = value; }

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if(this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    str.AppendLine(vessel.ToString());
                }
            }
            return str.ToString().TrimEnd();
        }
    }
}
