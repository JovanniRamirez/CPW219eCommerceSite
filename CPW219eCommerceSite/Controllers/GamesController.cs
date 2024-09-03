using CPW219eCommerceSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;
        public GamesController(VideoGameContext context)
        {
            _context = context;
        }
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
                _context.Games.Add(game); //Prepares insert
                _context.SaveChanges(); // Executes pending insert
                ViewData["Message"] = $"{game.Title} was added successfully!"; // Show success message on page
                return View();
            }

            return View(game);
        }
    }
}
