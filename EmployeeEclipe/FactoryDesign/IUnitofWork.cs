namespace EmployeeEclipe.FactoryDesign
{
    public interface IUnitofWork
    {
        IDepartment Departments { get; }
        IEmployeLeaves EmployeLeaves { get; }   
        INoticeBorads NoticeBorad { get; }
        ICompanyEmployes CompanyEmploye { get; }
        IEmployee Employe { get; }
        void save();
    }
}
