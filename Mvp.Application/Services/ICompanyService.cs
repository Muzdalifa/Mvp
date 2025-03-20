using Mvp.Application.Dtos;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public interface ICompanyService
    {
        public Task<IEnumerable<CompanyResponseDto>> GetCompanies();

        public Task<CompanyResponseDto> GetCompanyById(Guid id);

        public Task<CompanyResponseDto> CreateCompany(CompanyResponseDto createCompanyDto);

        public Task<CompanyResponseDto> UpdateCompany(CompanyResponseDto updateCompanyDto);

        public Task DeleteCompany(Guid id);
    }
}
