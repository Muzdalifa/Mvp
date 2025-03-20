using AutoMapper;
using Mvp.Application.Dtos.Employee;
using Mvp.Domain.Entities;
using Mvp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public sealed class EmployeeService(
        IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeResponseDto>> GetEmployees()
        {
            var employees =  await employeeRepository.Get();
            return mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);
        }

        public async Task<EmployeeResponseDto?> GetEmployeeById(Guid id)
        {
            var employee = await employeeRepository.GetById(id);

            if(employee is null)
            {
                return null;
            }

            return mapper.Map<EmployeeResponseDto>(employee);
        }

        public async Task<EmployeeResponseDto?> CreateEmployee(
            EmployeeRequestDto createEmployeeDto)
        {
            var employee = mapper.Map<Employee>(createEmployeeDto);

            var newEmployee = await employeeRepository.Create(employee);

            if(newEmployee is null)
            {
                return null;
            }

            return mapper.Map<EmployeeResponseDto>(newEmployee);
        }

        public async Task<EmployeeResponseDto?> UpdateEmployee(
            Guid id, EmployeeRequestDto updateEmployeeDto)
        {
            if(id != Guid.Empty)
            {
                var mappedEmployee = mapper.Map<Employee>(updateEmployeeDto);

                var updatedEmployee = await employeeRepository.Update(id, mappedEmployee);

                return mapper.Map<EmployeeResponseDto>(updatedEmployee);
            }
            else
            {
                return null;
            }   
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            if(id != Guid.Empty)
            {
               return await employeeRepository.Delete(id);               
            }
            else
            {
                return false;
            }
        }
    }
}
