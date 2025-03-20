using Mvp.Api.Database;
using Mvp.Api.Database.Extensions;
using Mvp.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.AddDatabase();

builder.Services.AddDbContext<MvpDbContext>();

builder.Services.RegisterAutoMappings();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
