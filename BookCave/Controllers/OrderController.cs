using System.Security.Claims;
using System.Threading.Tasks;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private CartRepo _cartRepo;
        private OrderRepo _orderRepo;

        public OrderController(UserManager<ApplicationUser> userManager) 
        {
            _cartRepo = new CartRepo();
            _orderRepo = new OrderRepo();
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            var Orders = _orderRepo.GetOrders(UserId);
            return View(Orders);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderInputModel order)
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _orderRepo.MakeOrder(order, UserId);

            return RedirectToAction("Index");
        }

/*
public async Task<IActionResult> Add(int bookId)
{
    var User = await GetCurrentUserAsync();
    var UserId = User.Id;
    _cartRepo.AddBookToCart(bookId, UserId);

    return RedirectToAction("Index");
}
 */

    }
}