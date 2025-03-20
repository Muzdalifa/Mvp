using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database;
using Mvp.Domain.Entities;

namespace Mvp.Api.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController(MvpDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        return Ok(await context.Employees.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(Guid id)
    {
        var employee = await context.Employees
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The given data was not on the correct format");
        }

        var id = Guid.CreateVersion7();

        Employee newEmployee = new Employee
        {
            Id = id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            ManagerId = employee.ManagerId,
            HireDate = employee.HireDate,
            Position = employee.Position,
        };

        await context.Employees.AddAsync(newEmployee);

        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetEmployee),
            new { id = employee.Id },
            employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee updateEmployee)
    {
        Employee? employee = await context.Employees
            .FirstOrDefaultAsync(c => c.Id == id);

        if (employee is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        employee.FirstName = updateEmployee.FirstName;
        employee.LastName = updateEmployee.LastName;
        employee.Email = updateEmployee.Email;
        employee.Position = updateEmployee.Position;
        employee.HireDate = updateEmployee.HireDate;
        employee.ManagerId = updateEmployee.ManagerId;
        employee.PhoneNumber = updateEmployee.PhoneNumber;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        Employee? employee = await FindEmployee(id);

        if (employee is null)
        {
            return NotFound();
        }

        context.Employees.Remove(employee);

        await context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<Employee?> FindEmployee(Guid id)
    {
        if (id == Guid.Empty)
            return null;

        Employee? employee = await context.Employees
            .FirstOrDefaultAsync(c => c.Id == id);

        return employee;
    }
}
