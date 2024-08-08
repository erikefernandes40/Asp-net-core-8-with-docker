using AutoMapper;
using FirstApi.Domain.DTOs;
using FirstApi.Domain.Model.EmployeeAggregate;

namespace FirstApi.Application.Mapping
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping() 
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
