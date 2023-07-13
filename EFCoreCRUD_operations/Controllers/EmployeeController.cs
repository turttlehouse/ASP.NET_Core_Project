using EFCoreCRUD_operations.Data;
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
            return View();
        }
    }
}
