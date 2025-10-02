public interface IBookRepository
{
    List<Book> GetBooks();
    Book GetBook(int id);
    Book AddBook(string title, string author);
}
