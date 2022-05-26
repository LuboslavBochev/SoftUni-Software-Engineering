namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish nemo;
        private Fish emerald;
        private Fish tony;

        [SetUp]
        public void SetUp()
        {
            this.nemo = new Fish("Nemo");
            this.emerald = new Fish("Emerald");
            this.tony = new Fish("Tony");
            this.aquarium = new Aquarium("World", 3);
        }

        [Test]
        public void ctor_Success()
        {
            Assert.IsNotNull(this.aquarium);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumName_ShouldThrowExceptionIfInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 5));
        }

        [Test]
        public void AquariumCapacity_ShouldThrowExceptionIfInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("blabla", -2));
        }

        [Test]
        public void AquariumCount_ShouldReturnCountOfTheAquarium()
        {
            this.aquarium.Add(nemo);
            this.aquarium.Add(emerald);
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.aquarium.Count);
        }

        [Test]
        public void Add_ShouldThrowExceptionIfAquariumIsFull()
        {
            this.aquarium.Add(nemo);
            this.aquarium.Add(emerald);
            this.aquarium.Add(tony);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Daisy")));
        }

        [Test]
        public void Add_AddingSuccessfully()
        {
            this.aquarium.Add(nemo);

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void RemoveFish_ShouldReturnExceptionIfSuchFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Emily"));
        }

        [Test]
        public void RemoveFish_Successfully ()
        {
            this.aquarium.Add(nemo);
            this.aquarium.RemoveFish("Nemo");

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void SellFish_ShouldReturnExceptionIfSuchFishDoesNotExist()
        {
            this.aquarium.Add(this.nemo);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Emily"));
        }

        [Test]
        public void SellFish_ShouldReturnSoldFish()
        {
            this.aquarium.Add(this.nemo);
            this.aquarium.Add(this.emerald);

            Fish soldFish = this.aquarium.SellFish("Nemo");

            bool expectedIsAvailable = false;

            Assert.AreEqual(expectedIsAvailable, soldFish.Available);
        }

        [Test]
        public void Report_ShouldReturnAllFish()
        {
            List<Fish> fish = new List<Fish>();

            fish.Add(this.nemo);
            fish.Add(this.emerald);
            fish.Add(this.tony);

            string fishNames = string.Join(", ", fish.Select(f => f.Name));
            string expectedReport = $"Fish available at {this.aquarium.Name}: {fishNames}";

            this.aquarium.Add(this.nemo);
            this.aquarium.Add(this.emerald);
            this.aquarium.Add(this.tony);

            Assert.AreEqual(expectedReport, this.aquarium.Report());
        }
    }
}
