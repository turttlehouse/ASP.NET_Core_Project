using System.ComponentModel.DataAnnotations;

namespace EFCoreCRUD_operations.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public int salary { get; set; }
    }
}
