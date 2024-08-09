using AutoMapper;
using FirstApi.Application.ViewModel;
using FirstApi.Domain.DTOs;
using FirstApi.Domain.Model.EmployeeAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace FirstApi.Controllers.V1
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath, employeeView.Password, employeeView.Email);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var emplyess = _employeeRepository.Get(pageNumber, pageQuantity);
            return Ok(emplyess);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            if (employee?.photo == null)
            {
                return new NotFoundObjectResult("User photo not found");
            }

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.Get(id);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }
    }
}
