using BusinessObject.DTOs;
using DataAccess.Repositories.AuthorRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            if (!authors.Any())
            {
                return NotFound("No authors found.");
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            await _authorRepository.AddAuthorAsync(createAuthorDTO);
            return Ok(createAuthorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDTO updateAuthorDTO)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }

            await _authorRepository.UpdateAuthorAsync(id, updateAuthorDTO);
            return Ok(updateAuthorDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }

            await _authorRepository.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
