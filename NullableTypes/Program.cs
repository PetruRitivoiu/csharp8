using System.Collections.Generic;

namespace NullableTypes
{
    internal class Book
    {
        public string Name { get; set; } //Warning: Non-nullable property 'Name' is uninitialized

        public string? Author { get; set; } //this reference may be null
    }

    internal class BookIndexer : IBookIndexer
    {
        public string Index(Book book) => $"{book.Name}_{book.Author}";
    }

    internal interface IBookIndexer
    {
        public string Index(Book book);
    }

    internal class BookStore
    {
        //The list will NOT be null and the items in it will NOT be null
        private List<Book> BookList { get; set; }

        //The list is allowed to be null but the items in it are NOT allowed to be null 
        //private List<Book>? bookList2;

        //The list is NOT allowed to be null but the items in it are allowed to be null
        //private List<Book?> bookList3;

        //Both the list and the items in it are allowed to be null (C# 7.0)
        //private List<Book?>? bookList4;

        private IBookIndexer? BookIndexer { set; get; }

        private Dictionary<string, Book> BooksDictionary { get; set; }

        public BookStore(IBookIndexer bookIndexer)
        {
            BookList = new List<Book>();
            BooksDictionary = new Dictionary<string, Book>();

            BookIndexer = bookIndexer;
        }

        public void IndexAllBooks()
        {
            if (BookIndexer != null)
            {
                BookList.ForEach((currentBook) =>
                {
                    BooksDictionary.Add(BookIndexer.Index(currentBook), currentBook);
                });
            }
        }

        public void AddBooks(List<Book> books)
        {
            books.ForEach((currentBook) =>
            {
                books.Add(currentBook);
            });
        }

        #region powerpoint

#nullable disable
        public object MaybeNull() => null; //This could be from a C# 7.0 library
#nullable enable

        public string MaybeNullToString() => MaybeNull().ToString(); //no warning

        public string? MaybeString() => "string";

#nullable safeonly
        public string Test_MaybeString1()
        {
            string maybeNull = MaybeString();
            string maybeNullToString = maybeNull.ToString(); //Warning: Dereference of a possibly null reference

            return maybeNullToString;
        }

#nullable enable
        public string Test_MaybeString2()
        {
            string maybeNull = MaybeString(); //Warning: Converting null literal or possible null value to non-nullable type
            string maybeNullToString = maybeNull.ToString(); //Warning: Dereference of a possibly null reference

            return maybeNullToString;
        }

        #endregion
    }



    class Program
    {
        static void Main(string[] args)
        {
            //BookStore bookStore = new BookStore(null); //add the null forgiving operator
            BookStore bookStore = new BookStore(new BookIndexer());

            List<Book> books = new List<Book>();

            books.Add(new Book() { Name = "The Steppenwolf", Author = "Herman Hesse" });
            books.Add(new Book() { Name = "On the heights of despair", Author = "Emil Cioran" });
            books.Add(new Book() { Name = "Karamazov brothers", Author = "Fyodor Dostoevsky" });

            bookStore.AddBooks(books);

            bookStore.IndexAllBooks();
        }
    }

}


