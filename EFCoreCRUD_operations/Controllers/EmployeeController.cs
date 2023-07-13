using EFCoreCRUD_operations.Data;
using EFCoreCRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]

        public IActionResult Create(Employees model)
        {
            if (ModelState.IsValid)
            {
                var data = new Employees
                {
                    Name = model.Name,
                    salary = model.salary,

                };
                context.Employees.Add(data);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }


            //var data = new Employees                    // for inserting our predefined data directly to create the data
            //{
            //    Name = "John",
            //    salary = 5000,
            //};
            //context.Employees.Add(data);
            //context.SaveChanges();

            //return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(X=> X.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public IActionResult Update(int id)
        {
            var emp = context.Employees.SingleOrDefault(x=> x.Id == id);
            var result = new Employees()
            {
                Name = emp.Name,
                salary = emp.salary,
            };
           

           

            return View(result);  
        }

        [HttpPost]

        public IActionResult Update(Employees model)
        {
            if (ModelState.IsValid)
            {
                var data = new Employees
                {
                    Name = model.Name,
                    salary = model.salary,

                };
                context.Employees.Add(data);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }
        }
    }
}
