using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersioningImplementationindotnetcoreWithDummyData.Controllers.V1
{
  
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(new[]
                {
        new { Id = 1, FirstName = "Alice"}
          });
        }
    }
}
/*
 * API Versioning in .NET Core is a technique used to update your API without breaking existing mobile apps or web applications.

we can  run multiple versions of the same endpoint (like v1 and v2) at the same time.


 The main reasons to using this one is:Legacy clients continue using v1 while new clients migrate to v2.



We canimplement API versioning in .NET Core using three main approaches:
1. URL Route (Most Popular):  GET /api/v1/users
2. Query Parameter:           GET /api/users?api-version=1.0
3. Request Header:            GET /api/users  [Header: X-Version = 1.0]
=====================Realtime mainly used route based versioning in .NET 8.0===
To implement Route based  versioning   we need to fallow below steps

Install  the below Packages
 Asp.Versioning.Mvc --version 8.*
 Asp.Versioning.Mvc.ApiExplorer --version 8.*
------------------------------
next  Configure  APi versioning in Program.cs
In .NET 8, chaining AddApiExplorer() on AddApiVersioning() enables automatic route integration and version format standardisation.

using Asp.Versioning;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
------------------------------
// Configure .NET 8 API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true; // Adds 'api-supported-versions' headers
    
    // Reads version from URL route (/api/v1/...)
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // Formats version group as 'v1', 'v2'
    options.SubstituteApiVersionInUrl = true;
});
--------------------------------

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
3. Define Versioned Controllers
Create separate folders (e.g., /Controllers/V1/ and /Controllers/V2/) to keep versions cleanly based on version wise.
V1/UsersController.cs
C#
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
namespace MyApi.Controllers.V1;
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new[] { new { Id = 1, Name = "Alice Smith" } });
}
V2/UsersController.cs
C#
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
namespace MyApi.Controllers.V2;
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new[] { new { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com" } });
}

 */