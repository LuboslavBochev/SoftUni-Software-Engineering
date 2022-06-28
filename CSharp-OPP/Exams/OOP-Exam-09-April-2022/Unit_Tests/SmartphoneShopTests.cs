using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            this.smartphone = new Smartphone("Iphone", 100);
            this.shop = new Shop(10);
        }

        [Test]
        public void ctor_CreatingSuccessfully()
        {
            Assert.AreEqual(10, this.shop.Capacity);
            Assert.IsNotNull(this.shop);
            Assert.AreEqual(0, this.shop.Count);
        }

        [Test]
        public void Capacity_ShouldThrowExceptionIfIsLessThanOne()
        {
            Shop inCorrectInstance;
            Assert.Throws<ArgumentException>(() => inCorrectInstance = new Shop(-1));
        }

        [Test]
        public void Count_WorksCorrect()
        {
            this.shop.Add(this.smartphone);
            Assert.AreEqual(1, this.shop.Count);
        }

        [Test]
        public void Add_ShouldThrowExceptionIfThereIsAlreadySuchPhone()
        {
            this.shop.Add(this.smartphone);
            Assert.Throws<InvalidOperationException>(() => this.shop.Add(this.smartphone));
        }

        [Test]
        public void Add_ShouldThrowExceptionIfYouHitTheCapacityLimit()
        {
            Shop newShop = new Shop(1);
            newShop.Add(this.smartphone);
            Assert.Throws<InvalidOperationException>(() => newShop.Add(this.smartphone));
        }

        [Test]
        public void Add_WorkingCorrectly()
        {
            this.shop.Add(this.smartphone);
            Assert.AreEqual(1, this.shop.Count);
        }

        [Test]
        public void Remove_ShouldThrowExceptionIfThereIsNotSuchPhone()
        {
            this.shop.Add(this.smartphone);
            Assert.Throws<InvalidOperationException>(() => this.shop.Remove("baba"));
        }

        [Test]
        public void Remove_ShouldRemoveProperly()
        {
            this.shop.Add(this.smartphone);
            this.shop.Add(new Smartphone("Samsung", 100));

            this.shop.Remove("Samsung");

            Assert.AreEqual(1, this.shop.Count);
        }

        [Test]
        public void TestPhone_ShouldThrowExceptionIfSuchPhoneDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.shop.TestPhone("Iphone", 50));
        }

        [Test]
        public void TestPhone_ShouldThrowExceptionIfBatteryIsLow()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() => this.shop.TestPhone("Iphone", 102));
        }

        [Test]
        public void TestPhone_ShouldReduceBatteryByBatteryUsage()
        {
            this.shop.Add(this.smartphone);

            this.shop.TestPhone("Iphone", 50);

            Assert.AreEqual(50, this.smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhone_ShouldThrowExceptionIfThePhoneDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.shop.ChargePhone("Samsung"));
        }

        [Test]
        public void ChargePhone_ShouldChargeAtFullCapacity()
        {
            this.shop.Add(this.smartphone);
            this.shop.TestPhone("Iphone", 50);

            this.shop.ChargePhone("Iphone");

            Assert.AreEqual(this.smartphone.MaximumBatteryCharge, this.smartphone.CurrentBateryCharge);
        }
    }
}