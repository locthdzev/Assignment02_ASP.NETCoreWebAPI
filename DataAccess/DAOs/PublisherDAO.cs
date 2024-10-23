using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAOs
{
    public class PublisherDAO
    {
        private readonly MyDbContext _context;

        public PublisherDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublishersAsync()
        {
            return await _context.Publishers
                .Select(p => new PublisherDTO
                {
                    pub_id = p.pub_id,
                    publisher_name = p.publisher_name,
                    city = p.city,
                    state = p.state,
                    country = p.country
                })
                .ToListAsync();
        }

        public async Task<PublisherDTO?> GetPublisherByIdAsync(int id)
        {
            return await _context.Publishers
                .Where(p => p.pub_id == id)
                .Select(p => new PublisherDTO
                {
                    pub_id = p.pub_id,
                    publisher_name = p.publisher_name,
                    city = p.city,
                    state = p.state,
                    country = p.country
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddPublisherAsync(CreatePublisherDTO createPublisherDTO)
        {
            var publisher = new Publisher
            {
                publisher_name = createPublisherDTO.publisher_name,
                city = createPublisherDTO.city,
                state = createPublisherDTO.state,
                country = createPublisherDTO.country
            };

            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePublisherAsync(int id, UpdatePublisherDTO updatePublisherDTO)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) return;

            publisher.publisher_name = updatePublisherDTO.publisher_name;
            publisher.city = updatePublisherDTO.city;
            publisher.state = updatePublisherDTO.state;
            publisher.country = updatePublisherDTO.country;

            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePublisherAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) return;

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}
