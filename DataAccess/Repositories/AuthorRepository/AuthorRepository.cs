using BusinessObject.DTOs;
using DataAccess.DAOs;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDAO _authorDAO;

        public AuthorRepository(AuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }

        public Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
        {
            return _authorDAO.GetAllAuthorsAsync();
        }

        public Task<AuthorDTO> GetAuthorByIdAsync(int id)
        {
            return _authorDAO.GetAuthorByIdAsync(id);
        }

        public Task AddAuthorAsync(CreateAuthorDTO createAuthorDTO)
        {
            return _authorDAO.AddAuthorAsync(createAuthorDTO);
        }

        public Task UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            return _authorDAO.UpdateAuthorAsync(id, updateAuthorDTO);
        }

        public Task DeleteAuthorAsync(int id)
        {
            return _authorDAO.DeleteAuthorAsync(id);
        }
    }
}
