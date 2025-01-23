using AutoMapper;
using KidKinder.Models;
using KidKinder.ViewModels.Employees;

namespace KidKinder.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateVM, Employee>();
            CreateMap<EmployeeUpdateVM, Employee>().ReverseMap();
            CreateMap<Employee,EmployeeItemVM>();
        }
    }
}
