using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly BoothRepository boothRepository;
        private readonly DelicacyRepository delicacyRepository;
        private readonly CocktailRepository cocktailRepository;

        public Controller()
        {
            this.boothRepository = new BoothRepository();
            this.delicacyRepository = new DelicacyRepository();
            this.cocktailRepository = new CocktailRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = this.boothRepository.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);

            this.boothRepository.AddModel(booth);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            ICocktail cocktail = this.cocktailRepository.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size);
            bool haveDifSize = size == "Small" || size == "Middle" || size == "Large";

            switch (cocktailTypeName)
            {
                case "Hibernation":
                    if (cocktail != null) return $"{size} {cocktailName} is already added in the pastry shop!";
                    if (!haveDifSize) return $"{size} is not recognized as valid cocktail size!";
                    cocktail = new Hibernation(cocktailName, size);
                    break;

                case "MulledWine":
                    if (cocktail != null) return $"{size} {cocktailName} is already added in the pastry shop!";
                    if (!haveDifSize) return $"{size} is not recognized as valid cocktail size!";
                    cocktail = new MulledWine(cocktailName, size);
                    break;

                default:
                    return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            this.cocktailRepository.AddModel(cocktail);
            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = this.delicacyRepository.Models.FirstOrDefault(x => x.Name == delicacyName);
            IBooth booth = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    if (delicacy != null) return $"{delicacyName} is already added in the pastry shop!";

                    delicacy = new Gingerbread(delicacyName);
                    break;

                case "Stolen":
                    if (delicacy != null) return $"{delicacyName} is already added in the pastry shop!";

                    delicacy = new Stolen(delicacyName);
                    break;

                default:
                    return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            this.delicacyRepository.AddModel(delicacy);
            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            StringBuilder str = new StringBuilder();

            IBooth booth = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            str.AppendLine($"Bill {bill:f2} lv");
            str.AppendLine($"Booth {boothId} is now available!");
            return str.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            if (this.boothRepository.Models.Count == 0) return $"No available booth for {countOfPeople} people!";

            IBooth booth = this.boothRepository.Models.Where(x => !x.IsReserved && countOfPeople <= x.Capacity)
           .OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).FirstOrDefault();

            if (booth == null) return $"No available booth for {countOfPeople} people!";
            booth.ChangeStatus();

            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderedPieces = int.Parse(tokens[2]);

            if (itemTypeName == "Hibernation" ||
                itemTypeName == "MulledWine")
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName);

                string size = tokens[3];

                if (cocktail == null) return $"There is no {itemTypeName} {itemName} available!";
                if (cocktail.Size != size) return $"There is no {size} {itemName} available!";

                switch (itemTypeName)
                {
                    case "Hibernation":
                        booth.UpdateCurrentBill(((Hibernation)cocktail).Price * countOfOrderedPieces);
                        break;

                    case "MulledWine":
                        booth.UpdateCurrentBill(((MulledWine)cocktail).Price * countOfOrderedPieces);
                        break;
                }
            }
            else if (itemTypeName == "Gingerbread" ||
                itemTypeName == "Stolen")
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName);

                if (delicacy == null) return $"There is no {itemTypeName} {itemName} available!";

                switch (itemTypeName)
                {
                    case "Gingerbread":
                        booth.UpdateCurrentBill(((Gingerbread)delicacy).Price * countOfOrderedPieces);
                        break;

                    case "Stolen":
                        booth.UpdateCurrentBill(((Stolen)delicacy).Price * countOfOrderedPieces);
                        break;
                }
            }
            else
            {
                return $"{itemTypeName} is not recognized type!";
            }

            return $"Booth {boothId} ordered {countOfOrderedPieces} {itemName}!";
        }
    }
}
