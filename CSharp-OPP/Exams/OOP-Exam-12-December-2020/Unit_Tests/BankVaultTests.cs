using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.item = new Item("Ivan", "1");
            this.bankVault = new BankVault();
        }

        [Test]
        public void ctor_CreatingSuccessful()
        {
            Assert.IsNotNull(this.bankVault);
            Assert.AreEqual(this.bankVault.VaultCells.Count, 12);
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("K2", this.item));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfCellIsAlreadyExist()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("A1", new Item("Gosho", "2")));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfItemExistInCollection()
        {
            this.bankVault.AddItem("A2", this.item);
            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem("A1", this.item));
        }

        [Test]
        public void AddItem_ShouldAddItemCorrectly()
        {
            this.bankVault.AddItem("A1", this.item);
            Item actual = this.bankVault.VaultCells["A1"];

            Assert.AreEqual(this.item.ItemId, actual.ItemId);
            Assert.IsNotNull(this.bankVault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionIfCellDoesNotExit()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("MK4", this.item));
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionIfItemInCellDoesNotExist()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A1", new Item("Ivan", "55")));
        }

        [Test]
        public void RemoveItem_ShouldEmptyTheCell()
        {
            this.bankVault.AddItem("A1", this.item);
            this.bankVault.RemoveItem("A1", this.item);

            Assert.IsNull(this.bankVault.VaultCells["A1"]);
        }
    }
}