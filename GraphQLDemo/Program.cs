var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();


public record Book(int Id, string Title, string Author);

public static class BookLibrary
{
    public static int NumberOfBooks { get; set; } = 0;
    public static List<Book> Books { get; set; } = new List<Book>()
    {
        new Book(++NumberOfBooks, "The Hobbit", "J.R.R. Tolkien"),
        new Book(++NumberOfBooks, "1984", "George Orwell")
    };

    public static Book AddBook(string title, string author)
    {
        var newBook = new Book(++NumberOfBooks, title, author);
        Books.Add(newBook);
        return newBook;
    }
}

public class Query
{
    public List<Book> GetBooks() => BookLibrary.Books;
    public Book GetBook(int id)
    {
        return BookLibrary.Books.First(x => x.Id == id);
    }
}

public class Mutation
{
    public Book AddBook(string title, string author)
    {
        return BookLibrary.AddBook(title, author);
    }
}
