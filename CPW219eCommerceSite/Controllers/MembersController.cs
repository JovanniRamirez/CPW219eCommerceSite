using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly VideoGameContext _context;

        public MembersController(VideoGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to Member object
                Member newMember = new Member
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                // Add the new member to the database
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                // Redirect to the home page
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Check if the member exists in the database
                // CHecking DB for credentials
                Member? m = (from member in _context.Members
                                where member.Email == loginModel.Email
                                && member.Password == loginModel.Password
                                select member).SingleOrDefault();

                // If exist,, send to a home page
                if (m != null)
                {
                    return RedirectToAction("Index", "Home");
                }               
                
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            // If no record matches, display an Error
            return View(loginModel);
        }
    }
}
