using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebCoreTask.Data;
using WebCoreTask.Models;

namespace WebCoreTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Employee/Manage
        public async Task<IActionResult> Manage()
        {
            var employees = await _context.Employees.FromSqlRaw("EXEC ManageEmployee @Action = 'Get'").ToListAsync();
            var viewModel = new EmployeeViewModel
            {
                Employee = new Employee(),
                Employees = employees
            };
            return View(viewModel);
        }

        // GET: /Employee/GetEmployee/{id}
        [HttpGet]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .FromSqlInterpolated($"EXEC ManageEmployee @Action = 'Get', @Id = {id}")
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Manage));
            //return Json(employee);

        }

        // POST: /Employee/SaveEmployee
        [HttpPost]
        public async Task<IActionResult> SaveEmployee(Employee employee, string action)
        {
            if (ModelState.IsValid)
            {
                switch (action)
                {
                    case "Save":
                        if (employee.Id == 0)
                        {
                            // Create new employee
                            await _context.Database.ExecuteSqlInterpolatedAsync(
                                $"EXEC ManageEmployee @Action = 'Add', @Name = {employee.Name}, @Position = {employee.Position}, @Salary = {employee.Salary}");
                        }
                        else
                        {
                            // Update existing employee
                            await _context.Database.ExecuteSqlInterpolatedAsync(
                                $"EXEC ManageEmployee @Action = 'Update', @Id = {employee.Id}, @Name = {employee.Name}, @Position = {employee.Position}, @Salary = {employee.Salary}");
                        }
                        break;

                    case "Delete":
                        // Delete employee
                        await _context.Database.ExecuteSqlInterpolatedAsync(
                            $"EXEC ManageEmployee @Action = 'Delete', @Id = {employee.Id}");
                        break;

                    default:
                        return BadRequest("Invalid action.");
                }

                return RedirectToAction(nameof(Manage));
            }

            // Reload the view with the current employees list if model state is not valid
            var employees = await _context.Employees.FromSqlRaw("EXEC ManageEmployee @Action = 'Get'").ToListAsync();
            var viewModel = new EmployeeViewModel
            {
                Employee = employee,
                Employees = employees
            };
            return View("Manage", viewModel);
        }
    }
}