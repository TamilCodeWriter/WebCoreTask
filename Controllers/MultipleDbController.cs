using Microsoft.AspNetCore.Mvc;
using WebCoreTask.Data;
using WebCoreTask.Models;

namespace WebCoreTask.Controllers
{
    public class MultipleDbController : Controller
    {
        private readonly FirstDataBaseContext _firstDbContext;
        private readonly SecondDatabaseContext _secondDbContext;

        public MultipleDbController(FirstDataBaseContext firstDbContext, SecondDatabaseContext secondDbContext)
        {
            _firstDbContext = firstDbContext;
            _secondDbContext = secondDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var dataFromFirstDb = _firstDbContext.Employee.ToList();
            //var dataFromSecondDb = _secondDbContext.Employee.ToList();

            //return Ok(new { dataFromFirstDb, dataFromSecondDb });

            var viewModel = new DBViewModel
            {
                DataFromFirstDb = _firstDbContext.Employee.ToList(),
                DataFromSecondDb = _secondDbContext.Employee.ToList()
            };

            return View(viewModel);
        }
    }
}
