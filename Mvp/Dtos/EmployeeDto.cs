using Mvp.Entities;

namespace Mvp.Dtos
{
    public sealed class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
    }
}
