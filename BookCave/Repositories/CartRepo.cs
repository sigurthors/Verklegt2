using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class CartRepo
    {
        private DataContext _db;
        public CartRepo()
        {
            _db = new DataContext();
        }

        public void AddBookToCart(int bookId, string userId)
        {
            bool isInCart = _db.Carts.Any(u => u.UserId == userId && u.BookId == bookId);
            if(isInCart)
            {
                var Cart = _db.Carts.Where(u => u.UserId == userId && u.BookId == bookId).SingleOrDefault();
                Cart.Quantity += 1;
                _db.SaveChanges();
            }
            else 
            {
                var BookToCart = new Cart{ UserId = userId, BookId = bookId, Quantity = 1};
                _db.Carts.Add(BookToCart);
                _db.SaveChanges();                
            } 

        }

        public void RemoveFromCart(int bookId, string UserId)
        {
            var BookToRemove = _db.Carts.Where(c => c.BookId == bookId && c.UserId == UserId).SingleOrDefault();
            if(BookToRemove.Quantity > 1)
            {
                BookToRemove.Quantity -= 1;
                _db.SaveChanges();
            }
            else if(BookToRemove.Quantity == 1)
            {
                _db.Remove(BookToRemove);
                _db.SaveChanges();
            }
            
        }
        public void IncreaseInCart(int bookId, string UserId)
        {
            var BookToIncrease = _db.Carts.Where(c => c.BookId == bookId && c.UserId == UserId).SingleOrDefault();
            BookToIncrease.Quantity += 1;
             _db.SaveChanges();
        }

        public List<CartViewModel> GetCart(string userId)
        {
            var Cart = (from c in _db.Carts
                        join b in _db.Books on c.BookId equals b.Id
                        where c.UserId == userId
                        select new CartViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Price = b.Price,
                            Quantity = c.Quantity,
                        }).ToList();
            return Cart;
        }
    }
}