using AutoMapper;
using Mvp.Application.Dtos.Department;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Mappings.Profiles
{
    public sealed class DepartmentMappingProfile: Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentRequestDto, Department>()
                .ForMember(dest => dest.Id, opt =>opt.MapFrom(src => Guid.CreateVersion7()));

            CreateMap<Department, DepartmentRequestDto>();

            CreateMap<Department, DepartmentResponseDto>().ReverseMap();

            CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
        }
    }
}
