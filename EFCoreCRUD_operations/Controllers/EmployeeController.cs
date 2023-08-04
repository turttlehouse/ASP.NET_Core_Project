using EFCoreCRUD_operations.Data;
using EFCoreCRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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

        // Check if the predefined data already exists in the database
        // if (!context.Employees.Any(e => e.Name == "John"))  /*Any(e => e.Name == "John"): This is a LINQ query using the Any method. It checks if there is any record in the EmployeeTable DbSet where the Name property is equal to "John".*/
        //{
        //    var data = new Employees // for inserting our predefined data directly to create the data
        //    {
        //        Name = "John",
        //        salary = 5000,
        //    };
        //    context.Employees.Add(data);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //else
        //{
        //    return RedirectToAction("Index");
        //}

    }

    public IActionResult Delete(int id)
    {
        var emp = context.Employees.SingleOrDefault(x => x.Id == id);
        if (emp != null)
        {
            context.Employees.Remove(emp);
            context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var emp = context.Employees.SingleOrDefault(x => x.Id == id);
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
            var emp = context.Employees.SingleOrDefault(x => x.Id == model.Id);
            if (emp != null)
            {
                emp.Name = model.Name;
                emp.salary = model.salary;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }
}
