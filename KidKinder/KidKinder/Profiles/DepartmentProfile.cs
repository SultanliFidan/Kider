using AutoMapper;
using KidKinder.Models;
using KidKinder.ViewModels.Departments;

namespace KidKinder.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentCreateVM, Department>();
            CreateMap<DepartmentUpdateVM, Department>();
            CreateMap<Department,DepartmentItemVM>();
        }
    }
}
