using AutoMapper;
using Mvp.Application.Dtos;
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
            CreateMap<Company, CompanyResponseDto>().ReverseMap();  
        }
    }
}
