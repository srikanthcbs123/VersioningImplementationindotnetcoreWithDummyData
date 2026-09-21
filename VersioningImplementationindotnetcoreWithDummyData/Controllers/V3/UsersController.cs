using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersioningImplementationindotnetcoreWithDummyData.Controllers.V3
{
   
    [ApiController]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(new[]
                {
        new { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com" }
          });
        }
    }
}
