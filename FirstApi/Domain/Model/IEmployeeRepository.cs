using FirstApi.Domain.DTOs;

namespace FirstApi.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDto> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
