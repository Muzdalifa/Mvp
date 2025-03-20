using Mvp.Api.Database;
using Mvp.Api.Database.Extensions;
using Mvp.Application.Mappings;
using Mvp.Application.Services;
using Mvp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.AddDatabase();

builder.Services.AddDbContext<MvpDbContext>();

builder.Services.RegisterAutoMappings();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("developmentPlicy",
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("developmentPlicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
