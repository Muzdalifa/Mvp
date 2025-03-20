using Mvp.Application.Dtos.Department;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentResponseDto>> GetDepartments();

        public Task<DepartmentResponseDto?> GetDepartmentById(Guid id);

        public Task<DepartmentResponseDto> CreateDepartment(DepartmentRequestDto createDepartmentDto);

        public Task<DepartmentResponseDto?> UpdateDepartment(Guid id, DepartmentRequestDto updateDepartmentDto);

        public Task<bool> DeleteDepartment(Guid id);
    }
}
