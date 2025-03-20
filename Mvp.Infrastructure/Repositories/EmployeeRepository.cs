using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Infrastructure.Repositories
{
    public sealed class EmployeeRepository(MvpDbContext context) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> Get()
        {
            return await context.Employees
                .Include(e => e.Manager)
                .ToListAsync();
        }

        public async Task<Employee?> GetById(Guid id)
        {
            var employee = await context.Employees
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<Employee> Create(Employee createEmployee)
        {
            try
            {
                await context.Employees.AddAsync(createEmployee);

                await context.SaveChangesAsync();

                return createEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while creating employee : {createEmployee.Id}", ex);
            }
        }

        public async Task<Employee?> Update(Guid id, Employee updateEmployee)
        {
            var employee = await GetById(id);

            if(employee is null)
            {
                return null;
            }

            employee.FirstName = updateEmployee.FirstName;
            employee.LastName = updateEmployee.LastName;
            employee.Email = updateEmployee.Email;
            employee.Position = updateEmployee.Position;
            employee.HireDate = updateEmployee.HireDate;
            employee.PhoneNumber = updateEmployee.PhoneNumber;
            employee.CompanyId = updateEmployee.CompanyId;
            employee.ManagerId = updateEmployee.ManagerId;

            await context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> Delete(Guid id)
        {
            var employee = await GetById(id);

            if (employee is not null)
            {
                context.Employees.Remove(employee);

                await context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
