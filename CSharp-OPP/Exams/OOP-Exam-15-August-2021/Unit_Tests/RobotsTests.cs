namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Initialize()
        {
            this.robot = new Robot("Robo", 100);
            this.robotManager = new RobotManager(10);
        }

        [Test]
        public void ctor_CreateSuccessfully()
        {
            Assert.IsNotNull(this.robotManager);
            Assert.AreEqual(this.robotManager.Count, 0);
        }

        [Test]
        public void Capacity_ShouldThrowExceptionIfTheValueGoesBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void Capacity_ShouldBePositive()
        {
            Assert.AreEqual(this.robotManager.Capacity, 10);
        }

        [Test]
        public void Count_ShouldReturnCountOfRobots()
        {
            Robot robot2 = new Robot("Burny", 10);

            this.robotManager.Add(this.robot);
            this.robotManager.Add(robot2);

            Assert.AreEqual(this.robotManager.Count, 2);
        }

        [Test]
        public void Add_ShouldThrowExceptionIfRobotAlreadyExits()
        {
            this.robotManager.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));
        }

        [Test]
        public void Add_ShouldThrowExceptionIfThereIsNoSpace()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Mike", 100)));
        }

        [Test]
        public void Add_AddingCorrectlyInManager()
        {
            this.robotManager.Add(this.robot);
            Assert.AreEqual(this.robotManager.Count, 1);
        }

        [Test]
        public void Remove_ShouldThrowExceptionIfRobotWithGivenNameDoesNotExit()
        {
            this.robotManager.Add(this.robot);
            
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Mike"));
        }

        [Test]
        public void Remove_RemovingFromCollection()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Remove(this.robot.Name);
            Assert.AreEqual(this.robotManager.Count, 0);
        }

        [Test]
        public void Work_ShouldThrowExceptionIfRobotWithGivenNameDoesNotExit()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Mike", "Sewer", 50));
        }

        [Test]
        public void Work_ShouldThrowExceptionIfNotSufficientBattery()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(this.robot.Name, "Sewer", 150));
        }

        [Test]
        public void Work_ShouldReduceBatteryByBatteryUsage()
        {
            this.robotManager.Add(this.robot);
            int expectedBattery = this.robot.Battery - 50;
            this.robotManager.Work(this.robot.Name, "Mechanic", 50);

            Assert.AreEqual(expectedBattery, this.robot.Battery);
        }

        [Test]
        public void Charge_ShouldThrowExceptionIfRobotDoesNotExist()
        {
            this.robotManager.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("Mike"));
        }

        [Test]
        public void Charge_ShouldBoostBatteryUp()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work(this.robot.Name, "Dentist", 50);

            this.robotManager.Charge(this.robot.Name);

            Assert.AreEqual(100, this.robot.Battery);
        }
    }
}
