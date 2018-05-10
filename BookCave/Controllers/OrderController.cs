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

        public IActionResult Checkout(float total)
        {
            ViewBag.TotalPrice = total;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderInputModel order)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            _orderRepo.MakeOrder(order, UserId);

            return RedirectToAction("Review");
        }

        public async Task<IActionResult> Review()
        {
            var User = await GetCurrentUserAsync();
            var UserId = User.Id;
            var Order = _orderRepo.GetLastOrder(UserId);
            return View(Order);
        }

        public async Task<IActionResult> Confirm(bool confirm)
        {
            if(confirm == false)
            {
                var User = await GetCurrentUserAsync();
                var UserId = User.Id;
                var Order = _orderRepo.LastOrder(UserId);
                _orderRepo.DeleteOrder(Order);
            }
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