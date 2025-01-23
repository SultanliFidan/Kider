using KidKinder.Models;

namespace KidKinder.ViewModels.Departments
{
    public class DepartmentItemVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
