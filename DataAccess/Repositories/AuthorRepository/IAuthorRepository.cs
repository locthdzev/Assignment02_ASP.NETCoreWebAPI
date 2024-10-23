using BusinessObject.DTOs;

namespace DataAccess.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
        Task<AuthorDTO> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(CreateAuthorDTO createAuthorDTO);
        Task UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO);
        Task DeleteAuthorAsync(int id);
    }
}