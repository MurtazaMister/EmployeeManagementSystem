using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Department> departments = _db.Departments.ToList();
            return View(departments);
        }
        public Department department { get; set; }
        public IActionResult Create()
        {
            return View(department);
        }
        public IActionResult CreateHelper(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            department = _db.Departments.Find(id);
            return View(department);
        }
        public IActionResult EditHelper(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            department = _db.Departments.Find(id);
            if(department != null)
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
