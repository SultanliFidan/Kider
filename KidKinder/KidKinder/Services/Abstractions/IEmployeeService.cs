using KidKinder.ViewModels.Employees;

namespace KidKinder.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task EmployeeCreate(EmployeeCreateVM vm, string destination);
        Task EmployeeUpdate(int id,EmployeeUpdateVM vm, string destination);
        Task EmployeeDelete(int id);
        Task<EmployeeUpdateVM> GetEmployeeItemById(int id);
        Task<ICollection<EmployeeItemVM>> GetEmployees();
    }
}
