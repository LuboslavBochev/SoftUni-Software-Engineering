using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Initialize()
        {
            this.axe = new Axe(35, 10);
            this.dummy = new Dummy(40, 31);
        }

        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            this.axe.Attack(this.dummy);

            Assert.IsTrue(this.dummy.Health == 5, "It was not lost health");
        }

        [Test]
        public void DeadDummyShouldReturnExceptionIfAttacked()
        {
            this.dummy = new Dummy(0, 20);

            Assert.Catch<InvalidOperationException>(() =>
            {
                this.axe.Attack(this.dummy);
            }, "Dead Dummy attacks died");
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            this.dummy = new Dummy(0, 20);

            int experience = this.dummy.GiveExperience();

            Assert.IsTrue(experience == 20, "Dead Dummy couldn't return experience!");
        }

        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                this.dummy.GiveExperience();
            }, "Alive dummy returned experience!");
        }
    }
}