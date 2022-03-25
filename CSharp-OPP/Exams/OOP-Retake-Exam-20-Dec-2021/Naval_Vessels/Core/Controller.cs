using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly List<ICaptain> captains;
        private readonly IRepository<IVessel> vessels;

        public Controller()
        {
            this.captains = new List<ICaptain>();
            this.vessels = new VesselRepository();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (captain == null) return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            if (vessel == null) return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            if (vessel.Captain != null) return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (attackingVessel == null) return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            if (defendingVessel == null) return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attackingVessel.ArmorThickness == 0) return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            if (defendingVessel.ArmorThickness == 0) return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            IVessel vessel = this.vessels.Models.FirstOrDefault(v => v.Captain.FullName == captainFullName);

            if (vessel == null) return string.Format(OutputMessages.CaptainNotFound, captainFullName);

            return vessel.Captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == fullName);

            if (captain == null)
            {
                captain = new Captain(fullName);
                this.captains.Add(captain);
                return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
            else
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);

            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            switch (vesselType)
            {
                case "Battleship":
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;

                case "Submarine":
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;

                default:
                    return string.Format(OutputMessages.InvalidVesselType);
            }
            this.vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            switch (vessel.GetType().Name)
            {
                case "Battleship":
                    Battleship battleship = (Battleship)this.vessels.FindByName(vesselName);
                    battleship.ToggleSonarMode();
                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);

                case "Submarine":
                    Submarine submarine = (Submarine)this.vessels.FindByName(vesselName);
                    submarine.ToggleSubmergeMode();
                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                default:
                    return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if(vessel == null) return string.Format(OutputMessages.VesselNotFound, vesselName);

            return vessel.ToString();
        }
    }
}
