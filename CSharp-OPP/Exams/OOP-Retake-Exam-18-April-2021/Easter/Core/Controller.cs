using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnyRepository;
        private readonly IRepository<IEgg> eggRepository;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.bunnyRepository = new BunnyRepository();
            this.eggRepository = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            switch (bunnyType)
            {
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            this.bunnyRepository.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnyRepository.FindByName(bunnyName);

            if (bunny != null)
            {
                IDye dye = new Dye(power);
                bunny.AddDye(dye);
                return string.Format(OutputMessages.DyeAdded, power, bunnyName);
            }
            else throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggRepository.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggRepository.FindByName(eggName);

            List<IBunny> mostReadyBunnies = this.bunnyRepository.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();

            if (mostReadyBunnies.Count == 0) throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);

            foreach (var bunny in mostReadyBunnies)
            {
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0) this.bunnyRepository.Remove(bunny);
                if (egg.IsDone()) return string.Format(OutputMessages.EggIsDone, eggName);
            }
            return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.eggRepository.Models.Count(e => e.IsDone())} eggs are done!");
            str.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunnyRepository.Models)
            {
                str.AppendLine($"Name: {bunny.Name}");
                str.AppendLine($"Energy: {bunny.Energy}");
                int notFinishedCount = bunny.Dyes.Count(dye => !dye.IsFinished());
                str.AppendLine($"Dyes: {notFinishedCount} not finished");
            }
            return str.ToString().TrimEnd();
        }
    }
}
