using DataAccess.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RoleController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _userRepository.GetAlllRolesAsync();
            if (!roles.Any())
            {
                return NotFound("No roles found.");
            }
            return Ok(roles);
        }
    }
}