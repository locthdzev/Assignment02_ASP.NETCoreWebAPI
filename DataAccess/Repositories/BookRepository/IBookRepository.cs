using BusinessObject.DTOs;

namespace DataAccess.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task AddBookAsync(CreateBookDTO createBookDTO);
        Task UpdateBookAsync(int id, UpdateBookDTO updateBookDTO);
        Task DeleteBookAsync(int id);
    }
}