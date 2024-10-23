using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAOs
{
    public class AuthorDAO
    {
        private readonly MyDbContext _context;

        public AuthorDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Select(a => new AuthorDTO
                {
                    author_id = a.author_id,
                    last_name = a.last_name,
                    first_name = a.first_name,
                    phone = a.phone,
                    address = a.address,
                    city = a.city,
                    state = a.state,
                    zip = a.zip,
                    email_address = a.email_address
                })
                .ToListAsync();
        }

        public async Task<AuthorDTO?> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Where(a => a.author_id == id)
                .Select(a => new AuthorDTO
                {
                    author_id = a.author_id,
                    last_name = a.last_name,
                    first_name = a.first_name,
                    phone = a.phone,
                    address = a.address,
                    city = a.city,
                    state = a.state,
                    zip = a.zip,
                    email_address = a.email_address
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAuthorAsync(CreateAuthorDTO createAuthorDTO)
        {
            var author = new Author
            {
                last_name = createAuthorDTO.last_name,
                first_name = createAuthorDTO.first_name,
                phone = createAuthorDTO.phone,
                address = createAuthorDTO.address,
                city = createAuthorDTO.city,
                state = createAuthorDTO.state,
                zip = createAuthorDTO.zip,
                email_address = createAuthorDTO.email_address
            };

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return;

            author.last_name = updateAuthorDTO.last_name;
            author.first_name = updateAuthorDTO.first_name;
            author.phone = updateAuthorDTO.phone;
            author.address = updateAuthorDTO.address;
            author.city = updateAuthorDTO.city;
            author.state = updateAuthorDTO.state;
            author.zip = updateAuthorDTO.zip;
            author.email_address = updateAuthorDTO.email_address;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
