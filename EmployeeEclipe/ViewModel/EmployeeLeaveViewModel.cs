#nullable disable
namespace EmployeeEclipe.ViewModel
{
    public class EmployeeLeaveViewModel
    {
        public int LeaveId { get; set; }    
        public string LeaveName { get; set; }   
        public string LeaveDate { get; set; }   
        public string AlreadyTakenLeave { get; set; }   
        public string RemainLeave { get; set; } 

        public string EmployeeName { get; set; }  
        
        public string TotalLeave { get; set; }  

        public string LeaveStatus { get; set; } 

        public string LoginUserId {  get; set; }
    }

}
