using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAOs
{
    public class UserDAO
    {
        private readonly MyDbContext _context;

        public UserDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDTO
                {
                    user_id = u.user_id,
                    email_address = u.email_address,
                    source = u.source,
                    first_name = u.first_name,
                    middle_name = u.middle_name,
                    last_name = u.last_name,
                    role_desc = u.Role.role_desc,
                    publisher_name = u.Publisher.publisher_name,
                    hire_date = u.hire_date
                })
                .ToListAsync();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.user_id == id)
                .Select(u => new UserDTO
                {
                    user_id = u.user_id,
                    email_address = u.email_address,
                    source = u.source,
                    first_name = u.first_name,
                    middle_name = u.middle_name,
                    last_name = u.last_name,
                    role_desc = u.Role.role_desc,
                    publisher_name = u.Publisher.publisher_name,
                    hire_date = u.hire_date
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(CreateUserDTO createUserDTO)
        {
            var user = new User
            {
                email_address = createUserDTO.email_address,
                password = createUserDTO.password,
                source = createUserDTO.source,
                first_name = createUserDTO.first_name,
                middle_name = createUserDTO.middle_name,
                last_name = createUserDTO.last_name,
                role_id = createUserDTO.role_id,
                pub_id = createUserDTO.pub_id,
                hire_date = createUserDTO.hire_date
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            user.email_address = updateUserDTO.email_address;
            user.password = updateUserDTO.password;
            user.source = updateUserDTO.source;
            user.first_name = updateUserDTO.first_name;
            user.middle_name = updateUserDTO.middle_name;
            user.last_name = updateUserDTO.last_name;
            user.role_id = updateUserDTO.role_id;
            user.pub_id = updateUserDTO.pub_id;
            user.hire_date = updateUserDTO.hire_date;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Select(r => new RoleDTO
                {
                    role_id = r.role_id,
                    role_desc = r.role_desc
                })
                .ToListAsync();
        }
    }
}
