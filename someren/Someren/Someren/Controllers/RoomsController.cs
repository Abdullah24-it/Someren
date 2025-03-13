using Microsoft.AspNetCore.Mvc;

namespace Someren.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
