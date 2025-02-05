namespace Assignment03Adv
{
    public delegate string BookFunctionDelegate(Book B);

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book("123456789", "C# Advanced", new string[] { "Eng. Aliaa Tarek" }, new DateTime(2025, 1, 30),
                    1000),
                new Book("987654321", "C# Basics", new string[] { "Eng. Khaled Ahmed" }, new DateTime(2025, 1, 30),
                    500),
            };


            #region a. User Defined Delegate Datatype

            BookFunctionDelegate titleDelegate = new BookFunctionDelegate(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(books, titleDelegate);

            #endregion

            #region b. BCL Delegates

            Func<Book, string> authorDelegate = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(books, new BookFunctionDelegate(authorDelegate));

            #endregion

            #region c. Anonymous Method (GetISBN)

            BookFunctionDelegate isbnDelegate = delegate(Book b) { return b.ISBN; };
            LibraryEngine.ProcessBooks(books, isbnDelegate);
            
            
            #endregion

            #region d. Lambda Expression (GetPublicationDate)
            
            BookFunctionDelegate GetPublicationDate = B => B.PublicationDate.ToString("yyyy-MM-dd");
            LibraryEngine.ProcessBooks(books, GetPublicationDate);
            
            #endregion
        }
    }
}