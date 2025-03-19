using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Domain.Entities
{
    public sealed class Employee: Entity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        public string Position { get; set; } = string.Empty;

        public Guid? ManagerId { get; set; }

        public Employee? Manager { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
