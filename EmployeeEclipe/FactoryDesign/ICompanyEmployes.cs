using EmployeeEclipe.Models;
using EmployeeEclipe.ViewModel;

namespace EmployeeEclipe.FactoryDesign
{
    public interface ICompanyEmployes : IRepository<CompanyEmployesViewModel>
    {
        List<CompanyEmployesViewModel> CompanyEmployeeList();

        List<EmployeeLeaveViewModel> EmployeeLeaveLis();

    }
    

}
