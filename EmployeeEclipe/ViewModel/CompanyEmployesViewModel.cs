#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EmployeeEclipe.ViewModel
{
    public class CompanyEmployesViewModel
    {
        public string EmployeeId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long. Password need to contain special and uppercase letters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Emplyee Name")]
        [Required]

        public string FullName { get; set; }
        [Display(Name = "Emplyee Father Name")]
        [Required]

        public string FatherName { get; set; }
        [Display(Name = "Emplyee Mother Name")]
        [Required]

        public string MotherName { get; set; }
        [Display(Name = "Emplyee Date of birth")]
        [Required]

        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Emplyee Date of joining")]
        [Required]

        public DateTime DateOfjoining { get; set; }
        [Display(Name = "Emplyee Department")]
        [Required]

        public int Department { get; set; }
        [Display(Name = "Emplyee Designation")]
        [Required]
        public string Designation { get; set; }
        [Display(Name = "Emplyee Salary")]
        [Required]
        public string Salary { get; set; }
        [Display(Name = "Emplyee Office Id")]
        [Required]
        public string EmployeeOfficeId { get; set; }
        public string DepartmentName { get; set; }
        [Display(Name = "Emplyee Phone")]

        public string EmployeePhone { get;set; }

    }
}
