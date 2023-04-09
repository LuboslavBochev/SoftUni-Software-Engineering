using NUnit.Framework;
using System;

namespace UniversityLibrary.Test
{
    [TestFixture]
    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            this.textBook = new TextBook("Harry Potter", "SomeAuthor", "Fantasy");
            this.library = new UniversityLibrary();
        }

        [Test]
        public void ctorShouldCreateListOfBooks()
        {
            Assert.IsNotNull(this.library);
        }

        [Test]
        public void AddTextBookToLibraryShouldAddBookAndAssigsANumber()
        {
            this.library.AddTextBookToLibrary(new TextBook("Some", "Author", "Action"));
            string textBookAdded = this.library.AddTextBookToLibrary(textBook);

            int expectedInventoryNum = this.library.Catalogue.Count;

            Assert.That(expectedInventoryNum, Is.EqualTo(this.textBook.InventoryNumber));
        }

        [Test]
        [TestCase(1, "John")]
        public void LoanTextBookShouldSayThatTheBookIsntReturned(int bookInventoryNumber, string studentName)
        {
            this.textBook.Holder = "John";
            this.library.AddTextBookToLibrary(this.textBook);
            string result = $"{studentName} still hasn't returned {this.textBook.Title}!";

            Assert.That(result, Is.EqualTo(this.library.LoanTextBook(bookInventoryNumber, studentName)));
        }

        [Test]
        [TestCase(1, "Barney")]
        public void LoanTextBookShouldSayThatTheBookIsReturned(int bookInventoryNumber, string studentName)
        {
            string result = $"{this.textBook.Title} loaned to {studentName}.";
            this.library.AddTextBookToLibrary(this.textBook);

            Assert.That(result, Is.EqualTo(this.library.LoanTextBook(bookInventoryNumber, studentName)));
            string expectedHolder = this.textBook.Holder;

            Assert.That(expectedHolder, Is.EqualTo(this.textBook.Holder));
        }

        [Test]
        [TestCase (1)]
        public void ReturnTextBookShouldReturnTolibrary(int bookNum)
        {
            this.library.AddTextBookToLibrary(this.textBook);
            string expected = $"{this.textBook.Title} is returned to the library.";

            Assert.That(expected, Is.EqualTo(this.library.ReturnTextBook(bookNum)));
            Assert.IsEmpty(this.textBook.Holder);
        }
    }
}