using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quick_Books.Models;
using Quick_Books.Repositories;

namespace Quick_Books.Controllers
{
    [Authorize]
    [Route("api/books")]
    [ApiController]
    public class BookControler : ControllerBase
    {
        IBookRepository _bookRepository;

        public BookControler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Get Books API
        [HttpGet]
        public async Task<IActionResult> GetAllBooks(string? searchTitle, Genre? genre)
        {
            List<Book> books = await _bookRepository.GetAllAsync(searchTitle, genre);
            return Ok(books);
        }

        // Get Book API
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            Book book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Create Book API
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bookRepository.CreateBookAsync(book);
            await _bookRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // Update Book API
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.PublishedDate = book.PublishedDate;
            await _bookRepository.UpdateBookAsync(existingBook);
            await _bookRepository.SaveChangesAsync();
            return NoContent();
        }

        // Delete Book API
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBookAsync(id);
            await _bookRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
