using FirstApi.Model;
using FirstApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("api/vi/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpPost]

        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, null);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var emplyess = _employeeRepository.Get();
            return Ok(emplyess);
        }
    }
}
