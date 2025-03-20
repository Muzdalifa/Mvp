using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Application.Dtos.Department;
using Mvp.Application.Services;
using Mvp.Domain.Entities;

namespace Mvp.Api.Controllers;

[ApiController]
[Route("departments")]
public class DepartmentController(IDepartmentService departmentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        return Ok(await departmentService.GetDepartments());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(Guid id)
    {
        var department = await departmentService.GetDepartmentById(id);

        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(
        [FromBody] DepartmentRequestDto department)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var newCompany = await departmentService.CreateDepartment(department);

        return CreatedAtAction(nameof(GetDepartment), new { id = newCompany.Id }, newCompany);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(
        Guid id, [FromBody] DepartmentRequestDto updateDepartment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var updatedDepartment = await departmentService.UpdateDepartment(
            id, updateDepartment);

        if (updatedDepartment is null)
        {
            return BadRequest();
        }
        else
        {
            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        if (await departmentService.DeleteDepartment(id))
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
