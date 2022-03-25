namespace Book.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            this.book = new Book("Harry Potter", "Jimmy Turner");
        }

        [Test]
        public void Ctor_Successfully()
        {
            Assert.IsNotNull(this.book);
        }

        [Test]
        public void Ctor_CreatesDictionaryInitialization()
        {
            Assert.IsNotNull(this.book.FootnoteCount);
        }

        [Test]
        [TestCase(null, "Jimmy")]
        [TestCase("", "Turner")]
        public void BookName_ShouldNotBeNullOrEmpty(string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() => this.book = new Book(bookName, author));
        }

        [Test]
        [TestCase("Jimmy", null)]
        [TestCase("Turner", "")]
        public void Author_ShouldNotBeNullOrEmpty(string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() => this.book = new Book(bookName, author));
        }

        [Test]
        public void AddFootnote_AddingSuccessful()
        {
            int expectedCount = 1;
            int footNumber = 1;
            string text = "Note";

            this.book.AddFootnote(footNumber, text);

            Assert.AreEqual(expectedCount, this.book.FootnoteCount);
        }

        [Test]
        public void AddFootNote_FootnoteAlreadyExistsShouldThrowException()
        {
            int footNumber = 1;
            string text = "Note";

            this.book.AddFootnote(footNumber, text);
            Assert.Throws<InvalidOperationException>(() => this.book.AddFootnote(footNumber, text));
        }

        [Test]
        public void FindFootnote_ReturnTextOfFootNoteSuccessfully()
        {
            int footNumber = 1;
            string text = "Hello!";
            this.book.AddFootnote(footNumber, text);

            string returnedText = this.book.FindFootnote(footNumber);

            Assert.AreEqual($"Footnote #1: {text}", returnedText);
        }

        [Test]
        public void FindFootNote_ShouldThrowExceptionIfNotExistSuchNumber()
        {
            Assert.Throws<InvalidOperationException>(() => this.book.FindFootnote(1));
        }

        [Test]
        public void AlterFootNote_ShouldAlterTextSuccessfully()
        {
            int footNumber = 1;
            string text = "Some text!";

            this.book.AddFootnote(footNumber, text);

            string newText = "This is a new text!";

            this.book.AlterFootnote(footNumber, newText);

            string[] result = this.book.FindFootnote(footNumber).Split(": ", StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(result[1], newText);
        }

        [Test]
        public void AlterFootNote_ShouldThrowExceptionIfNumberNotExist()
        {
            string newText = "new text!";
            Assert.Throws<InvalidOperationException>(() => this.book.AlterFootnote(1, newText));
        }
    }
}