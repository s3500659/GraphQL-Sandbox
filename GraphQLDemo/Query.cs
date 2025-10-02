public class Query
{
    private readonly IBookRepository _repo;

    public Query(IBookRepository repo)
    {
        _repo = repo;
    }

    public List<Book> GetBooks()
    {
        return _repo.GetBooks();
    }

    public Book GetBook(int id)
    {
        return _repo.GetBook(id);
    }
}
