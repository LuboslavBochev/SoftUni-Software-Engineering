using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            Axe axe = new Axe(50, 20);
            Dummy dummy = new Dummy(50, 30);

            axe.Attack(dummy);

            int durability = axe.DurabilityPoints;

            Assert.AreEqual(19, durability, "It was not lost durablity properly!");
        }

        [Test]
        public void AttackingWithBrokenWeaponShouldNotBePossibleAndThrowsException()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(50, 10);

            Assert.Catch<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "It was attacked with broken weapon!");
        }
    }
}