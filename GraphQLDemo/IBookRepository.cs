public interface IBookRepository
{
    Task<List<Book>> GetBooks();
    Task<Book?> GetBook(int id);
    Task<Book> AddBook(string title, string author);
}
