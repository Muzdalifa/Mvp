﻿using AutoMapper;
using Mvp.Application.Dtos.Company;
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

        public async Task<CompanyResponseDto?> UpdateCompany(Guid id, CompanyRequestDto updateCompanyDto)
        {
            if(id != Guid.Empty)
            {
                var mappedCompany = mapper.Map<Company>(updateCompanyDto);

                var updatedCompany = await companyRepository.Update(id, mappedCompany);

                return mapper.Map<CompanyResponseDto>(updatedCompany);
            }
            else
            {
                return null;
            }   
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            if(id != Guid.Empty)
            {
               return await companyRepository.Delete(id);               
            }
            else
            {
                return false;
            }
        }

        
    }
}
