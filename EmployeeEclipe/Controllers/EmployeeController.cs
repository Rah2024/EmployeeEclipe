using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.FactoryDesign;
using EmployeeEclipe.Models;
using EmployeeEclipe.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEclipe.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitofWork _UnitofWork;

        public EmployeeController( UserManager<ApplicationUser> userManager, IUnitofWork unitofWork)
        {
            _userManager = userManager;
            _UnitofWork= unitofWork;
        }

        public IActionResult Dashborad()
        {
            return View();
        }
        public IActionResult NoticeBorad()
        {
            var obj = _UnitofWork.Employe.NoticBoradsList();
            return View(obj);
        }

        public IActionResult LeaveType()
        {
            var obj = _UnitofWork.Employe.EmployeLeaveList();
            return View(obj);
        }
        public IActionResult EmployeeLeave()
        {
            string userid = _userManager.GetUserId(User);
            var obj = _UnitofWork.Employe.EmployeeLeaveRecordList().Where(x=>x.LoginUserId==userid).ToList();                    
            return View(obj);  
        }

        public IActionResult AddLeave()
        {
            ViewBag.LeaveType = new SelectList(_UnitofWork.Employe.GetAll(),"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddLeave(EmployeeLeaveViewModel employee)
        {
            string userid= _userManager.GetUserId(User);
            var record = new EmplyeeLeaveRecord
            {
                TakeLeave = employee.LeaveName,
                LeaveStatus = "Pending",
                EmplyeeId=userid,
                LeaveDate=employee.LeaveDate,
                LeaveId=employee.LeaveId,

            };
            _UnitofWork.Employe.AddLeaveRecord(record);
            _UnitofWork.save();
            return RedirectToAction("EmployeeLeave");
        }
        public IActionResult Salary()
        {
            string userid = _userManager.GetUserId(User);
            var obj= _UnitofWork.Employe.EmployeeSalary().Where(x => x.LoginUser == userid).ToList();
            return View(obj);
        }
        public IActionResult TestingMessage()
        {
            return View();
        }
    }
}
