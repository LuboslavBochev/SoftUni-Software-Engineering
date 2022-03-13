namespace ExtendedDatabase
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person;

        [SetUp]
        public void Init()
        {
            this.person = new Person(5, "Pesho");

            this.database = new Database(this.person);
        }

        [Test]
        public void ConstructorShouldInitialize()
        {
            Assert.AreEqual(1, this.database.Count);
        }

        [Test]
        public void CorrectAddingPersonToDatabase()
        {
            this.database.Add(new Person(1, "Gosho"));

            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void TestCorrectThrowingExceptionAtAddingMoreThanSixteen()
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    this.database.Add(this.person);
                }
            });
        }

        [Test]
        public void CorrectlyRemoveFromCollection()
        {
            this.database.Remove();

            Assert.AreEqual(0, this.database.Count);
        }

        [Test]
        public void RemovingFromEmptyCollection()
        {
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void AddingPersonWithSameUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(2, "Pesho")));
        }

        [Test]
        public void AddingPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(5, "Goge")));
        }

        [Test]
        public void ThrowExceptionIfUserNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Goge"));
        }

        [Test]
        public void ThrowExceptionIfUserIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void ThrowExceptionIfNotCaseSensitive()
        {
            Assert.That(() => this.database.FindByUsername("PESHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionIfIdNowExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(4));
        }

        [Test]
        public void ThrowExceptionIfIdIsNegative()
        {
            int id = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

        [Test]
        public void ProvidedCollectionShouldNotBeGreaterThanSixteen()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() => this.database = new Database(people));
        }

        [Test]
        public void FindByUserNameShouldReturnPerson()
        {
            Assert.AreEqual(this.person, this.database.FindByUsername("Pesho"));
        }

        [Test]
        public void FindByIdShouldReturnPerson()
        {
            Assert.AreEqual(this.person, this.database.FindById(5));
        }
    }
}