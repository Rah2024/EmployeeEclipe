using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.ViewModel;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class CompanyEmployesRespository : Repository<CompanyEmployesViewModel>, ICompanyEmployes
    {
        private ApplicationDbContext _context;
        public CompanyEmployesRespository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<CompanyEmployesViewModel> CompanyEmployeeList()
        {
            var obj = (from user in _context.Users
                       join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                       join roles in _context.Roles on userRoles.RoleId equals roles.Id
                       join dep in _context.Departments on user.Department equals dep.Id
                       where roles.Name == "Employee"
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
                       }).ToList();
            return obj;
        }

        public List<EmployeeLeaveViewModel> EmployeeLeaveLis()
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
            return obj;
        }
    }
}
