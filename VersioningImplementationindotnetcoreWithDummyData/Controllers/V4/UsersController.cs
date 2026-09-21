using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;//need to import this package
namespace VersioningImplementationindotnetcoreWithDummyData.Controllers.V4
{

    [ApiController]
    [ApiVersion("4.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(new[]
                {
      new { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com",Role="admin" }
          });
        }

    }

}
