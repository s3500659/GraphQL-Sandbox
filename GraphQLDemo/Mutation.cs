public class Mutation
{
    private readonly IBookRepository _bookLibrary;

    public Mutation(IBookRepository bookLibrary)
    {
        _bookLibrary = bookLibrary;
    }
    public Book AddBook(string title, string author)
    {
        return _bookLibrary.AddBook(title, author);
    }
}
