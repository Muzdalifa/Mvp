using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Application.Dtos;
using Mvp.Application.Services;
using Mvp.Domain.Entities;

namespace Mvp.Api.Controllers;

[ApiController]
[Route("companies")]
public class CompanyController(ICompanyService companyService) : Controller()
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await companyService.GetCompanies());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await companyService.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyRequestDto createCompany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The given data was not on the correct format");
        }

        var newCompany = await companyService.CreateCompany(createCompany);

        return Ok(newCompany);
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] Company updateCompany)
    //{
    //    Company? company = await context.Companies
    //        .FirstOrDefaultAsync(c => c.Id == id);

    //    if (company is null)
    //    {
    //        return NotFound();
    //    }

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest();
    //    }

    //    company.Name = updateCompany.Name;
    //    company.Address = updateCompany.Address;
    //    company.Description = updateCompany.Description;
    //    company.IsActive = updateCompany.IsActive;
    //    company.Website = updateCompany.Website;

    //    await context.SaveChangesAsync();
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteCompany(Guid id)
    //{
    //    Company? company = await FindCompany(id);

    //    if(company is null)
    //    {
    //        return NotFound();
    //    }

    //    context.Companies.Remove(company);

    //    await context.SaveChangesAsync();

    //    return NoContent();
    //}

    //private async Task<Company?> FindCompany(Guid id)
    //{
    //    if (id == Guid.Empty)
    //        return null;

    //    Company? company = await context.Companies
    //        .FirstOrDefaultAsync(c => c.Id == id);

    //    return company;
    //}
}
