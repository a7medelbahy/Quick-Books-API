using Microsoft.EntityFrameworkCore;
using Quick_Books.Models;

namespace Quick_Books.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly QuickBooksDbContext _context;

        public BookRepository(QuickBooksDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync(string? searchTitle, Genre? genre)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrWhiteSpace(searchTitle))
            {
                query = query.Where(b => b.Title.Contains(searchTitle));
            }

            if (genre.HasValue)
            {
                query = query.Where(b => b.Genre == genre.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
