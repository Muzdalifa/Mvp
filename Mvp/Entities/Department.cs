using System.ComponentModel.DataAnnotations;

namespace Mvp.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
    }
}
