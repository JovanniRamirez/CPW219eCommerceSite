using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Game game)
        {
            if (ModelState.IsValid)
            {
                // Add to database
                // Show success message on page
                return View();
            }

            return View(game);
        }
}
