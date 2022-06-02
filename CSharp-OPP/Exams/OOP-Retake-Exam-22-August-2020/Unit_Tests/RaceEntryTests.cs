using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitCar car;
        private RaceEntry raceEntry;
        private const int MinParticipants = 2;

        [SetUp]
        public void SetUp()
        {
            this.car = new UnitCar("BMW", 250, 3000);
            this.driver = new UnitDriver("John", this.car);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void ctor_SuccesfullyCreated()
        {
            Assert.IsNotNull(this.raceEntry);
            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ShouldThrowNullExceptionIfThereIsNoDriver()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ShouldThrowExceptionIfSuchDriverExits()
        {
            this.raceEntry.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(this.driver));
        }

        [Test]
        public void AddDriver_ShouldAddDriverAndReturnResult()
        {
            string expected = $"Driver {this.driver.Name} added in race.";

            string actual = this.raceEntry.AddDriver(this.driver);
            Assert.AreEqual(1, this.raceEntry.Counter);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowExceptionIfThereIsLessThenMinParticipants()
        {
            this.raceEntry.AddDriver(this.driver);
            
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldReturnCorrectly()
        {
            this.raceEntry.AddDriver(this.driver);
            this.raceEntry.AddDriver(new UnitDriver("Bob", new UnitCar("Camaro", 520, 5000)));

            double averageHorsePowerExpected = 385.0;

            double result = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(averageHorsePowerExpected, result);
        }
    }
}