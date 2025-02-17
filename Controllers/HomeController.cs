using CrudAppUsingADO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDataAccessLayer dal;

        public HomeController()
        {
            dal= new EmpDataAccessLayer();
        }
        public IActionResult Index()
        {
            List<Employees> emps = dal.getAllEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                dal.AddEmployee(emp);
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
          
           
        }

        public IActionResult Edit(int id)
        {
            Employees emp = dal.getEmployeeByID(id);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
        public IActionResult Details(int id)
        {
            Employees emp = dal.getEmployeeByID(id);
            return View(emp);
        }


        public IActionResult Delete(int id)
        {
            Employees emp = dal.getEmployeeByID(id);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees emp)
        {
            try
            {
                dal.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
