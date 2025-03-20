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

        if (company == null)
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

        Company newCompany = new Company
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] Company updateCompany)
    {
        Company? company = await context.Companies
            .FirstOrDefaultAsync(c => c.Id == id);

        if (company is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        company.Name = updateCompany.Name;
        company.Address = updateCompany.Address;
        company.Description = updateCompany.Description;
        company.IsActive = updateCompany.IsActive;
        company.Website = updateCompany.Website;

        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        Company? company = await FindCompany(id);

        if(company is null)
        {
            return NotFound();
        }

        context.Companies.Remove(company);

        await context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<Company?> FindCompany(Guid id)
    {
        if (id == Guid.Empty)
            return null;

        Company? company = await context.Companies
            .FirstOrDefaultAsync(c => c.Id == id);

        return company;
    }
}
