using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using EmployeeEclipe.FactoryDesign;

namespace EmployeeEclipe.Controllers
{
    [Authorize(Roles = "HRAdmin")]
    public class NoticBoradsController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUnitofWork _UnitofWork;

        public NoticBoradsController(IWebHostEnvironment hostEnvironment, IUnitofWork unitofWork)
        {
            _hostEnvironment = hostEnvironment;
            _UnitofWork= unitofWork;    
        }

        public IActionResult Index()
        {
            var obj = _UnitofWork.NoticeBorad.GetAll();
            return View(obj);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoticBorad noticBorad)
        {
            if (ModelState.IsValid)
            {
                if(noticBorad.UploadName != null)
                {
                    string dateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string webRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(noticBorad.UploadName.FileName);
                    string extension = Path.GetExtension(noticBorad.UploadName.FileName);
                    string uniqueFileName = fileName + "_" + dateTime + extension;

                    noticBorad.UploadFile = uniqueFileName;
                    string filePath = Path.Combine(webRootPath, "UploadContent", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        noticBorad.UploadName.CopyTo(fileStream);
                    }

                }
                 noticBorad.NoticDate = System.DateTime.Now;
                _UnitofWork.NoticeBorad.Add(noticBorad);
                _UnitofWork.save();
                return RedirectToAction(nameof(Index));
            }
            return View(noticBorad);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticBorad = _UnitofWork.NoticeBorad.GETFirstOrDefault(x=>x.Id==id);
            if (noticBorad == null)
            {
                return NotFound();
            }
            return View(noticBorad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NoticBorad noticBorad)
        {
            if (id != noticBorad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    if (noticBorad.UploadName != null)
                    {
                        string dateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string webRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(noticBorad.UploadName.FileName);
                        string extension = Path.GetExtension(noticBorad.UploadName.FileName);
                        string uniqueFileName = fileName + "_" + dateTime + extension;

                        noticBorad.UploadFile = uniqueFileName;
                        string filePath = Path.Combine(webRootPath, "UploadContent", uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            noticBorad.UploadName.CopyTo(fileStream);
                        }

                    }
                    noticBorad.NoticDate = System.DateTime.Now;
                    _UnitofWork.NoticeBorad.Update(noticBorad);
                    _UnitofWork.save();
                return RedirectToAction(nameof(Index));
            }
            return View(noticBorad);
        }
        public  IActionResult DeleteConfirmed(int id)
        {

            var noticBorad = _UnitofWork.NoticeBorad.GETFirstOrDefault(x => x.Id == id);
            if (noticBorad != null)
            {
                _UnitofWork.NoticeBorad.Remove(noticBorad); 
            }

            _UnitofWork.save();
           return new JsonResult("Notic Borads information is Delete successfully");
           
        }

    }
}
