using BusinessObject.DTOs;
using DataAccess.Repositories.BookRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if (!books.Any())
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookDTO createBookDTO)
        {
            await _bookRepository.AddBookAsync(createBookDTO);
            return Ok(createBookDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDTO updateBookDTO)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            await _bookRepository.UpdateBookAsync(id, updateBookDTO);
            return Ok(updateBookDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
