using EmployeeEclipe.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeEclipe.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public ChatController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;   
        }
        //Employee Reply
        public IActionResult EmployeeChat()
        {
            ViewBag.userid = _userManager.GetUserId(User);
            ViewBag.Role = "User";
            ViewBag.HRAdminId = _context.Users.Where(x => x.UserName == "HRAdmin123@gmail.com").Select(x => x.Id).FirstOrDefault();
                     
            return View();
        }
        public IActionResult UserMessage()
        {
            string userId = _userManager.GetUserId(User);
            var obj = _context.ChatRecords.Where(x => x.EmployeeId == userId).ToList();
            return new JsonResult(obj);
        }

        //HR Reply
        public IActionResult Reply(string Reply)
        {
            ViewBag.employeeId = Reply;
            ViewBag.userid = Reply;
            ViewBag.Role = "Admin";
            ViewBag.HRAdminId = _context.Users.Where(x => x.UserName == "HRAdmin123@gmail.com").Select(x => x.Id).FirstOrDefault();
            return View();
        }
        public IActionResult ReplyUserMessage(string EmployeeId )
        {
            var obj = _context.ChatRecords.Where(x => x.EmployeeId == EmployeeId).ToList();
            return new JsonResult(obj);
        }
    }
}
