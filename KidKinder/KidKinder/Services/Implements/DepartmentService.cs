using AutoMapper;
using KidKinder.Context;
using KidKinder.Models;
using KidKinder.Services.Abstractions;
using KidKinder.ViewModels.Departments;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Services.Implements
{
    public class DepartmentService(KidkinderDbContext _context, IMapper _mapper) : IDepartmentService
    {
        public async Task DepartmentCreate(DepartmentCreateVM vm)
        {
            Department department = _mapper.Map<Department>(vm);
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DepartmentDelete(int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new Exception("Department not found");
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task DepartmentUpdate(int id, DepartmentUpdateVM vm)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new Exception("Department not found");
            _mapper.Map(vm, department);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DepartmentItemVM>> GetAllDepartments()
        {
            ICollection<Department> departments = await _context.Departments.ToListAsync();
            ICollection<DepartmentItemVM> departmentItems = _mapper.Map<ICollection<DepartmentItemVM>>(departments);
            return departmentItems;
        }

        public async Task<DepartmentItemVM> GetByIdDepartment(int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new Exception("Department not found");
            DepartmentItemVM departmentItem = _mapper.Map<DepartmentItemVM>(department);
            return departmentItem;
        }
    }
}
