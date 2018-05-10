using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private CartRepo _cartRepo;

        public CartController(UserManager<ApplicationUser> userManager) 
        {
            _cartRepo = new CartRepo();
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            
            
            var Cart = _cartRepo.GetCart(UserId);

            return View(Cart);
        }

        public async Task<IActionResult> Add(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _cartRepo.AddBookToCart(bookId, UserId);
 
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _cartRepo.RemoveFromCart(bookId, UserId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Increase(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _cartRepo.IncreaseInCart(bookId, UserId);
            return RedirectToAction("Index");
        }
    }
}