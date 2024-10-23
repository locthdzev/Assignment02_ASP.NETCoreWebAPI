using BusinessObject.DTOs;
using DataAccess.DAOs;

namespace DataAccess.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return _userDAO.GetAllUsersAsync();
        }

        public Task<UserDTO> GetUserByIdAsync(int id)
        {
            return _userDAO.GetUserByIdAsync(id);
        }

        public Task AddUserAsync(CreateUserDTO createUserDTO)
        {
            return _userDAO.AddUserAsync(createUserDTO);
        }

        public Task UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            return _userDAO.UpdateUserAsync(id, updateUserDTO);
        }

        public Task DeleteUserAsync(int id)
        {
            return _userDAO.DeleteUserAsync(id);
        }

        public Task<IEnumerable<RoleDTO>> GetAlllRolesAsync()
        {
            return _userDAO.GetAllRolesAsync();
        }
    }
}
