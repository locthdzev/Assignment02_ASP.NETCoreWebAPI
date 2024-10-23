using BusinessObject.DTOs;

namespace DataAccess.Repositories.PublisherRepository
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<PublisherDTO>> GetAllPublishersAsync();
        Task<PublisherDTO> GetPublisherByIdAsync(int id);
        Task AddPublisherAsync(CreatePublisherDTO createPublisherDTO);
        Task UpdatePublisherAsync(int id, UpdatePublisherDTO updatePublisherDTO);
        Task DeletePublisherAsync(int id);
    }
}