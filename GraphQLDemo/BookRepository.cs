using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Book> AddBook(string title, string author)
    {
        var newBook = new Book(0, title, author);
        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
        return newBook;
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }
}
