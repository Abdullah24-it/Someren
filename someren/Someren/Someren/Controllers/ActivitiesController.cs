using Microsoft.AspNetCore.Mvc;

namespace Someren.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
