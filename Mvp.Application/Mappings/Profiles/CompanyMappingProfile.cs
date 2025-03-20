using AutoMapper;
using Mvp.Application.Dtos.Company;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Mappings.Profiles
{
    public sealed class CompanyMappingProfile: Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyRequestDto, Company>()
                .ForMember(dest => dest.Id, opt =>opt.MapFrom(src => Guid.CreateVersion7()));

            CreateMap<Company, CompanyRequestDto>();

            CreateMap<Company, CompanyResponseDto>().ReverseMap();

            CreateMap<UpdateCompanyDto, Company>().ReverseMap();
        }
    }
}
