using KidKinder.Models.Common;

namespace KidKinder.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
