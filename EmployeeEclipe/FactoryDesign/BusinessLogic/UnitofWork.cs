using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _context;
        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Departments = new DepartmentRespository(_context);
            EmployeLeaves = new EmployeLeavesRespository(_context);
            NoticeBorad = new NoticeRespository(_context);
            CompanyEmploye = new CompanyEmployesRespository(_context);
            Employe = new EmployeeRespository(_context);
        }
        public IDepartment Departments { get; private set; }
        public IEmployee Employe {  get; private set; }
        public IEmployeLeaves EmployeLeaves { get; private set; }
        public INoticeBorads NoticeBorad { get; private set; }  
        public ICompanyEmployes CompanyEmploye { get; private set; }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
