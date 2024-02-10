using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;

namespace EmployeeEclipe.FactoryDesign.BusinessLogic
{
    public class NoticeRespository : Repository<NoticBorad>, INoticeBorads
    {
        private ApplicationDbContext _context;
        public NoticeRespository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<NoticBorad> NoticBoradList()
        {
            var obj =_context.NoticBorads.ToList(); 
            return obj;
        }

        public void Update(NoticBorad noticBorad)
        {
            var olddata= _context.NoticBorads.FirstOrDefault(x=>x.Id==noticBorad.Id);   
            if (olddata!=null)
            {
                olddata.Name=noticBorad.Name;
                olddata.Description=noticBorad.Description;
                olddata.UploadFile=noticBorad.UploadFile;
                olddata.NoticDate=noticBorad.NoticDate;
            }
        }
    }
}
