using KidKinder.Models;
using System.ComponentModel.DataAnnotations;

namespace KidKinder.ViewModels.Employees
{
    public class EmployeeItemVM
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
