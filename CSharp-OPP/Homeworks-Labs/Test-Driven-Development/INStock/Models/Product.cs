using INStock.Contracts;
using System;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get => this.label;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Label can not be null or empty!");
                }
                this.label = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("The price of the product can not be zero or negative number!");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("The quantity of the product can not be negative number!");
                }
                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            int result = 0;

            if(this.price > other.Price)
            {
                result = 1;
            }
            if(this.price < other.Price)
            {
                result = -1;
            }
            return result;
        }
    }
}
