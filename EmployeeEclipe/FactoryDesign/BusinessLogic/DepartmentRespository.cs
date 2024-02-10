using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class DepartmentRespository : Repository<Department>, IDepartment
    {
        private ApplicationDbContext _context;
        public DepartmentRespository(ApplicationDbContext context) :base(context) 
        { 
            _context = context;
        }
        public List<Department> GetAllDepartments()
        {
            var obj = _context.Departments.ToList();
            return obj;
        }

        public void Update(Department department)
        {
            var oldDepartment = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (oldDepartment != null) { 
                oldDepartment.Name = department.Name;              
            }
        }
    }
}
