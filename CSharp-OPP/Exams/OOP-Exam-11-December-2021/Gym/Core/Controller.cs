using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private List<IGym> gyms;
        private EquipmentRepository equipmentRepository;

        public Controller()
        {
            this.gyms = new List<IGym>();
            this.equipmentRepository = new EquipmentRepository();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            gym = GymCreating(gymType, gymName);

            this.gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            equipment = EquipmentCreating(equipmentType);

            this.equipmentRepository.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipmentRepository.FindByType(equipmentType);

            if (equipment == null)
            {
                string message = string.Format(ExceptionMessages.InexistentEquipment, equipmentType);
                throw new InvalidOperationException(message);
            }
            this.equipmentRepository.Remove(equipment);

            IGym gym = this.gyms.Find(g => g.Name == gymName);
            gym.AddEquipment(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;

                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            IGym gym = this.gyms.Find(g => g.Name == gymName);
            string gymType = gym.GetType().Name;

            if (athleteType == "Boxer" && gymType == "BoxingGym")
            {
                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && gymType == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gym.Name);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.Find(g => g.Name == gymName);

            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.Find(g => g.Name == gymName);

            double wholeWeight = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, wholeWeight);
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                str.AppendLine(gym.GymInfo());
            }
            return str.ToString().TrimEnd();
        }

        private IGym GymCreating(string gymType, string gymName)
        {
            IGym gym = null;

            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;

                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            return gym;
        }

        private IEquipment EquipmentCreating(string equipmentType)
        {
            IEquipment equipment = null;

            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    break;

                case "Kettlebell":
                    equipment = new Kettlebell();
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            return equipment;
        }
    }
}
