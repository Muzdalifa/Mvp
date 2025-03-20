using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> Get();

        public Task<Company?> GetById(Guid id);

        public Task<Company> Create(Company company);

        public Task<Company?> Update(Guid id, Company company);

        public Task Delete(Guid id);
    }
}
