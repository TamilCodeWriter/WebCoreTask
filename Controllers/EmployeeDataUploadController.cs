    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;
    using WebCoreTask.Data;
    using WebCoreTask.Models;

    namespace WebCoreTask.Controllers
    {
        public class EmployeeDataUpload : Controller
        {
            private readonly ApplicationDbContext _context;

            public EmployeeDataUpload(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Index()
            {
                var employees = _context.Employees.ToList();
                return View(employees);
            }

            [HttpGet]
            public IActionResult Upload()
            {
                return View();
            }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
            public async Task<IActionResult> Upload(IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    ViewBag.Error = "Please select a valid Excel file.";
                    return View();
                }

                var employees = new List<Employee>();

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            employees.Add(new Employee
                            {
                                Name = worksheet.Cells[row, 1].Text,
                                // Age = int.Parse(worksheet.Cells[row, 2].Text),
                                Position = worksheet.Cells[row, 2].Text,
                                Salary = decimal.Parse(worksheet.Cells[row, 3].Text)
                            });
                        }
                    }
                }

                _context.Employees.AddRange(employees);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
    }
