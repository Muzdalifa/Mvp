using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Dtos
{
    public sealed class DepartmentResponseDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Location { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }
    }
}
