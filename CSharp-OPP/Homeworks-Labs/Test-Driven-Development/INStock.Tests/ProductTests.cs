namespace INStock.Tests
{
    using System;
    using INStock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        [TestCase("Apple", 0.5, 10)]
        public void Constructor_ShouldSetParametersIfTheyAreValid(string label, decimal price, int quantity)
        {
            Product newProduct = new Product(label, price, quantity);

            Assert.AreEqual(label, newProduct.Label);
            Assert.AreEqual(price, newProduct.Price);
            Assert.AreEqual(quantity, newProduct.Quantity);
        }

        [Test]
        [TestCase("", 0.2, 10)]
        [TestCase(null, 0.1, 20)]
        [TestCase(" ", 0.22, 30)]
        [TestCase("Apple", 0, 30)]
        [TestCase("Apple", -2, 30)]
        [TestCase("Apple", 2, -2)]
        public void Constructor_ShouldThrowExceptionIfParametersAreNotValid(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity));
        }

        [Test]
        [TestCase(20)]
        [TestCase(199)]
        public void CompareTo_ShouldComparePriceProperlly(decimal price)
        {
            Product firstIphone = new Product("IPhone", price, 10);
            Product secondIphone = new Product("IPhone", 150, 10);

            decimal expected = -1;

            decimal actual = firstIphone.CompareTo(secondIphone);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}