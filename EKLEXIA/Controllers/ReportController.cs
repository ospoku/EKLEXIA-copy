using Microsoft.AspNetCore.Mvc;

namespace ECLEXIA.Controllers
{
    public class ReportController : Controller
    {
        public ReportController()
        {

        }
        [HttpGet]
        public IActionResult ViewDashboard()
        {
            return ViewComponent("ViewDashboard");
        }
    }
}
