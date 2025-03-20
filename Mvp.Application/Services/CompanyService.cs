using AutoMapper;
using Mvp.Application.Dtos;
using Mvp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Services
{
    public sealed class CompanyService(ICompanyRepository companyRepository, IMapper mapper) : ICompanyService
    {
        public async Task<IEnumerable<CompanyResponseDto>> GetCompanies()
        {
            var company =  await companyRepository.Get();
            return mapper.Map<IEnumerable<CompanyResponseDto>>(company);
        }

        public Task<CompanyResponseDto> CreateCompany(CompanyResponseDto createCompanyDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyResponseDto> GetCompanyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyResponseDto> UpdateCompany(CompanyResponseDto updateCompanyDto)
        {
            throw new NotImplementedException();
        }
    }
}
