using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebCoreTask.Models;

namespace WebCoreTask.Controllers
{
    public class SimpleInterestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View(new SimpleIntrestModel());
           
        }
        public IActionResult Index(SimpleIntrestModel model)
        {
            
                if (ModelState.IsValid)
                {
                    model.SimpleInterest = CalculateSimpleInterest(model.PrincipalAmount.Value, model.RateOfInterest.Value, model.YearOfInvestment.Value);
                }

           
            return View(model);
           
        }
        private decimal CalculateSimpleInterest(decimal principal, decimal rate, decimal years)
        {
            return (principal * rate * years) / 100;
        }
    }
}
