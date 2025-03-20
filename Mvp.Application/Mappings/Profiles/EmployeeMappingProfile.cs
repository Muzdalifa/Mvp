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
    public sealed class EmployeeMappingProfile: Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeRequestDto>()
               .ForMember(dest => dest.ManagerName, opt =>
               {
                   opt.MapFrom(src =>
                       src.Manager != null ? src.Manager.FirstName + " " + src.Manager.LastName : null);                   
               });
        }
    }
}
