namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.present = new Present("Truck", 20);
            this.bag = new Bag();
        }

        [Test]
        public void ctor_CreatePresentConstructor()
        {
            Assert.IsNotNull(this.present);
        }

        [Test]
        public void ctor_CreateBagConstructor()
        {
            Assert.IsNotNull(this.bag);
            Assert.That(this.bag.GetPresents().Count, Is.Zero);
        }

        [Test]
        public void Create_ThrowsExceptionWithNullPresent()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }

        [Test]
        public void Create_ThrowsExceptionIfPresentAlreadyExists()
        {
            this.bag.Create(this.present);
            Assert.Throws<InvalidOperationException>(() => this.bag.Create(this.present));
        }

        [Test]
        public void Create_AddingPresentInBag()
        {
            this.bag.Create(this.present);

            Present expectedPresent = this.present;
            Present returnedPresent = this.bag.GetPresent(this.present.Name);

            Assert.AreEqual(this.bag.GetPresents().Count, 1);
            Assert.That(expectedPresent, Is.EqualTo(returnedPresent));
        }

        [Test]
        public void Remove_RemovingExistingPresent()
        {
            this.bag.Create(this.present);

            Assert.IsTrue(this.bag.Remove(this.present));
        }

        [Test]
        public void Remove_RemovingNonExistingPresent()
        {
            Assert.IsFalse(this.bag.Remove(this.present));
        }

        [Test]
        public void GetPresentWithLeastMagic_GettingPresentWithLeastMagicShouldReturnProperlly()
        {
            Present expectedPresent = new Present("LeastMagic", 10);

            this.bag.Create(this.present);
            this.bag.Create(expectedPresent);

            Assert.AreEqual(expectedPresent, this.bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresent_ShouldReturnPresentIfExist()
        {
            Present dollPresent = new Present("Doll", 20);

            this.bag.Create(this.present);
            this.bag.Create(dollPresent);

            string presentName = "Doll";

            Assert.AreEqual(presentName, this.bag.GetPresent(presentName).Name);
        }

        [Test]
        public void GetPresents_ReturningCollectionOfPresents()
        {
            Present dollPresent = new Present("Doll", 20);
            Present carPresent = new Present("Car", 30);
            Present bearPresent = new Present("Bear", 50);


            List<Present> presents = new List<Present>();
            presents.Add(this.present);
            presents.Add(dollPresent);
            presents.Add(bearPresent);
            presents.Add(carPresent);

            this.bag.Create(this.present);
            this.bag.Create(dollPresent);
            this.bag.Create(bearPresent);
            this.bag.Create(carPresent);

            CollectionAssert.AreEqual(presents, this.bag.GetPresents());
        }
    }
}
