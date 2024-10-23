using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email_address")))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}