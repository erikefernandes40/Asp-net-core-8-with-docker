using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Domain.Model.EmployeeAggregate
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }
        public string password { get; private set; }
        public string email {  get; private set; }

        public Employee(string name, int age, string photo, string password, string email)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
            this.password = password;
            this.email = email;
        }

    }
}
