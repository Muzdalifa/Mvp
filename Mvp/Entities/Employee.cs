namespace Mvp.Entities
{
    public sealed class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
    }
}
