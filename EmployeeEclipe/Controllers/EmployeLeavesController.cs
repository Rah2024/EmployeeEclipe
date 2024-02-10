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
    public class EmployeLeavesController : Controller
    {
        private readonly IUnitofWork _UnitofWork;

        public EmployeLeavesController( IUnitofWork UnitofWork)
        {
            _UnitofWork = UnitofWork;
        }

        public IActionResult Index()
        {
            var obj = _UnitofWork.EmployeLeaves.EmployeLeaveList();
            return View(obj);
             
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( EmployeLeave employeLeave)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.EmployeLeaves.Add(employeLeave);
                _UnitofWork.save();              
                return RedirectToAction(nameof(Index));
            }
            return View(employeLeave);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var employeLeave = _UnitofWork.EmployeLeaves.GETFirstOrDefault(x => x.Id == id);    
            if (employeLeave == null)
            {
                return NotFound();
            }
            return View(employeLeave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeLeave employeLeave)
        {
            if (id != employeLeave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {            
               _UnitofWork.EmployeLeaves.Update(employeLeave);
               _UnitofWork.save();
                return RedirectToAction(nameof(Index));
            }
            return View(employeLeave);
        }
        public IActionResult DeleteConfirmed(int id)
        {
           
            var employeLeave = _UnitofWork.EmployeLeaves.GETFirstOrDefault(x=>x.Id == id);
            if (employeLeave != null)
            {
                _UnitofWork.EmployeLeaves.Remove(employeLeave);
            }

            _UnitofWork.save();          
            return new JsonResult("Employe Leaves is Delete successfully");
           
        }
    }
}
