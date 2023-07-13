using EFCoreCRUD_operations.Data;
using EFCoreCRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCRUD_operations.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var tabledata = context.Employees.ToList();

            return View(tabledata);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]

        public IActionResult Create(Employees model)
        {
            //if (ModelState.IsValid)
            //{
            //    var data = new Employees
            //    {
            //        Name = model.Name,
            //        salary = model.salary,

            //    };
            //    context.Employees.Add(data);
            //    context.SaveChanges();

            //    return RedirectToAction("Index");   

            //}
            //else
            //{ 
            //    return View(model);
            //}
            var data = new Employees
            {
                Name = "John",
                salary = 5000,
            };
            context.Employees.Add(data);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
