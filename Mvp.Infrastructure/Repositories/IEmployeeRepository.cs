using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> Get(string? filter, string? text);

        public Task<Employee?> GetById(Guid id);

        public Task<Employee?> Create(Employee company);

        public Task<Employee?> Update(Guid id, Employee company);

        public Task<bool> Delete(Guid id);
    }
}
