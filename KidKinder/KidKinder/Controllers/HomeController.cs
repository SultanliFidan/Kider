using System.Diagnostics;
using KidKinder.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers
{
    public class HomeController(IEmployeeService _service) : Controller
    {
       

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetEmployees());
        }

       
    }
}
