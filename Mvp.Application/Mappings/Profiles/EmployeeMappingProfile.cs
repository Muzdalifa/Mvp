using AutoMapper;
using Mvp.Application.Dtos.Employee;
using Mvp.Domain.Entities;

namespace Mvp.Application.Mappings.Profiles
{
    public sealed class EmployeeMappingProfile: Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponseDto>()
               .ForMember(dest => dest.ManagerName, opt =>
               {
                   opt.MapFrom(src =>
                       src.Manager != null ? src.Manager.FirstName + " " + src.Manager.LastName : null);                   
               });

            CreateMap<EmployeeRequestDto, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.CreateVersion7()));

            CreateMap<Employee, EmployeeRequestDto>();

            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
        }
    }
}
