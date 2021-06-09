using Microsoft.AspNetCore.Mvc;

namespace NiceRedirectServer.Controllers
{
    public class CreateRedirectController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}