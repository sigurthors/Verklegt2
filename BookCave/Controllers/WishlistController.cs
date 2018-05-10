using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private WishlistRepo _wishRepo;
        private CartRepo _cartRepo;
        
        public WishlistController(UserManager<ApplicationUser> userManager)
        {
            _wishRepo = new WishlistRepo();
            _cartRepo = new CartRepo();
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

        public async Task<IActionResult> Remove(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _wishRepo.Remove(bookId, UserId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MoveToCart(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _cartRepo.AddBookToCart(bookId, UserId);
            _wishRepo.Remove(bookId, UserId);
            return RedirectToAction("Index");
        }
    }
}