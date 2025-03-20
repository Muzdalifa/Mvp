using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Application.Dtos;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Infrastructure.Repositories
{
    public sealed class CompanyRepository(MvpDbContext context) : ICompanyRepository
    {
        public async Task<IEnumerable<Company>> Get()
        {
            return await context.Companies.ToListAsync();
        }

        public Task<CompanyResponseDto> Create(CompanyResponseDto company)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> Update(Guid id, CompanyResponseDto company)
        {
            throw new NotImplementedException();
        }
    }
}
