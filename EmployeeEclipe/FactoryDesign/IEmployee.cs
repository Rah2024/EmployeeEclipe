using EmployeeEclipe.Models;
using EmployeeEclipe.ViewModel;

namespace EmployeeEclipe.FactoryDesign
{
    public interface IEmployee : IRepository<EmployeLeave>
    {
        List<EmployeLeave> EmployeLeaveList();
        List<NoticBorad> NoticBoradsList();
        List<EmployeeLeaveViewModel> EmployeeLeaveRecordList();
        public void AddLeaveRecord(EmplyeeLeaveRecord emplyeeLeaveRecord);
        List<SalaryViewModel> EmployeeSalary();
    }
}
