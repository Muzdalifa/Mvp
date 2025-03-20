using AutoMapper;
using Mvp.Application.Dtos.Department;
using Mvp.Domain.Entities;
using Mvp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public sealed class DepartmentService(
        IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
    {
        public async Task<IEnumerable<DepartmentResponseDto>> GetDepartments()
        {
            var departments =  await departmentRepository.Get();
            return mapper.Map<IEnumerable<DepartmentResponseDto>>(departments);
        }

        public async Task<DepartmentResponseDto?> GetDepartmentById(Guid id)
        {
            var department = await departmentRepository.GetById(id);

            if(department is null)
            {
                return null;
            }

            return mapper.Map<DepartmentResponseDto>(department);
        }

        public async Task<DepartmentResponseDto> CreateDepartment(
            DepartmentRequestDto createDepartmentDto)
        {
            var department = mapper.Map<Department>(createDepartmentDto);

            var newDepartment = await departmentRepository.Create(department);

            return mapper.Map<DepartmentResponseDto>(newDepartment);
        }

        public async Task<DepartmentResponseDto?> UpdateDepartment(
            Guid id, DepartmentRequestDto updateDepartmentDto)
        {
            if(id != Guid.Empty)
            {
                var mappedDepartment = mapper.Map<Department>(updateDepartmentDto);

                var updatedDepartment = await departmentRepository.Update(id, mappedDepartment);

                return mapper.Map<DepartmentResponseDto>(updatedDepartment);
            }
            else
            {
                return null;
            }   
        }

        public async Task<bool> DeleteDepartment(Guid id)
        {
            if(id != Guid.Empty)
            {
               return await departmentRepository.Delete(id);               
            }
            else
            {
                return false;
            }
        }        
    }
}
