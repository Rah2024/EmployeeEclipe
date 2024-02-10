#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EmployeeEclipe.Models
{
    public class ChatRecord
    {
        [Key]
        public int Id { get; set; }
        public string UserMessage { get; set; } 
        public DateTime MessageDateTime { get; set; } 
        public string EmployeeId { get; set; }  
        public string HrId { get; set; }    

        public string HRReplay { get; set; }  
        
        public string Role { get; set; }    
    }
}
