using System.ComponentModel.DataAnnotations;

namespace KidKinder.ViewModels.Departments
{
    public class DepartmentUpdateVM
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
    }
}
