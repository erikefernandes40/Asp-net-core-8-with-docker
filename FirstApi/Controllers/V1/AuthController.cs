using Asp.Versioning;
using FirstApi.Application.Services;
using FirstApi.Domain.Model.EmployeeAggregate;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers.V1
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AuthController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]
        public IActionResult Auth(string email, string password)

        {
            var employeeExists = _employeeRepository.GetByEmail(email);

            if(employeeExists == null || employeeExists.password != password)
            {
                return BadRequest("Username or password invalid");
            }

                var token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee(employeeExists.name, employeeExists.age, employeeExists?.photo, employeeExists.password, employeeExists.email));

                return Ok(token);
        }
    }
}
