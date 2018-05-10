using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class WishlistRepo
    {
        private DataContext _db;

        public WishlistRepo()
        {
            _db = new DataContext();
        }

        public void Add(int bookId, string userId)
        {
            var Book = _db.Books.Where(b => b.Id == bookId);
            var WishlistItem = new Wishlist{ BookId = bookId, UserId = userId};
            _db.Wishlists.Add(WishlistItem);
            _db.SaveChanges();
        }

        public void Remove(int bookId, string userId)
        {
            var WishlistItem = (from wi in _db.Wishlists
                                where wi.BookId == bookId
                                where wi.UserId == userId
                                select wi).Single();
            _db.Wishlists.Remove(WishlistItem);
            _db.SaveChanges();
        }

        public List<WishlistViewModel> GetWishlist(string userId)
        {
            var Books = (from wb in _db.Wishlists
                        join b in _db.Books on wb.BookId equals b.Id
                        where wb.UserId == userId
                        select new WishlistViewModel{
                            Title = b.Title,
                            BookId = b.Id
                        }).ToList();
            return Books;
        }
    }
}