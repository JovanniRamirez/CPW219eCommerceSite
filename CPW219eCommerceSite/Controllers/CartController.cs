using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPW219eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;
        private const string Cart = "ShoppingCart";

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
            CartGameViewModel cartGame = new()
            {
                GameId = gameToAdd.GameId,
                Title = gameToAdd.Title,
                Price = gameToAdd.Price
            };

            List<CartGameViewModel> cartGames = GetExistingCartData();
            cartGames.Add(cartGame);
            WriteShoppingCartCookie(cartGames);

            //Todo add item to cart cookie
            TempData["Message"] = $"{gameToAdd.Title} was added to your cart!";
            return RedirectToAction("Index", "Games");
        }

        private void WriteShoppingCartCookie(List<CartGameViewModel> cartGames)
        {
            string cookieData = JsonConvert.SerializeObject(cartGames);

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Return the current list of games in the shopping cart cookie
        /// If there is no cookie, an empty list is returned
        /// </summary>
        /// <returns></returns>
        private List<CartGameViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<CartGameViewModel>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<CartGameViewModel>>(cookie);
            }
        }

        public IActionResult Summary()
        {
            //Read Shopping Cart data and convert to list of view model
            List<CartGameViewModel> cartGames = GetExistingCartData();
            return View(cartGames);
        }

        public IActionResult Remove(int id)
        {
            List<CartGameViewModel> cartGames = GetExistingCartData();

            CartGameViewModel? targetGame = 
                cartGames.Where(g => g.GameId == id).FirstOrDefault();

            cartGames.Remove(targetGame);

            WriteShoppingCartCookie(cartGames);

            return RedirectToAction(nameof(Summary));
        }
    }
}
