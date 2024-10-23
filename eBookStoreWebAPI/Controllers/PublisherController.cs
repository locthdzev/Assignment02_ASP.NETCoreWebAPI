using BusinessObject.DTOs;
using DataAccess.Repositories.PublisherRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishersAsync();
            if (!publishers.Any())
            {
                return NotFound("No publishers found.");
            }
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher([FromBody] CreatePublisherDTO createPublisherDTO)
        {
            await _publisherRepository.AddPublisherAsync(createPublisherDTO);
            return Ok(createPublisherDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] UpdatePublisherDTO updatePublisherDTO)
        {
            var existingPublisher = await _publisherRepository.GetPublisherByIdAsync(id);
            if (existingPublisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }

            await _publisherRepository.UpdatePublisherAsync(id, updatePublisherDTO);
            return Ok(updatePublisherDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var existingPublisher = await _publisherRepository.GetPublisherByIdAsync(id);
            if (existingPublisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }

            await _publisherRepository.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}
