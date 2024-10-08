﻿using FirstApi.Domain.DTOs;
using FirstApi.Domain.Model.EmployeeAggregate;

namespace FirstApi.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetByEmail(string email)
        {
            return _context.Employees.FirstOrDefault(e => e.email == email);
        }

        public List<EmployeeDto> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).Select(b => 
            new EmployeeDto()
            {
                Id = b.id,
                Name = b.name,
                Photo = b.photo,
            }
            ).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
