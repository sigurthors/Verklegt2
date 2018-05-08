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
        //public Cart GetCartById(int id)
        //{
           // var Cart = (from a in _db.Carts
           //             where a.Id == id
           //             select new CartViewModel{
                //          ....
           //})
         //  return 0
        //}

        public void AddBookToCart(int bookId, string userId)
        {
            var BookToCart = new Cart{ UserId = userId, BookId = bookId };
            _db.Carts.Add(BookToCart);
            _db.SaveChanges();
        }

        public List<CartViewModel> GetCart(string userId)
        {
            var Cart = (from c in _db.Carts
                        join b in _db.Books on c.BookId equals b.Id
                        where c.UserId == userId
                        select new CartViewModel
                        {
                            Title = b.Title,
                            Price = b.Price 
                        }).ToList();
            return Cart;
        }
    }
}