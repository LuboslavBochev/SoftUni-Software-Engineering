using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get => this.products[index];
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("The product should not be null");
                }
                if(index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is not in range!");
                }
                this.products[index] = value;
            }
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            if(this.products.Contains(product))
            {
                throw new ArgumentException();
            }
            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            if(!this.products.Contains(product))
            {
                return false;
            }
            return true;
        }

        public IProduct Find(int index)
        {
            if(index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return this.products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            List<IProduct> products = this.products.Where(p => p.Price == (decimal)price).ToList();
            return products;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> products = this.products.Where(p => p.Quantity == quantity).ToList();
            return products;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            if (this.Count == 0)
            {
                return new List<IProduct>();
            }
            if (lo < 0 || lo >= this.Count || hi < 0 || hi >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            List<IProduct> productsInRange = this.products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi).OrderByDescending(p => p.Price).ToList();

            return productsInRange;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == label);

            if(product == null)
            {
                throw new ArgumentException();
            }
            else
            {
                return product;
            }
        }

        public IProduct FindMostExpensiveProduct()
        {
            if(this.Count == 0)
            {
                throw new ArgumentException();
            }
            return this.products.OrderByDescending(p => p.Price).First();
        }

        public bool Remove(IProduct product)
        {
            if(this.products.Contains(product))
            {
                this.products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in this.products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
