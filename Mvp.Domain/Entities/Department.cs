namespace Mvp.Domain.Entities;

public sealed class Department: Entity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Location { get; set; } = string.Empty;

    public Guid CompanyId { get; set; }

    public Company Company { get; set; } = new Company();

    public ICollection<EmployeeDepartment> EmployeeDepartmens { get; set; }
}