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
        public async Task<IActionResult> Create(Models.Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);           //Prepares insert
                // For async code info in the tutorial
                // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-8.0#asynchronous-code
                
                await _context.SaveChangesAsync();  // Executes pending insert
                
                ViewData["Message"] = $"{game.Title} was added successfully!"; // Show success message on page
                return View();
            }

            return View(game);
        }
    }
}
