using FirstApi.Domain.Model.CompanyAggregate;
using FirstApi.Domain.Model.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Host=postgres;Port=5432;Database=employee_sample;Username=postgres;Password=postgres";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
