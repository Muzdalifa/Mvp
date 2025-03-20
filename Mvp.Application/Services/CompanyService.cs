using AutoMapper;
using Mvp.Application.Dtos;
using Mvp.Domain.Entities;
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
            var companies =  await companyRepository.Get();
            return mapper.Map<IEnumerable<CompanyResponseDto>>(companies);
        }

        public async Task<CompanyResponseDto?> GetCompanyById(Guid id)
        {
            var company = await companyRepository.GetById(id);

            if(company is null)
            {
                return null;
            }

            return mapper.Map<CompanyResponseDto>(company);
        }

        public async Task<CompanyResponseDto> CreateCompany(CompanyRequestDto createCompanyDto)
        {
            var company = mapper.Map<Company>(createCompanyDto);

            var newCompany = await companyRepository.Create(company);

            return mapper.Map<CompanyResponseDto>(newCompany);
        }

        public Task DeleteCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyResponseDto> UpdateCompany(CompanyResponseDto updateCompanyDto)
        {
            throw new NotImplementedException();
        }
    }
}
