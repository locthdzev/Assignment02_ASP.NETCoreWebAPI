using BusinessObject.DTOs;
using DataAccess.DAOs;

namespace DataAccess.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDAO _bookDAO;

        public BookRepository(BookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return _bookDAO.GetAllBooksAsync();
        }

        public Task<BookDTO> GetBookByIdAsync(int id)
        {
            return _bookDAO.GetBookByIdAsync(id);
        }

        public Task AddBookAsync(CreateBookDTO createBookDTO)
        {
            return _bookDAO.AddBookAsync(createBookDTO);
        }

        public Task UpdateBookAsync(int id, UpdateBookDTO updateBookDTO)
        {
            return _bookDAO.UpdateBookAsync(id, updateBookDTO);
        }

        public Task DeleteBookAsync(int id)
        {
            return _bookDAO.DeleteBookAsync(id);
        }
    }
}
