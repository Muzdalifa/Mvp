using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Domain.Entities
{
    public sealed class EmployeeDepartment
    {
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public bool IsManager { get; set; }
    }
}
