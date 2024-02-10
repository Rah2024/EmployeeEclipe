#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEclipe.Models
{
    public class EmplyeeLeaveRecord
    {
        [Key]
        public int Id { get; set;}
        [Display(Name ="Already taken Leave")]
        public string TakeLeave { get; set;}    
        public string EmplyeeId { get; set;}    
        public int LeaveId { get; set;}
        [ForeignKey("LeaveId")]
        public EmployeLeave EmployeLeave { get; set;}   
        public string LeaveStatus { get; set;}  

        public string LeaveDate { get; set;}  
    }
}
