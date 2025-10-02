var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddSingleton<IBookLibrary, BookLibrary>();

var app = builder.Build();

app.MapGraphQL();

app.Run();


public record Book(int Id, string Title, string Author);



public interface IBookLibrary
{
    int NumberOfBooks { get; set; }
    List<Book> Books { get; set; }
    Book AddBook(string title, string author);
}


public class BookLibrary : IBookLibrary
{
    public int NumberOfBooks { get; set; } = 0;
    public List<Book> Books { get; set; } = new List<Book>();

    public BookLibrary()
    {
        Books.Add(new Book(++NumberOfBooks, "The Hobbit", "J.R.R. Tolkien"));
        Books.Add(new Book(++NumberOfBooks, "1984", "George Orwell"));
    }

    public Book AddBook(string title, string author)
    {
        var newBook = new Book(++NumberOfBooks, title, author);
        Books.Add(newBook);
        return newBook;
    }
}

public interface IQuery
{
    List<Book> GetBooks();
    Book GetBook(int id);
}

public class Query : IQuery
{
    private readonly IBookLibrary _bookLibrary;

    public Query(IBookLibrary bookLibrary)
    {
        _bookLibrary = bookLibrary;
    }

    public List<Book> GetBooks() => _bookLibrary.Books;
    public Book GetBook(int id)
    {
        return _bookLibrary.Books.First(x => x.Id == id);
    }
}

public class Mutation
{
    private readonly IBookLibrary _bookLibrary;

    public Mutation(IBookLibrary bookLibrary)
    {
        _bookLibrary = bookLibrary;
    }
    public Book AddBook(string title, string author)
    {
        return _bookLibrary.AddBook(title, author);
    }
}
