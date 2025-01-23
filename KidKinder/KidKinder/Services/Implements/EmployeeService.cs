using AutoMapper;
using KidKinder.Context;
using KidKinder.Extensions;
using KidKinder.Models;
using KidKinder.Services.Abstractions;
using KidKinder.ViewModels.Departments;
using KidKinder.ViewModels.Employees;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Services.Implements
{
    public class EmployeeService(KidkinderDbContext _context, IMapper _mapper) : IEmployeeService
    {
        public async Task EmployeeCreate(EmployeeCreateVM vm, string destination)
        {
            Employee employee = _mapper.Map<Employee>(vm);
            employee.ImageUrl = await vm.File!.UploadAsync(destination, "images", "employees");
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task EmployeeDelete(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new Exception("Employee not found");
            var path = Path.Combine("wwwroot","images","employees",employee.ImageUrl);
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async  Task EmployeeUpdate(int id, EmployeeUpdateVM vm, string destination)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new Exception("Employee not found");
            if (destination != null)
                employee.ImageUrl = await vm.File!.UploadAsync(destination, "images", "employees");
            _mapper.Map(vm, employee);
            await _context.SaveChangesAsync();

        }

        public async Task<EmployeeUpdateVM> GetEmployeeItemById(int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new Exception("Employee not found");
            EmployeeUpdateVM employeeItem = _mapper.Map<EmployeeUpdateVM>(employee);
            return employeeItem;
        }

        public async Task<ICollection<EmployeeItemVM>> GetEmployees()
        {
            ICollection<Employee> employees = await _context.Employees.ToListAsync();
            ICollection<EmployeeItemVM> employeeItems = _mapper.Map<ICollection<EmployeeItemVM>>(employees);
            return employeeItems;
        }
    }
}
