namespace Mvp.Domain.Entities;

public class EmployeeDepartment
{
    public Guid EmployeeId { get; set; }

    public Employee Employee { get; set; }

    public Guid DepartmentId { get; set; }

    public Department Department { get; set; }

    public bool IsManager { get; set; }
}