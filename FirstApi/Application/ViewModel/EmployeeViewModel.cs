namespace FirstApi.Application.ViewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
