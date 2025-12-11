using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
