namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete;

        [SetUp]
        public void SetUp()
        {
            this.gym = new Gym("Titans", 10);
            this.athlete = new Athlete("Tom");
        }

        [Test]
        public void Constructor_CreatingInstanceCorrect()
        {
            Assert.IsNotNull(this.gym);
            Assert.That(this.gym.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void GymName_ShouldNotBeNullOrEmpty(string name)
        {
            Gym fitness = null;
            Assert.Throws<ArgumentNullException>(() => fitness = new Gym(name, 2));
        }

        [Test]
        public void GymCapacity_ShouldNotBeNegative()
        {
            Gym fitness = null;
            Assert.Throws<ArgumentException>(() => fitness = new Gym("John", -2));
        }

        [Test]
        public void AddAthlete_IfThereIsSpaceInGymShouldAddAthlete()
        {
            this.gym.AddAthlete(this.athlete);

            Assert.AreEqual(1, this.gym.Count);
        }

        [Test]
        public void AddAthlete_ShouldThrowExceptionIfGymIsFull()
        {
            Gym gym = new Gym("Pulse", 1);

            gym.AddAthlete(this.athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Bruce")));
        }

        [Test]
        public void RemoveAthlete_ShouldRemoveAthleteIfExists()
        {
            this.gym.AddAthlete(this.athlete);

            int sizeOfFittnes = this.gym.Count;

            this.gym.RemoveAthlete(this.athlete.FullName);
            sizeOfFittnes--;

            Assert.That(sizeOfFittnes, Is.EqualTo(this.gym.Count));
        }

        [Test]
        public void RemoveAthlete_ShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete(this.athlete.FullName));
        }

        [Test]
        public void InjureAthlete_ShouldReturnInjuredAthlete()
        {
            this.gym.AddAthlete(this.athlete);

            Athlete injuredAthlete = this.gym.InjureAthlete(this.athlete.FullName);

            Assert.IsTrue(injuredAthlete.IsInjured);
        }

        [Test]
        public void InjureAthlete_ShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete(this.athlete.FullName));
        }

        [Test]
        public void Report_ShouldReturnOnlyInGoodHealthAthletes()
        {
            Athlete john = new Athlete("John");
            Athlete mark = new Athlete("Mark");
            Athlete josh = new Athlete("Josh");

            this.gym.AddAthlete(this.athlete);
            this.gym.AddAthlete(mark);
            this.gym.AddAthlete(john);
            this.gym.AddAthlete(josh);

            this.gym.InjureAthlete(josh.FullName);

            string expected = string.Join(", ", this.ReturnHealthyAthletes());

            string healthyAthletesReturned = this.gym.Report().Split(": ")[1];

            Assert.AreEqual(expected, healthyAthletesReturned);
        }

        private List<string> ReturnHealthyAthletes()
        {
            List<string> athletes = new List<string>();

            Athlete john = new Athlete("John");
            Athlete mark = new Athlete("Mark");

            athletes.Add(this.athlete.FullName);
            athletes.Add(mark.FullName);
            athletes.Add(john.FullName);
            return athletes;
        }
    }
}
