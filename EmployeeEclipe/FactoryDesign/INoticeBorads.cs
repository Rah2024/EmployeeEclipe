using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign
{
    public interface INoticeBorads : IRepository<NoticBorad>
    {
        List<NoticBorad> NoticBoradList();
        void Update(NoticBorad noticBorad);
    }
}
