using Microsoft.AspNetCore.Mvc;

namespace ECLEXIA.Controllers
{
    public class ReportController : Controller
    {
        public ReportController()
        {

        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return ViewComponent("Dashboard");
        }
    }
}
