using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
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

    //[HttpPost]
    //public async Task<IActionResult> CreateDepartment([FromBody] Department department)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest();
    //    }

    //    var id = Guid.CreateVersion7();

    //    Department newDepartment = new Department
    //    {
    //        Id = id,
    //        Name = department.Name,
    //        Location = department.Location,
    //        CompanyId = department.CompanyId,
    //        Description = department.Description
    //    };

    //    await context.Departments.AddAsync(newDepartment);

    //    await context.SaveChangesAsync();

    //    return CreatedAtAction(
    //        nameof(GetDepartment),
    //        new { id = department.Id },
    //        department);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] Department updateDepartment)
    //{
    //    Department? department = await context.Departments
    //        .FirstOrDefaultAsync(c => c.Id == id);

    //    if (department is null)
    //    {
    //        return NotFound();
    //    }

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest();
    //    }

    //    department.Name = updateDepartment.Name;
    //    department.Location = updateDepartment.Location;
    //    department.Description = updateDepartment.Description;
    //    department.CompanyId = updateDepartment.CompanyId;

    //    await context.SaveChangesAsync();

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteDepartment(Guid id)
    //{
    //    Department? department = await FindDepartment(id);

    //    if (department is null)
    //    {
    //        return NotFound();
    //    }

    //    context.Departments.Remove(department);

    //    await context.SaveChangesAsync();

    //    return NoContent();
    //}

}
