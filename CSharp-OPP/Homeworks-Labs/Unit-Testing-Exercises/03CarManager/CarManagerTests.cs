namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Initilize()
        {
            this.car = new Car("Ford", "Escord", 5, 60);
        }

        [Test]
        public void ConstructorsShouldCreateCar()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void ValidationMakeShouldReturnExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("", "X3", 5, 50));
        }

        [Test]
        public void ValidationMakeShouldReturnExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(null, "X3", 5, 50));
        }

        [Test]
        public void ValidationModelShouldReturnExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", "", 5, 50));
        }

        [Test]
        public void ValidationModelShouldReturnExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", null, 5, 50));
        }

        [Test]
        public void ValidationFuelConsumtionShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", "Escord", -5, 50));
        }

        [Test]
        public void ValidationFuelConsumtionShouldNotBeZero()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", "Escord", 0, 50));
        }

        [Test]
        public void ValidationFuelAmountShouldNotBeNegative()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void ValidationFuelCapacityShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", "Escord", 5, -50));
        }

        [Test]
        public void ValidationFuelCapacityShouldNotBeZero()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Ford", "Escord", 5, 0));
        }

        [Test]
        public void FuelToRefulShoulNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(-2));
        }

        [Test]
        public void FuelToRefulShouldNotBeZero()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void FuelToRefulWorkFineWithAmountBelowCapacity()
        {
            this.car.Refuel(25);

            Assert.AreEqual(25, this.car.FuelAmount);
        }

        [Test]
        public void FuelToRefulWorkFineWithAmountAboveCapacity()
        {
            this.car.Refuel(70);

            Assert.AreEqual(60, this.car.FuelAmount);
        }

        [Test]
        public void DriveWithNotEnoughFuelShouldReturnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(500));
        }

        [Test]
        public void DriveMethodWorksFine()
        {
            this.car.Refuel(30);
            this.car.Drive(500);

            Assert.AreEqual(5, this.car.FuelAmount);
        }
    }
}