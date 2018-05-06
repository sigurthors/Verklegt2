using BookCave.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        private CartRepo _cartRepo;

        public CartController() 
        {
            _cartRepo = new CartRepo();
        }

        public IActionResult Index(int? userId)
        {
            //var cart = _cartRepo.GetCartByUserId;
            //return View(cart);
            return View();
        }

    }
}