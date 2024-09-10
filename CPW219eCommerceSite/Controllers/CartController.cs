using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;

        public CartController(VideoGameContext context)
        {
            _context = context;
        }
        public IActionResult Add(int id)
        {
            Game? gameToAdd = _context.Games.Where(g => g.GameId == id).SingleOrDefault();

            if (gameToAdd == null)
            {
                // Game with that ID was not found
                TempData["Message"] = "Game not found or no longer Exist!";
                return RedirectToAction("Index", "Games");
            }
            //Todo add item to cart cookie
            TempData["Message"] = $"{gameToAdd.Title} was added to your cart!";
            return RedirectToAction("Index", "Games");
        }
    }
}
