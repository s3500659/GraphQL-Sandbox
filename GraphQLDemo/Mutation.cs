using GraphQLDemo;

public class Mutation
{
    private readonly IBookRepository _bookLibrary;

    public Mutation(IBookRepository bookLibrary)
    {
        _bookLibrary = bookLibrary;
    }

    public async Task<Book> AddBook(string title, string author)
    {
        return await _bookLibrary.AddBook(title, author);
    }
}