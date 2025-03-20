using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> Get();

        public Task<Department?> GetById(Guid id);

        public Task<Department> Create(Department company);

        public Task<Department?> Update(Guid id, Department company);

        public Task<bool> Delete(Guid id);
    }
}
