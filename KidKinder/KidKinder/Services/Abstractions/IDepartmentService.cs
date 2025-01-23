using KidKinder.ViewModels.Departments;

namespace KidKinder.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task DepartmentCreate(DepartmentCreateVM vm);
        Task DepartmentUpdate(int id,DepartmentUpdateVM vm);
        Task DepartmentDelete(int id);
        Task<DepartmentItemVM> GetByIdDepartment(int id);
        Task<ICollection<DepartmentItemVM>> GetAllDepartments();
    }
}
