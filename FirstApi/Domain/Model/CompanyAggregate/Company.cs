using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Domain.Model.CompanyAggregate
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Company(string name)
        {
            this.Name = name;
        }


    }
}
