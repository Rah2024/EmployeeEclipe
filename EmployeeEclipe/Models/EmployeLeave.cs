#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EmployeeEclipe.Models
{
    public class EmployeLeave
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Leave Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Leave in year allow")]
        [Required]
        public string LeaveInYear { get; set; } 
    }
}
