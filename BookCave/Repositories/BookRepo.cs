using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        //Breyta fyrir gagnagrunninn.
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }

        public List<BookListViewModel> GetAllBooks()
        {
            //Þetta fer í gagnagrunninn nær í bækur þar og setur inn
            //inn í BookListViewModel til að sýna ekki entity modelið
            //og breytir þessu svo í lista sem við skilum svo.
            var Books = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name
                        }).ToList();

            return Books;
        }

        public List<BookListViewModel> GetTop5Books()
        {
            var Books = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        orderby b.Rating descending
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name
                        }).Take(5).ToList();

            return Books;
        }
    }
}