using Microsoft.AspNetCore.Mvc;
using Mvp.Application.Dtos.Employee;
using Mvp.Application.Services;

namespace Mvp.Api.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController(IEmployeeService employeeService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        return Ok(await employeeService.GetEmployees());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(Guid id)
    {
        var employee = await employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([
        FromBody] EmployeeRequestDto employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var newEmployee = await employeeService.CreateEmployee(employee);

        if(newEmployee is null)
        {
            return Ok("Employee is already exist");
        }

        return CreatedAtAction(
            nameof(GetEmployee), new { id = newEmployee.Id }, newEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        Guid id, [FromBody] EmployeeRequestDto updateEmployee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var updatedEmployee = await employeeService.UpdateEmployee(
            id, updateEmployee);

        if (updatedEmployee is null)
        {
            return BadRequest();
        }
        else
        {
            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        if (await employeeService.DeleteEmployee(id))
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
