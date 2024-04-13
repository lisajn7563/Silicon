using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
