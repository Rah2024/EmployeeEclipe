using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace EmployeeEclipe.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;
        public ChatHub(ApplicationDbContext context, UserManager<ApplicationUser> userManager )
        {
            _context = context;
            _UserManager = userManager;
        }

        public async Task SendMessage(string user, string message, string HrId, string Role)
        {
            InsertData(user, message, HrId, Role);
            await Clients.All.SendAsync("InsertMessage", user, message, HrId, Role);
        }
        public void InsertData(string userId, string message, string HrId, string Role)
        {
            
            if(Role == "User")
            {
                ChatRecord userMessages = new ChatRecord
                {
                    UserMessage = message,
                    MessageDateTime = System.DateTime.Now,
                    EmployeeId = userId,
                    HrId = HrId,
                    Role = Role
                };
                _context.ChatRecords.Add(userMessages);
                _context.SaveChanges();
            }
            else if (Role == "Admin")
            {
                ChatRecord userMessages = new ChatRecord
                {
                    HRReplay = message,
                    MessageDateTime = System.DateTime.Now,
                    EmployeeId = userId,
                    HrId = HrId,
                    Role = Role
                };
                _context.ChatRecords.Add(userMessages);
                _context.SaveChanges();
            }
                       
            }                             
    }
}
