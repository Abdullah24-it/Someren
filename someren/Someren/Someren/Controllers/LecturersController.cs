using Microsoft.AspNetCore.Mvc;

namespace Someren.Controllers
{
    public class LecturersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
