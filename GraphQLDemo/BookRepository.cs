public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public Book AddBook(string title, string author)
    {
        var newBook = new Book(0, title, author);
        _context.Books.Add(newBook);
        _context.SaveChanges();
        return newBook;
    }

    public Book GetBook(int id)
    {
        return _context.Books.First(x => x.Id == id);
    }

    public List<Book> GetBooks()
    {
        return _context.Books.ToList();
    }
}
