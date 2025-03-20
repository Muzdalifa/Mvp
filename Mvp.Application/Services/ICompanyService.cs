using Mvp.Application.Dtos.Company;
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

        public Task<CompanyResponseDto?> GetCompanyById(Guid id);

        public Task<CompanyResponseDto> CreateCompany(CompanyRequestDto createCompanyDto);

        public Task<CompanyResponseDto?> UpdateCompany(Guid id, CompanyRequestDto updateCompanyDto);

        public Task<bool> DeleteCompany(Guid id);
    }
}
