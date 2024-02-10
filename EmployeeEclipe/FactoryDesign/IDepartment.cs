using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign
{
    public interface IDepartment : IRepository<Department>
    {
        List<Department> GetAllDepartments();
        void Update(Department department); 
    }
}
