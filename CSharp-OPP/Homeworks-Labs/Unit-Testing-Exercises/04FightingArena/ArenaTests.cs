namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private List<Warrior> warriors;
        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void Initilize()
        {
            this.warriors = new List<Warrior>();
            this.arena = new Arena();
            this.warrior = new Warrior("Tony", 50, 50);
        }

        [Test]
        public void ConstructorShouldCreateCollectionOfWarriors()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void ProperlyReturnedCollection()
        {
            CollectionAssert.AreEqual(this.warriors, this.arena.Warriors);
        }

        [Test]
        public void WarriorCountShouldReturn()
        {
            Assert.IsTrue(this.arena.Count == 0);
        }

        [Test]
        public void ArenaShouldNotEnrollAlreadyEnrolledWarriors()
        {
            this.arena.Enroll(this.warrior);

            Warrior newWarrior = new Warrior("Tony", 50, 50);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(newWarrior));
        }

        [Test]
        public void ArenaShouldEnrollWarriorSuccessfully()
        {
            this.arena.Enroll(this.warrior);

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void AttackerIsNotEnrolledInCollectionShouldReturnException()
        {
            Warrior defendWarrior = new Warrior("Jony", 40, 40);
            this.arena.Enroll(defendWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Tonyy", "Jony"));
        }

        [Test]
        public void DefenderIsNotEnrolledInCollectionShouldReturnException()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Tony", "Jony"));
        }

        [Test]
        public void TheFightWasSuccessful()
        {
            Warrior defendingWarrior = new Warrior("Jony", 50, 60);
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(defendingWarrior);

            this.arena.Fight("Tony", "Jony");

            Assert.AreEqual(10, defendingWarrior.HP);
        }
    }
}
