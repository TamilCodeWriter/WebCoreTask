using CompanyDetailService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Formats.Asn1;
using WebCoreTask.Class;
using WebCoreTask.Models;


namespace WebCoreTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyDetail _Companyinfo;

        public HomeController(ILogger<HomeController> logger, ICompanyDetail cInfo)
        {
            _logger = logger;
            _Companyinfo = cInfo;
        }
      
        public IActionResult Index()
        {
            MyTask mytaks = new MyTask();
            //mytaks.ReverseString();
            mytaks.ReverseStringDF();
            TempData["CompanyName"] = _Companyinfo.CompanyName;
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
