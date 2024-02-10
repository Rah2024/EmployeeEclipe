using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using EmployeeEclipe.ViewModel;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class EmployeeRespository : Repository<EmployeLeave>, IEmployee
    {
        private ApplicationDbContext _context;
        public EmployeeRespository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<NoticBorad> NoticBoradsList()
        {
            var obj= _context.NoticBorads.ToList();
            return obj;
        }
        public List<EmployeLeave> EmployeLeavesList()
        {
            var obj= _context.EmployeLeaves.ToList();
            return obj;
        }
        public List<EmployeeLeaveViewModel> EmployeeLeaveRecordList()
        {
             var obj = (from leave in _context.EmployeLeaves
                                 join record in _context.EmplyeeLeaveRecords on
                                 leave.Id equals record.LeaveId
                                 join user in _context.Users on record.EmplyeeId equals user.Id
                                 select new EmployeeLeaveViewModel
                                 {
                                     EmployeeName = user.FullName,
                                     LeaveDate = record.LeaveDate.ToString(),
                                     LeaveName = leave.Name,
                                     LeaveId = leave.Id,
                                     TotalLeave = leave.LeaveInYear,
                                     LeaveStatus = record.LeaveStatus,
                                     LoginUserId=user.Id,
                                 }).ToList();
            return obj;
        }

        public List<EmployeLeave> EmployeLeaveList()
        {
            var obj = _context.EmployeLeaves.ToList();
            return obj;
        }

        public void AddLeaveRecord(EmplyeeLeaveRecord emplyeeLeaveRecord)
        {
            _context.EmplyeeLeaveRecords.Add(emplyeeLeaveRecord);
        }

        public List<SalaryViewModel> EmployeeSalary()
        {
            var obj = (from user in _context.Users
                       join dep in _context.Departments
                       on user.Department equals dep.Id
                       select new SalaryViewModel
                       {
                           DepartmentName = dep.Name,
                           Designation = user.Designation,
                           FullName = user.FullName,
                           OfficeUserName = user.OfficeId,
                           Salary = user.Salary,
                           LoginUser=user.Id,
                       }).ToList();
            return obj;
        }
    }
}
