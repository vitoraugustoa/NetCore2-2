using Microsoft.AspNetCore.Mvc;

namespace ContatoWebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}