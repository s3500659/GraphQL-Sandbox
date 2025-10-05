using GraphQLDemo;
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
        var newBook = new Book
        {
            Title = title,
            Author = new Author { Name = author }
        };

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
        return newBook;
    }

    public async Task<Book> GetBook(int id)
    {
        return await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _context.Books
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task<Book> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return book;
    }
}
