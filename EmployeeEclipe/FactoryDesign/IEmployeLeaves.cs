using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign
{
    public interface IEmployeLeaves : IRepository<EmployeLeave>
    {
        List<EmployeLeave> EmployeLeaveList();
        void Update(EmployeLeave employeLeave);

    }
}
