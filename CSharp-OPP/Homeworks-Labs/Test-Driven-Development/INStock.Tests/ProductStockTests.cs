namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock products;
        private Product product;

        [SetUp]
        public void SetUp()
        {
            this.products = new ProductStock();
            this.product = new Product("IPhone", 500, 1);
        }

        [Test]
        public void Constructor_ShouldInitilizeCollectionOfProducts()
        {
            Assert.IsNotNull(this.products);
        }

        [Test]
        public void Count_ShouldReturnTheCountOfTheCollection()
        {
            this.products.Add(this.product);

            int expected = 1;

            Assert.That(expected, Is.EqualTo(this.products.Count));
        }

        [Test]
        public void Collection_ShouldReturnIProductWhenIdIsValid()
        {
            int index = 0;

            Product newProduct = new Product("IPhone", 500, 1);

            this.products.Add(newProduct);

            IProduct returnedProduct = this.products[index];

            Assert.AreEqual(this.product.Label, returnedProduct.Label);
            Assert.AreEqual(this.product.Price, returnedProduct.Price);
            Assert.AreEqual(this.product.Quantity, returnedProduct.Quantity);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        public void Collection_ShouldThrowExceptionIfIndexIsNotValid(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IProduct returnedProduct = this.products[index];
            });
        }

        [Test]
        [TestCase(10)]
        public void Collection_ShouldThrowExceptionIfSetOnInvalidIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.products[index] = this.product);
        }

        [Test]
        public void Collection_ShouldThrowExceptionIfObjectToSetIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.products[0] = null);
        }

        [Test]
        public void Add_ShouldAddStockInCollection()
        {
            this.products.Add(this.product);

            Assert.IsTrue(this.products.Contains(this.product));
            Assert.AreEqual(1, this.products.Count);
        }

        [Test]
        public void Add_ShouldThrowExceptionIfProductAlreadyExists()
        {
            this.products.Add(this.product);

            Assert.Throws<ArgumentException>(() => this.products.Add(this.product));
        }

        [Test]
        public void Add_ShouldThrowExceptionIfAddNullObject()
        {
            Assert.Throws<ArgumentNullException>(() => this.products.Add(null));
        }

        [Test]
        public void Contains_ShouldReturnTrueIfProductExists()
        {
            this.products.Add(this.product);

            Assert.IsTrue(this.products.Contains(this.product));
        }

        [Test]
        public void Contains_ShouldReturnFalseIfProductNotExists()
        {
            Assert.IsFalse(this.products.Contains(this.product));
        }

        [Test]
        public void Contains_ShouldThrowExceptionIfObjIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.products.Contains(null));
        }

        [Test]
        public void Find_ShouldReturnProductIfIndexIsValid()
        {
            int index = 0;

            this.products.Add(this.product);

            IProduct product = this.products.Find(index);

            Assert.That(this.product, Is.EqualTo(product));
        }

        [Test]
        [TestCase(-2)]
        [TestCase(2)]
        [TestCase(20)]
        public void Find_ShouldThrowExceptionIfInvalidIndexIsProvided(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.products.Find(index));
        }

        [Test]
        public void FindByLabel_ShouldReturnProductIfSuchLabelExists()
        {
            string label = this.product.Label;

            this.products.Add(this.product);

            IProduct product = this.products.FindByLabel(label);

            Assert.That(product.Label, Is.EqualTo(label));
        }

        [Test]
        public void FindByLabel_ThrowExceptionIfLabelDoesNotExist()
        {
            string label = "1234";

            this.products.Add(this.product);

            Assert.Throws<ArgumentException>(() => this.products.FindByLabel(label));
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnCollectionInProvidedRange()
        {
            double low = 0;
            double high = 5;

            CreateProducts();

            List<IProduct> expected = this.products.Where(p => p.Price >= (decimal)low && p.Price <= (decimal)high).OrderByDescending(p => p.Price).ToList();

            List<IProduct> productsInRange = this.products.FindAllInRange(low, high).ToList();

            Assert.That(expected, Is.EquivalentTo(productsInRange));
        }

        [Test]
        [TestCase(-1, 20)]
        [TestCase(-5, -2)]
        public void FindAllInPriceRange_ShouldThrowExceptionIfIndexesAreNotValid(int lo, int hi)
        {
            this.products.Add(this.product);
            Assert.Throws<IndexOutOfRangeException>(() => this.products.FindAllInRange(lo, hi));
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnEmptyCollectionIfThereAreNoElements()
        {
            Assert.That(this.products, Is.EquivalentTo(this.products.FindAllInRange(0, 2)));
        }

        [Test]
        [TestCase(100)]
        [TestCase(105)]
        [TestCase(102)]
        public void FindAllByPrice_ShouldReturnProductsWithGivenPrice(double price)
        {
            CreateProducts();

            List<IProduct> expectedProducts = this.products.Where(p => p.Price == (decimal)price).ToList();

            Assert.That(expectedProducts, Is.EquivalentTo(this.products.FindAllByPrice(price)));
        }

        [Test]
        public void FindAllByPrice_ShouldReturnEmptyCollectionIfThereAreNoSuchPrice()
        {
            CreateProducts();

            double price = 200;

            List<IProduct> expectedProducts = this.products.Where(p => p.Price == (decimal)price).ToList();

            Assert.That(expectedProducts, Is.EquivalentTo(this.products.FindAllByPrice(price)));
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldReturnProductProperlly()
        {
            IProduct mostExpensiveProduct = new Product("110abv", 5000, 1);

            CreateProducts();

            this.products.Add(mostExpensiveProduct);

            Assert.That(mostExpensiveProduct, Is.EqualTo(this.products.FindMostExpensiveProduct()));
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldThrowExceptionIfThereAreNoElements()
        {
            Assert.Throws<ArgumentException>(() => this.products.FindMostExpensiveProduct());
        }

        [Test]
        public void Remove_ShouldRemoveElement()
        {
            this.products.Add(this.product);

            Assert.IsTrue(this.products.Remove(this.product));
            Assert.That(this.products.Count, Is.Zero);
        }

        [Test]
        public void Remove_ShouldReturnFalseIfSuchElementsDoesNotExist()
        {
            IProduct newProduct = new Product("sda", 100, 2);
            Assert.IsFalse(this.products.Remove(newProduct));
        }

        [Test]
        [TestCase(100)]
        [TestCase(105)]
        [TestCase(102)]
        public void FindAllByQuantity_ShouldReturnProductsWithGivenQuantity(int quantity)
        {
            CreateProducts();

            List<IProduct> expectedProducts = this.products.Where(p => p.Quantity == quantity).ToList();

            Assert.That(expectedProducts, Is.EquivalentTo(this.products.FindAllByQuantity(quantity)));
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnEmptyCollectionIfThereAreNoSuchQuantity()
        {
            CreateProducts();

            int quantity = 2000;

            List<IProduct> expectedProducts = this.products.Where(p => p.Quantity == quantity).ToList();

            Assert.That(expectedProducts, Is.EquivalentTo(this.products.FindAllByPrice(quantity)));
        }


        private void CreateProducts()
        {
            for (int i = 0; i < 10; i++)
            {
                this.products.Add(new Product($"1{i}", 100 + i, 2 + i));
            }
        }
    }
}
