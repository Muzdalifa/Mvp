using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mvp.Infrastructure.Repositories
{
    public sealed class DepartmentRepository(MvpDbContext context) : IDepartmentRepository
    {
        public async Task<IEnumerable<Department>> Get()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department?> GetById(Guid id)
        {
            var d = await context.Departments
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

            return d;
        }

        public async Task<Department> Create(Department createDepartment)
        {
            await context.Departments.AddAsync(createDepartment);

            await context.SaveChangesAsync();

            return createDepartment;
        }

        public async Task<Department?> Update(Guid id, Department updateDepartment)
        {
            var d = await GetById(id);

            if(d is null)
            {
                return null;
            }

            d.Name = updateDepartment.Name;
            d.Location = updateDepartment.Location;
            d.Description = updateDepartment.Description;

            await context.SaveChangesAsync();

            return d;
        }

        public async Task<bool> Delete(Guid id)
        {
            var d = await GetById(id);

            if (d is not null)
            {
                context.Departments.Remove(d);

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
