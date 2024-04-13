using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubscribeController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeForm form)
        {
           if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7146/api/Subscribers?key=de94fdf1-37f4-40cd-b634-8a9367b98c1a", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["StatusMessage"] = "You are now subscribed";
                    return RedirectToAction("Home", "Default", "subscribe" );
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict) 
                {
                    TempData["StatusMessage"] = "You are already subscribed";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
            }

            TempData["StatusMessage"] = "Something went wrong";
            return RedirectToAction("Home", "Default", "subscribe");
        }
    }
}
