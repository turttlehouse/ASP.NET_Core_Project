using System.ComponentModel.DataAnnotations;

namespace EFCoreCRUD_operations.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int salary { get; set; }
    }
}
