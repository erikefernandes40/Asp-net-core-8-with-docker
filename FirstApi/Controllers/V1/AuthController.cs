using Asp.Versioning;
using FirstApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers.V1
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "teste" && password == "teste")
            {
                string name = username;
                int age = 10;
                string photo = "teste";

                var token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee(name, age, photo));

                return Ok(token);
            }

            return BadRequest("Username or password invalid");
        }
    }
}
