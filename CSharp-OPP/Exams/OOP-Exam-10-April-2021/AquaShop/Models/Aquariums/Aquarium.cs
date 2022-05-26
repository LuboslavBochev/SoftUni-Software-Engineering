using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort); // vish dali e taka

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity > 0)
            {
                this.fish.Add(fish);
                this.Capacity--;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.Name} ({this.GetType().Name}):");
            str.Append($"Fish: ");
            if (this.fish.Count > 0)
            {
                str.AppendLine(string.Join(", ", this.fish));
            }
            else str.AppendLine("none");
            str.AppendLine($"Decorations: {this.decorations.Count}");
            str.AppendLine($"Comfort: {this.Comfort}");

            return str.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            bool isRemoved = this.fish.Remove(fish);

            if (isRemoved)
            {
                this.Capacity++;
                return isRemoved;
            }
            else return isRemoved;
        }
    }
}
