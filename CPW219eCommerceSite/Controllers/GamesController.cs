// Ignore Spelling: CPW

using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPW219eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;
     
        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            // Get all games from the database
            //List<Game> games = _context.Games.ToList(); //method syntax
            List<Game> games = await (from game in _context.Games //query syntax
                                select game).ToListAsync();

            // Show them on the page


            return View(_context.Games);
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
    
        public async Task<IActionResult> Edit(int id)
        
        {
            Game gameToEdit = await _context.Games.FindAsync(id);

            if (gameToEdit == null)
            {
                return NotFound();
            }

            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gameModel);
        }
    }

}
