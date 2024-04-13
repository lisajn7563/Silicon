using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SecurityController : Controller
    {
        [Route("/security")]
        public IActionResult Security()
        {
            return View();
        }
    }
}
