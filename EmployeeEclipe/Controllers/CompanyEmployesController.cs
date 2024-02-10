using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.FactoryDesign;
using EmployeeEclipe.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEclipe.Controllers
{
    public class CompanyEmployesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitofWork _UnitofWork;

        public CompanyEmployesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitofWork UnitofWork)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _UnitofWork = UnitofWork;
        }


        public IActionResult EmployeeList()
        {
           var obj = _UnitofWork.CompanyEmploye.CompanyEmployeeList();
            return View(obj);
        }

        public IActionResult AddEmployee()
        {
            ViewBag.Department = new SelectList(_UnitofWork.Departments.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> AddEmployee(CompanyEmployesViewModel company )
        {

            var userEmail = _context.Users.Where(x=>x.Email == company.Email).FirstOrDefault();
            if(userEmail==null)
            {
                var user = new ApplicationUser
                {
                    Email=company.Email,
                    UserName=company.Email,
                    DateOfBirth=company.DateOfBirth,
                    DateOfjoining=company.DateOfjoining,
                    Department= company.Department,
                    Designation=company.Designation,
                    FatherName=company.FatherName,
                    MotherName=company.MotherName,
                    FullName=company.FullName,
                    OfficeId=company.EmployeeOfficeId,
                    Salary=company.Salary,
                    PhoneNumber=company.EmployeePhone,                
                };

                var result = await _userManager.CreateAsync(user, company.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return RedirectToAction("EmployeeList");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "This Email is already available.");
                return View(company);

            }

            return View();
        }
    
        public IActionResult EditEmployee(string EmployeeId)
        {

            var obj = (from user in _context.Users
                       join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                       join roles in _context.Roles on userRoles.RoleId equals roles.Id
                       join dep in _context.Departments on user.Department equals dep.Id
                       where roles.Name == "Employee" && user.Id== EmployeeId
                       select new CompanyEmployesViewModel
                       {
                           FullName = user.FullName,
                           FatherName = user.FatherName,
                           DateOfBirth = user.DateOfBirth,
                           DateOfjoining = user.DateOfjoining,
                           DepartmentName = dep.Name,
                           Designation = user.Designation,
                           Salary = user.Salary,
                           Email = user.Email,
                           EmployeeId = user.Id,
                           MotherName = user.MotherName,
                           EmployeeOfficeId = user.OfficeId,
                           Department=user.Department,
                           EmployeePhone=user.PhoneNumber
                       }).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }

            ViewBag.Department = new SelectList(_UnitofWork.Departments.GetAll(), "Id", "Name",obj.Department);

            return View(obj);
        }
        [HttpPost]
        public async Task< IActionResult> EditEmployee(CompanyEmployesViewModel company)
        {
            ViewBag.Department = new SelectList(_UnitofWork.Departments.GetAll(), "Id", "Name", company.Department);

            // Find the user by email
            var user =  await _context.Users.Where(x => x.Id == company.EmployeeId).FirstOrDefaultAsync();
            if (user != null)
            {
               
                    // Update user properties
                    user.Email = company.Email;
                    user.UserName = company.Email;
                    user.DateOfBirth = company.DateOfBirth;
                    user.DateOfjoining = company.DateOfjoining;
                    user.Department = company.Department;
                    user.Designation = company.Designation;
                    user.FatherName = company.FatherName;
                    user.MotherName = company.MotherName;
                    user.FullName = company.FullName;
                    user.OfficeId = company.EmployeeOfficeId;
                    user.Salary = company.Salary;
                    user.PhoneNumber = company.EmployeePhone;

                    // Call UpdateAsync to update the user
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("EmployeeList");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "System Error");
                        return View(company);
                    }
               
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(company);
            }
        }

        public IActionResult DeleteEmployee(string id)
        {
            var getData = _context.Users.Find(id);
            if (getData != null)
            {
                _context.Users.Remove(getData);
                int check = _context.SaveChanges();
                if (check == 1)
                {
                    return new JsonResult("User is Delete successfully");
                }

                else
                {
                    return new JsonResult("Error! User is not Delete");
                }
            }
            return new JsonResult("Error! User is not Delete");
        }
        public IActionResult EmployeeLeave()
        {
            var obj = (from leave in _context.EmployeLeaves
                       join record in _context.EmplyeeLeaveRecords on
                       leave.Id equals record.LeaveId
                       join user in _context.Users on record.EmplyeeId equals user.Id
                       where record.LeaveStatus == "Pending"
                       select new EmployeeLeaveViewModel
                       {
                           EmployeeName = user.FullName,
                           LeaveDate = record.LeaveDate.ToString(),
                           LeaveName = leave.Name,
                           LeaveId = record.Id,
                           TotalLeave = leave.LeaveInYear,
                           LeaveStatus = record.LeaveStatus
                       }).ToList();
            return View(obj);
        }
        public IActionResult UpdateStatus(int id)
        {
            var obj= _context.EmplyeeLeaveRecords.Find(id);
            if(obj == null)
            {
                return NotFound();

            }
             obj.LeaveStatus = "Approve";
            _context.EmplyeeLeaveRecords.Update(obj);

            int check =  _context.SaveChanges();
            if (check == 1)
            {
                return new JsonResult("Leave information is update successfully");
            }

            else
            {
                return new JsonResult("Error! Leave  information is not update");
            }
        }

    }
}
