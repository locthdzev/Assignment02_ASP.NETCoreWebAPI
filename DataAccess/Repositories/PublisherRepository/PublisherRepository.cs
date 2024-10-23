using BusinessObject.DTOs;
using DataAccess.DAOs;

namespace DataAccess.Repositories.PublisherRepository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly PublisherDAO _publisherDAO;

        public PublisherRepository(PublisherDAO publisherDAO)
        {
            _publisherDAO = publisherDAO;
        }

        public Task<IEnumerable<PublisherDTO>> GetAllPublishersAsync()
        {
            return _publisherDAO.GetAllPublishersAsync();
        }

        public Task<PublisherDTO> GetPublisherByIdAsync(int id)
        {
            return _publisherDAO.GetPublisherByIdAsync(id);
        }

        public Task AddPublisherAsync(CreatePublisherDTO createPublisherDTO)
        {
            return _publisherDAO.AddPublisherAsync(createPublisherDTO);
        }

        public Task UpdatePublisherAsync(int id, UpdatePublisherDTO updatePublisherDTO)
        {
            return _publisherDAO.UpdatePublisherAsync(id, updatePublisherDTO);
        }

        public Task DeletePublisherAsync(int id)
        {
            return _publisherDAO.DeletePublisherAsync(id);
        }
    }
}
