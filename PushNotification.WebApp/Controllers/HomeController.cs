using Microsoft.AspNetCore.Mvc;

namespace PushNotification.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
