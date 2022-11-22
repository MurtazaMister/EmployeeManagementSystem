using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
	public class EmployeeController : Controller
	{
		private ApplicationDbContext _db;
		public EmployeeController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Employee> employees = _db.Employees.ToList<Employee>();
			List<Department> departments = _db.Departments.ToList<Department>();
			ViewData["employees"] = employees;
			ViewData["departments"] = departments;
			return View();
		}
		public Employee employee { get; set; }
		public IActionResult Create()
		{
            List<Department> departments = _db.Departments.ToList<Department>();
            ViewData["employee"] = employee;
            ViewData["departments"] = departments;
            return View();
		}
		public IActionResult CreateHelper(Employee employee)
		{
			if (ModelState.IsValid)
			{
				_db.Employees.Add(employee);
				_db.SaveChanges();
			}
			return RedirectToAction("Index");
		}
        public IActionResult Edit(int id)
        {
			employee = _db.Employees.Find(id);
            List<Department> departments = _db.Departments.ToList<Department>();
            ViewData["employee"] = employee;
            ViewData["departments"] = departments;
            return View();
        }
        public IActionResult EditHelper(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
		public IActionResult Delete(int id)
		{
			employee = _db.Employees.Find(id);
			if(employee != null)
			{
				_db.Employees.Remove(employee);
				_db.SaveChanges();
			}
            return RedirectToAction("Index");
        }
    }
}
