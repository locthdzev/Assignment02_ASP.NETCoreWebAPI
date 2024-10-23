using BusinessObject.DTOs;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(CreateUserDTO createUserDTO);
        Task UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<RoleDTO>> GetAlllRolesAsync();
    }
}