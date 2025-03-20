using Microsoft.AspNetCore.Mvc;
using Mvp.Application.Dtos.Company;
using Mvp.Application.Services;

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
    public async Task<IActionResult> CreateCompany(
        [FromBody] CompanyRequestDto createCompany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The given data was not on the correct format");
        }

        var newCompany = await companyService.CreateCompany(createCompany);

        return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newCompany);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(
        Guid id, [FromBody] CompanyRequestDto updateCompany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var updatedCompany = await companyService.UpdateCompany(id, updateCompany);

        if(updateCompany is null)
        {
            return BadRequest();
        }
        else
        {
            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        if (await companyService.DeleteCompany(id))
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }       
    }
}
