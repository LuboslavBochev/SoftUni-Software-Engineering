using NavalVessels.Models.Contracts;
using System;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const int initialArmorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
        }

        public bool SonarMode
        {
            get => this.sonarMode;
            private set => this.sonarMode = value;
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < initialArmorThickness)
            {
                this.ArmorThickness = initialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                if (this.Speed != 0)
                {
                    this.Speed -= 5;
                }
            }
            else
            {
                this.SonarMode = false;
                if (this.MainWeaponCaliber != 0)
                {
                    this.MainWeaponCaliber -= 40;
                }
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            string switcher = this.SonarMode ? "ON" : "OFF";
            string message = $"*Sonar mode: {switcher}";

            str.AppendLine(base.ToString());
            str.AppendLine(message);

            return str.ToString().TrimEnd();
        }
    }
}
