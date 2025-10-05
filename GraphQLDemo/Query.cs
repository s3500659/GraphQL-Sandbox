public class Query
{
    private readonly IBookRepository _repo;

    public Query(IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _repo.GetBooks();
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _repo.GetBook(id);
    }
}