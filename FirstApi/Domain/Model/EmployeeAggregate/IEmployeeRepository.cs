using FirstApi.Domain.DTOs;

namespace FirstApi.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDto> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
        Employee GetByEmail(string email);
    }
}
