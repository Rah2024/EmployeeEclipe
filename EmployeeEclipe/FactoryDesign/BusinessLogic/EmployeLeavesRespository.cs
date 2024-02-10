using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class EmployeLeavesRespository : Repository<EmployeLeave>, IEmployeLeaves
    {
        private ApplicationDbContext _context;
        public EmployeLeavesRespository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<EmployeLeave> EmployeLeaveList()
        {
            var obj = _context.EmployeLeaves.ToList();
            return obj;
        }

        public void Update(EmployeLeave employeLeave)
        {
            var obj= _context.EmployeLeaves.FirstOrDefault(x=>x.Id==employeLeave.Id);
            if (obj != null)
            {
                obj.Name = employeLeave.Name;
                obj.LeaveInYear= employeLeave.LeaveInYear;  
            }
        }
    }
}
