namespace Mvp.Entities
{
    public sealed class EmployeeDepartment
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
