using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Domain.Entities;

namespace Mvp.Api.Controllers;

[ApiController]
[Route("companies")]
public class CompanyController(MvpDbContext context) : Controller()
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await context.Companies.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await context.Companies
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if(company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] Company company)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The given data was not on the correct format");
        }

        var id = Guid.CreateVersion7();

        var newCompany = new Company
        {
            Id = id,
            Name = company.Name,
            Address = company.Address,
            IsActive = company.IsActive,
            Website = company.Website
        };

        await context.Companies.AddAsync(newCompany);

        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetCompany),
            new { id = company.Id },
            company);
    }
}
