using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
