using Microsoft.AspNetCore.Mvc;

namespace nest_backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
