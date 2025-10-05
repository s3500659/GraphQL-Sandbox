using GraphQLDemo;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J.R.R. Tolkien" },
            new Author { Id = 2, Name = "George Orwell" },
            new Author { Id = 3, Name = "Harper Lee" },
            new Author { Id = 4, Name = "F. Scott Fitzgerald" },
            new Author { Id = 5, Name = "Jane Austen" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Hobbit", AuthorId = 1 },
            new Book { Id = 2, Title = "1984", AuthorId = 2 },
            new Book { Id = 3, Title = "To Kill a Mockingbird", AuthorId = 3 },
            new Book { Id = 4, Title = "The Great Gatsby", AuthorId = 4 },
            new Book { Id = 5, Title = "Pride and Prejudice", AuthorId = 5 }
        );

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
