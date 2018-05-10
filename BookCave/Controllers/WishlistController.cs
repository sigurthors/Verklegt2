using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class WishlistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private WishlistRepo _wishRepo;
        public WishlistController(UserManager<ApplicationUser> userManager)
        {
            _wishRepo = new WishlistRepo();
            _userManager = userManager;
            
        }

        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
           var Wishlist = _wishRepo.GetWishlist(UserId);
            return View(Wishlist);
        }
        public async Task<IActionResult> Add(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _wishRepo.Add(bookId, UserId);
            return RedirectToAction("Index");
        }
    }
}