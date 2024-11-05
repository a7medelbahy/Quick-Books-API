using Quick_Books.Models;

namespace Quick_Books.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(string? searchTitle, Genre? genre);
        Task<Book> GetBookByIdAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task SaveChangesAsync();
    }
}
