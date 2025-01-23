using KidKinder.Services.Abstractions;
using KidKinder.ViewModels.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DepartmentController(IDepartmentService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllDepartments());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Create(DepartmentCreateVM vm)
        {
            await _service.DepartmentCreate(vm);
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await _service.GetByIdDepartment(id);
            if (data == null)
                throw new Exception("not found");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,DepartmentUpdateVM vm)
        {
            await _service.DepartmentUpdate(id, vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DepartmentDelete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _service.GetByIdDepartment(id));
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await _service.GetAllDepartments());
        }
    }
}
