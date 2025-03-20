using Mvp.Application.Dtos.Employee;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeResponseDto>> GetEmployees(string? filter, string? text);

        public Task<EmployeeResponseDto?> GetEmployeeById(Guid id);

        public Task<EmployeeResponseDto?> CreateEmployee(EmployeeRequestDto createEmployeeDto);

        public Task<EmployeeResponseDto?> UpdateEmployee(Guid id, EmployeeRequestDto updateEmployeeDto);

        public Task<bool> DeleteEmployee(Guid id);
    }
}
