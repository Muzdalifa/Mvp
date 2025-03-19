using Microsoft.EntityFrameworkCore;
using Mvp.Repository.Database;

namespace Mvp.Api.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<MvpDbContext>(
            options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Database"),
                    config => config.MigrationsAssembly("Mvp.Repository")));
    }
}
