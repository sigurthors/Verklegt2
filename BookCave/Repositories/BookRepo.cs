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
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Isbn = b.Isbn
                        }).ToList();

            return Books;
        }

        public List<BookListViewModel> GetTop10Books()
        {
            var Books = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        orderby b.Rating descending
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Isbn = b.Isbn
                        }).Take(10).ToList();

            return Books;
        }

        public BookListViewModel GetBookById(int? BookId)
        {
            var Author =(from b in _db.Books
                         join a in _db.Authors on b.AuthorId equals a.Id
                         where BookId == b.Id
                         select a.Id).SingleOrDefault();
            
            var Book = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        where BookId == b.Id
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            // Allar bækur eftir sama höfund
                            AuthorsBooks = (from b in _db.Books
                                            join a in _db.Authors on b.AuthorId equals a.Id
                                            where Author == b.AuthorId
                                            where BookId != b.Id
                                            select new BookInAuthorModel
                                            {
                                                Id = b.Id,
                                                Title = b.Title,
                                                CoverImage = b.CoverImg,
                                                AuthorId = b.AuthorId,
                                                Author = a.Name
                                            }).ToList()
                        }).SingleOrDefault();
            return Book;
        }

        public List<BookListViewModel> GetBookByName(string Title)
        {
            var Books = _db.Books    // Starting table
                        .Join(_db.Authors, // Table to join
                        b => b.AuthorId,        // Starting table to compare
                        a => a.Id,   // Joined table var to compare
                        (b, a) => new BookListViewModel{  // Join into a new model
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Isbn = b.Isbn
                        })
                        .Where(b => b.Title.ToLower().Contains(Title.ToLower())).ToList();    // Where, item in table that contains title

            return Books;
        }

        public List<BookListViewModel> GetBookByAuthor(string Author)
        {
            var Authors = _db.Books    // Starting table
                    .Join(_db.Authors, // Table to join
                    b => b.AuthorId,        // Starting table to compare
                    a => a.Id,   // Joined table var to compare
                    (b, a) => new BookListViewModel{  // Join into a new model
                        Id = b.Id,
                        Title = b.Title,
                        CoverImage = b.CoverImg,
                        ReleaseYear = b.ReleaseYear,
                        Rating = b.Rating,
                        AuthorId = a.Id,
                        Author = a.Name,
                        Isbn = b.Isbn
                    })
                    .Where(b => b.Author.ToLower().Contains(Author.ToLower())).ToList();    // Where, item in table that contains title

            return Authors;
        }

        public List<BookListViewModel> GetBookByISBN(string ISBN)
        {
            var Isbns = _db.Books    // Starting table
                    .Join(_db.Authors, // Table to join
                    b => b.AuthorId,        // Starting table to compare
                    a => a.Id,   // Joined table var to compare
                    (b, a) => new BookListViewModel{  // Join into a new model
                        Id = b.Id,
                        Title = b.Title,
                        CoverImage = b.CoverImg,
                        ReleaseYear = b.ReleaseYear,
                        Rating = b.Rating,
                        AuthorId = a.Id,
                        Author = a.Name,
                        Isbn = b.Isbn
                    })
                    .Where(b => b.Isbn.ToLower().Contains(ISBN.ToLower())).ToList();    // Where, item in table that contains title

            return Isbns;
        }

    }
}


