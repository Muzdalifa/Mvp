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
    public sealed class CompanyRepository(MvpDbContext context) : ICompanyRepository
    {
        public async Task<IEnumerable<Company>> Get()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company?> GetById(Guid id)
        {
            var company = await context.Companies
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

            return company;
        }

        public async Task<Company> Create(Company createCompany)
        {
            var id = Guid.CreateVersion7();

            Company newCompany = new Company
            {
                Id = id,
                Name = createCompany.Name,
                Address = createCompany.Address,
                IsActive = createCompany.IsActive,
                Website = createCompany.Website
            };

            await context.Companies.AddAsync(newCompany);

            await context.SaveChangesAsync();

            return newCompany;
        }

        public async Task<Company?> Update(Guid id, Company updateCompany)
        {
            var company = await GetById(id);

            if(company is null)
            {
                return null;
            }

            company.Name = updateCompany.Name;
            company.Address = updateCompany.Address;
            company.Description = updateCompany.Description;
            company.IsActive = updateCompany.IsActive;
            company.Website = updateCompany.Website;

            await context.SaveChangesAsync();

            return company;
        }

        public async Task<bool> Delete(Guid id)
        {
            var company = await GetById(id);

            if (company is not null)
            {
                context.Companies.Remove(company);

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
