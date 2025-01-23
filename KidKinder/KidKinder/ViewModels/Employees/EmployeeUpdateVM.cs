using System.ComponentModel.DataAnnotations;

namespace KidKinder.ViewModels.Employees
{
    public class EmployeeUpdateVM
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
        [Required, MaxLength(64)]
        public string Description { get; set; }
        public IFormFile File { get; set; }

        public int DepartmentId { get; set; }
    }
}
