using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Dtos.Employee;

public sealed class EmployeeRequestDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime HireDate { get; set; }

    public string Position { get; set; } = string.Empty;

    public Guid? ManagerId { get; set; }

    public string? ManagerName { get; set; }

    public Guid CompanyId { get; set; }
}
