using GraphQLDemo;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();
    Task<Book> GetBook(int id);
    Task<Book> AddBook(string title, string author);
    Task<Book> DeleteBookAsync(int id);
}
