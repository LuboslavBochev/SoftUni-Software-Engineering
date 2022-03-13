namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior attackWarrior;
        private Warrior defendWarrior;

        [SetUp]
        public void Initilize()
        {
            this.attackWarrior = new Warrior("John", 50, 50);
            this.defendWarrior = new Warrior("Bradly", 40, 40);
        }

        [Test]
        public void ConstructorShouldCreateWarrior()
        {
            Assert.IsNotNull(this.attackWarrior);
        }

        [Test]
        public void WarriorNameShouldNotBeNull()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior(null, 20, 30));
        }

        [Test]
        public void WarriorNameShouldNotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior("", 20, 30));
        }

        [Test]
        public void WarriorNameShouldNotBeWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior(" ", 20, 30));
        }

        [Test]
        public void WarriorDamageShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior("Josh", -20, 30));
        }

        [Test]
        public void WarriorDamageShouldNotBeZero()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior("Josh", 0, 30));
        }

        [Test]
        public void HpShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => this.attackWarrior = new Warrior("Josh", 40, -5));
        }

        [Test]
        public void HpShouldNotBeLessMinHpToAttack()
        {
            this.attackWarrior = new Warrior("Tony", 30, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.attackWarrior.Attack(this.defendWarrior);
            });
        }

        [Test]
        public void HpShouldNotBeEqualMinHpToAttack()
        {
            this.attackWarrior = new Warrior("Tony", 30, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.attackWarrior.Attack(this.defendWarrior);
            });
        }

        [Test]
        public void HpOfTheDefenderShouldNotBeLessMinHpToBeAttacked()
        {
            this.defendWarrior = new Warrior("Lyubo", 30, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.attackWarrior.Attack(this.defendWarrior);
            });
        }

        [Test]
        public void HpOfTheDefenderShouldNotBeEqualMinHpToBeAttacked()
        {
            this.defendWarrior = new Warrior("Lyubo", 30, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.attackWarrior.Attack(this.defendWarrior);
            });
        }

        [Test]
        public void AttackingTooStrongEnemyShouldNotBePossible()
        {
            this.attackWarrior = new Warrior("Tony", 10, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.attackWarrior.Attack(this.defendWarrior);
            });
        }

        [Test]
        public void AttackingIsSuccessful()
        {
            this.attackWarrior.Attack(this.defendWarrior);

            Assert.AreEqual(10, this.attackWarrior.HP);
        }

        [Test]
        public void DefendingIsSuccessful()
        {
            this.defendWarrior = new Warrior("Gogo", 30, 60);

            this.attackWarrior.Attack(this.defendWarrior);

            Assert.AreEqual(10, this.defendWarrior.HP);
        }

        [Test]
        public void AttackDamageIsGreaterThanHpOfTheDefender()
        {
            this.attackWarrior.Attack(this.defendWarrior);

            Assert.AreEqual(0, this.defendWarrior.HP);
        }
    }
}