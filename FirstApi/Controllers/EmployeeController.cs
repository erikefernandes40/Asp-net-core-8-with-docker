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

        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var directoryPath = Path.Combine("Storage");
            var filePath = Path.Combine(directoryPath, employeeView.Photo.FileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

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
