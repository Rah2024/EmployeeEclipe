#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EmployeeEclipe.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Department Name")]
        [Required]
        public string Name { get; set; }    
    }
}
