using FirstApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FirstApi.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Host=postgres;Port=5432;Database=employee_sample;Username=postgres;Password=postgres";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
