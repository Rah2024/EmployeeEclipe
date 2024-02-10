using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace EmployeeEclipe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var LoginUser = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(LoginUser);

            if (LoginUser == null)
            {
                return RedirectToAction("/Identity/Account/Login");
            }
            else if(roles.Contains("HRAdmin"))
            {
                return RedirectToAction("Dashborad", "Departments");

            }
            else if (roles.Contains("Employee"))
            {
                return RedirectToAction("Dashborad", "Employee");
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
