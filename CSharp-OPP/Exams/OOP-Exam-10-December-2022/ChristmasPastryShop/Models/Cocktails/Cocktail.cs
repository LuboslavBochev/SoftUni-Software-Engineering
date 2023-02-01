using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public string Size { get; private set; } //"Small", "Middle", "Large". this.Size will be validated later in the Controller class.

        public double Price
        {
            get => price;
            private set
            {
                switch (this.Size)
                {
                    case "Middle":
                        this.price = value * (2.0 / 3.0);
                        break;

                    case "Small":
                        this.price = value * (1.0 / 3.0);
                        break;

                    case "Large":
                        this.price = value;
                        break;
                }
            }
        }
        public override string ToString()
        {
            return $"--{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
