using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Garage garage;
            private Car car;

            [SetUp]
            public void SetUp()
            {
                this.car = new Car("BMW", 0);
                this.garage = new Garage("Tosho", 100);
            }

            [Test]
            public void ctor_CreatingSuccessfully()
            {
                Assert.IsNotNull(this.garage);
            }

            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void name_ShouldThrowExceptionIfIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, 2));
            }

            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            public void mechanicsAvailable_ShouldThrowExceptionBellowAndEqualZero(int mechanics)
            {
                Assert.Throws<ArgumentException>(() => new Garage("BMW", mechanics));
            }

            [Test]
            public void CarsInGarage_RetursSuccessfully()
            {
                this.garage.AddCar(this.car);
                Assert.AreEqual(1, this.garage.CarsInGarage);
            }

            [Test]
            public void AddCar_ShouldThrowExceptionIfThereAreNoMechanics()
            {
                Garage newGarage = new Garage("Toto", 1);
                newGarage.AddCar(this.car);
                Assert.Throws<InvalidOperationException>(() => newGarage.AddCar(new Car("BMW", 2)));
            }

            [Test]
            public void AddCar_AddingCarIntoGarage()
            {
                this.garage.AddCar(this.car);
                Assert.AreEqual(1, this.garage.CarsInGarage);
            }

            [Test]
            public void FixCar_ShouldThrowIfTheCarDoesNotExist()
            {
                Assert.Throws<InvalidOperationException>(() => this.garage.FixCar("Mercedes"));
            }

            [Test]
            public void FixCar_FixingAllIssues()
            {
                Car issueCar = new Car("Mercedes", 2);
                this.garage.AddCar(issueCar);
                this.garage.AddCar(this.car);

                Assert.AreEqual(0, this.garage.FixCar("Mercedes").NumberOfIssues);
            }

            [Test]
            public void RemoveCar_ShouldThrowExceptionIfThereIsNotFixedCar()
            {
                this.garage.AddCar(this.car);
                this.garage.AddCar(new Car("Mercedes", 0));
                this.garage.AddCar(new Car("Pegeout", 2));

                int expectedCars = 2;
                int removedCars = this.garage.RemoveFixedCar();

                Assert.AreEqual(expectedCars, removedCars);
            }

            [Test]
            public void Report_MakingReportSuccessfully()
            {
                this.garage.AddCar(this.car);
                this.garage.AddCar(new Car("Mercedes", 0));
                this.garage.AddCar(new Car("Pegeout", 2));
                this.garage.AddCar(new Car("Pegeou", 5));

                string expectedResult = $"There are 2 which are not fixed: Pegeout, Pegeou.";

                Assert.AreEqual(expectedResult, this.garage.Report());
            }
        }
    }
}