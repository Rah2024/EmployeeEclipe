#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeEclipe.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Display(Name ="Emplyee Name")]
    public string FullName { get; set; }
    [Display(Name = "Emplyee Father Name")]
    public string FatherName { get; set; }
    [Display(Name = "Emplyee Mother Name")]
    public string MotherName { get; set; }
    [Display(Name = "Emplyee Date of birth")]
    public DateTime DateOfBirth { get; set; }
    [Display(Name = "Emplyee Date of joining")]
    public DateTime DateOfjoining { get; set; }
    [Display(Name = "Emplyee Department")]
    public int Department {  get; set; }
    [Display(Name = "Emplyee Designation")]
    public string Designation {  get; set; }
    [Display(Name = "Emplyee Salary")]
    public string Salary { get; set; }
    [Display(Name = "Emplyee Office Id")]
    public string OfficeId { get; set; }    
}

