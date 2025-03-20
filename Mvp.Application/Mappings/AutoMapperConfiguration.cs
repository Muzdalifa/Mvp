using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Mvp.Application.Mappings.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Application.Mappings;

public static class AutoMapperConfiguration
{
    public static void RegisterAutoMappings(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new EmployeeMappingProfile());
            mc.AddProfile(new CompanyMappingProfile());
            mc.AddProfile(new DepartmentMappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        services.AddSingleton(mapper);
    }
}
