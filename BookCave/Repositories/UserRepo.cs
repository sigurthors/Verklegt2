using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;
        public UserRepo()
        {
            _db = new DataContext();
        }
        public UserViewModel GetUserById(int? id)
        {
            var user = (from u in _db.Users
                        where u.Id == id
                        select new UserViewModel
                        {
                            Name = u.Username,
                            Address = u.Address,
                            FavoriteBook = u.FavoriteBook,
                            Image = u.Image
                        }).SingleOrDefault();
            return user;
        }
    }
}