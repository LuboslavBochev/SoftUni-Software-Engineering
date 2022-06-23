using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Apple", "X3", 2000.00M);
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ctor_CreateSuccessful()
        {
            Assert.IsNotNull(this.computerManager);
            Assert.AreEqual(this.computerManager.Count, 0);
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionIfComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionIfSuchComputerAlreadyExist()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(this.computer));
        }

        [Test]
        public void AddComputer_AddingSuccessfully()
        {
            this.computerManager.AddComputer(this.computer);
            Computer actualComp = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.AreEqual(this.computer, actualComp);
            Assert.AreEqual(this.computerManager.Count, 1);
        }

        [Test]
        public void RemoveComputer_ShouldThrowExceptionIfSuchComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model));
        }

        [Test]
        public void RemoveComputer_ShouldRemoveComputerSuccessfully()
        {
            this.computerManager.AddComputer(this.computer);

            Computer actualComputer = this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.AreEqual(this.computer, actualComputer);
            Assert.AreEqual(this.computerManager.Count, 0);
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(null, this.computer.Model));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(this.computer.Manufacturer, null));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfThereIsNoSuchCompute()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model));
        }

        [Test]
        public void GetComputer_ShouldReturnThisComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Computer expectedComputer = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.AreEqual(expectedComputer, this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldThrowExceptionIfThereIsNoSuchManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnAllComputersWithGivenManufacturer()
        {
            this.computerManager.AddComputer(this.computer);
            this.computerManager.AddComputer(new Computer("Apple", "X2", 1500));
            this.computerManager.AddComputer(new Computer("Apple", "X5", 3500));

            Assert.AreEqual(this.computerManager.GetComputersByManufacturer(this.computer.Manufacturer).Count, 3);
        }
    }
}