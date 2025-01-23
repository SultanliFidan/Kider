using KidKinder.Extensions;
using KidKinder.Services.Abstractions;
using KidKinder.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController(IEmployeeService _service,IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetEmployees());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateVM vm)
        {
            
            if(!ModelState.IsValid) return View(vm);

            if(vm.File != null)
            {
                if (!vm.File.IsValidType("image")) 
                    ModelState.AddModelError("File", "File can be an image");
                if (!vm.File.IsValidSize(400))
                    ModelState.AddModelError("File", "File must be less than 400 kb");

                
            }
            string destination = _env.WebRootPath;
            await _service.EmployeeCreate(vm,destination);
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await _service.GetEmployeeItemById(id);
            if (data == null)
                throw new Exception("not found");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,EmployeeUpdateVM vm)
        {
           
            if (!ModelState.IsValid) return View(vm);

            if (vm.File != null)
            {
                if (!vm.File.IsValidType("image"))
                    ModelState.AddModelError("File", "File can be an image");
                if (!vm.File.IsValidSize(400))
                    ModelState.AddModelError("File", "File must be less than 400 kb");

               
            }
            string destination = _env.WebRootPath;
            await _service.EmployeeUpdate(id,vm,destination);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.EmployeeDelete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _service.GetEmployeeItemById(id));
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await _service.GetEmployees());
        }
    }
}
