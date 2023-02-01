using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private readonly CocktailRepository cocktailRepository;
        private readonly DelicacyRepository delicacyRepository;
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.cocktailRepository = new CocktailRepository();
            this.delicacyRepository = new DelicacyRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0) throw new ArgumentException("Capacity has to be greater than 0!");
                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyRepository;

        public IRepository<ICocktail> CocktailMenu => this.cocktailRepository;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (!this.IsReserved) this.IsReserved = true;
            else this.IsReserved = false;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Booth: {this.BoothId}");
            str.AppendLine($"Capacity: {this.Capacity}");
            str.AppendLine($"Turnover: {this.Turnover:f2} lv");
            str.AppendLine("-Cocktail menu:");
            foreach (var cocktail in this.CocktailMenu.Models)
            {
                str.AppendLine(cocktail.ToString());
            }
            str.AppendLine("-Delicacy menu:");
            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                str.AppendLine(delicacy.ToString());
            }
            return str.ToString().TrimEnd();
        }
    }
}
