using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private ICollection<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets
        {
            get => this.targets;
            private set => this.targets = value;
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            double reducedPoints = target.ArmorThickness - this.MainWeaponCaliber;

            if (reducedPoints <= 0)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }
            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"- {this.Name}");
            str.AppendLine($"*Type: {this.GetType().Name}");
            str.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            str.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            str.AppendLine($"*Speed: {this.Speed} knots");
            if (this.targets.Count == 0)
            {
                str.AppendLine("*Targets: None");
            }
            else
            {
                str.Append("*Targets: ");
                str.AppendLine(string.Join(", ", this.targets));
            }
            return str.ToString().TrimEnd();
        }
    }
}
