using Microsoft.AspNetCore.Mvc;

namespace Poke_Api.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
