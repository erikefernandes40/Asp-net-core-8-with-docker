using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers.V2
{
    [ApiVersion(2.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    public class EmployeeController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("employee v2");
        }
    }
}
