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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private CartRepo _cartRepo;

        public CartController(UserManager<ApplicationUser> userManager) 
        {
            _cartRepo = new CartRepo();
            _userManager = userManager;
        }

        public IActionResult Index(int? userId)
        {
            //var cart = _cartRepo.GetCartByUserId;
            //return View(cart);
            return View();
        }

        public async Task<IActionResult> Add(int bookId)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _cartRepo.AddBookToCart(bookId, UserId);
 
            return RedirectToAction("Index");
        }

    }
}