using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvp.Database;
using Mvp.Dtos;
using Mvp.Entities;
using System.Threading.Tasks;

namespace Mvp.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController(MvpDbContext context) : Controller
    {
        // GET: EmployeeController
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await context.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();

            if(employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }

        // GET: EmployeeController/Create
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maximumId = context.Employees.Max(i => i.EmployeeId);
            var newEmployee = new Employee
            {
                EmployeeId = maximumId + 1,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Position = employeeDto.Position,
                ManagerId = employeeDto.ManagerId,
                CompanyId = employeeDto.CompanyId,
                Company = new Company()
                {
                    CompanyId = employeeDto.CompanyId,
                    IsActive = true,
                    Website = employeeDto.Company.Website,
                    Departments = employeeDto.Company.Departments,
                    Location = employeeDto.Company.Location,
                    Name = employeeDto.Company.Name
                },
                Manager = employeeDto.Manager,
                Subordinates = employeeDto.Subordinates
            };

            await context.Employees.AddAsync(newEmployee);
            return CreatedAtAction(nameof(GetById), maximumId, newEmployee);

        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
