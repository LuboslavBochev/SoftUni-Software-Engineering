using NavalVessels.Models.Contracts;
using System;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const int initialArmorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
        }

        public bool SubmergeMode { get => this.submergeMode; private set => this.submergeMode = value; }

        public override void RepairVessel()
        {
            if(this.ArmorThickness < initialArmorThickness)
            {
                this.ArmorThickness = initialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if(!this.SubmergeMode)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            string switcher = this.SubmergeMode ? "ON" : "OFF";
            string message = $"*Submerge mode: {switcher}";

            str.AppendLine(base.ToString());
            str.AppendLine(message);

            return str.ToString().TrimEnd();
        }
    }
}
