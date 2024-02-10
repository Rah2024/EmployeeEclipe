using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using Microsoft.AspNetCore.Authorization;
using EmployeeEclipe.FactoryDesign;

namespace EmployeeEclipe.Controllers
{
    [Authorize(Roles = "HRAdmin")]
    public class DepartmentsController : Controller
    {
        private readonly IUnitofWork _UnitofWork;

        public DepartmentsController( IUnitofWork unitofWork)
        {
            _UnitofWork= unitofWork;
        }

        public IActionResult Dashborad()
        {
            return View();
        }
        public IActionResult Index()
        {
            var obj =  _UnitofWork.Departments.GetAllDepartments();
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.Departments.Add(department);
                _UnitofWork.save();
                
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  _UnitofWork.Departments.GETFirstOrDefault(x=>x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                _UnitofWork.Departments.Update(department);
                _UnitofWork.save();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _UnitofWork.Departments.GETFirstOrDefault(x => x.Id == id);
            if (department != null)
            {
                _UnitofWork.Departments.Remove(department);
            }        
              _UnitofWork.save();
             return new JsonResult("Departments is Delete successfully");            
        }     
    }
}
