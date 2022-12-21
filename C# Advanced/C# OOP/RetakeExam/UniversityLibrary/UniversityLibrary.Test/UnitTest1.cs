namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Text;

    public class Tests
    {
        private TextBook Book;
        private string tit = "ProgrammingBasicsC#";
        private string aut = "Slavova";
        private string cat = "Programming";
        private UniversityLibrary uLibrary;


        [SetUp]
        public void Setup()
        {
            uLibrary = new UniversityLibrary();
            Book = new TextBook(tit, aut, cat);
        }


        [Test]
        public void TextBookConstructorShouldWork()
        {
            Assert.AreEqual(tit, Book.Title);
            Assert.AreEqual(aut, Book.Author);
            Assert.AreEqual(cat, Book.Category);
        }
        [Test]
        public void LibraryConstructorShouldWork()
        {
            List<TextBook> Books = new List<TextBook>();
            CollectionAssert.AreEqual(Books, uLibrary.Catalogue);
        }
        [Test]
        public void AddTextbookShouldWork()
        {
            string exp = uLibrary.AddTextBookToLibrary(Book);
            Assert.AreEqual(1, Book.InventoryNumber);

            List<TextBook> Books = new List<TextBook>() { Book };
            CollectionAssert.AreEqual(Books, uLibrary.Catalogue);

            StringBuilder res = new StringBuilder();
            res.AppendLine($"Book: {Book.Title} - {Book.InventoryNumber}");
            res.AppendLine($"Category: {Book.Category}");
            res.AppendLine($"Author: {Book.Author}");
            Assert.AreEqual(res.ToString().Trim(), exp);
        }
        [Test]
        public void ReturnBookShouldWork()
        {
            string name = "Ico";
            Book.Holder = name;
            Assert.AreEqual(name, Book.Holder);

            uLibrary.AddTextBookToLibrary(Book);
            string exp = uLibrary.ReturnTextBook(1);
            string res = $"{Book.Title} is returned to the library.";
            Assert.AreEqual(string.Empty, Book.Holder);
            Assert.AreEqual(res, exp);
        }
        [Test]
        public void LoanTextbookShouldWork()
        {
            uLibrary.AddTextBookToLibrary(Book);
            string name = "Ico";
            string exp = uLibrary.LoanTextBook(1, name);
            string res = $"{Book.Title} loaned to {name}.";

            Assert.AreEqual(name, Book.Holder);
            Assert.AreEqual(res, exp);
        }
        [Test]
        public void LoanTextbookSamePerson()
        {
            uLibrary.AddTextBookToLibrary(Book);
            string name = "Ico";
            Book.Holder = name;

            string exp = uLibrary.LoanTextBook(1, name);
            string res = $"{name} still hasn't returned {Book.Title}!";
            Assert.AreEqual(res, exp);
        }

    }
}