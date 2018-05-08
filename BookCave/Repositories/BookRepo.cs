using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
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
                        join c in _db.Categories on b.CategoryId equals c.Id
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Isbn = b.Isbn,
                            CategoryId = c.Id,
                            Category = c.CategoryName,
                            Price = b.Price,
                    
                        }).ToList();

            return Books;
        }

        public List<BookListViewModel> GetTop10Books()
        {
            var Books = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        join c in _db.Categories on b.CategoryId equals c.Id
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
                            Isbn = b.Isbn,
                            CategoryId = c.Id,
                            Category = c.CategoryName
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
                        join c in _db.Categories on b.CategoryId equals c.Id
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
                            Isbn = b.Isbn,
                            CategoryId = c.Id,
                            Category = c.CategoryName,
                            Price = b.Price,
                            Comments = (from b in _db.Books
                                        join c in _db.Comments on b.Id equals c.BookId
                                        where BookId == c.BookId 
                                        select c).ToList(),
                            // Allar bækur eftir sama höfund nema sú sem er verið að skoða
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
            var Books = (from b in _db.Books
                            join a in _db.Authors on b.AuthorId equals a.Id
                            join c in _db.Categories on b.CategoryId equals c.Id
                            select new BookListViewModel{  // Join into a new model
                                Id = b.Id,
                                Title = b.Title,
                                CoverImage = b.CoverImg,
                                ReleaseYear = b.ReleaseYear,
                                Rating = b.Rating,
                                AuthorId = a.Id,
                                Author = a.Name,
                                Isbn = b.Isbn,
                                CategoryId = c.Id,
                                Category = c.CategoryName
                            }).Where(b => b.Title.ToLower().Contains(Title.ToLower())).ToList();

            return Books;
        }

        public List<BookListViewModel> GetBookByAuthor(string Author)
        {
            var Authors = (from b in _db.Books
                            join a in _db.Authors on b.AuthorId equals a.Id
                            join c in _db.Categories on b.CategoryId equals c.Id
                            select new BookListViewModel{
                                Id = b.Id,
                                Title = b.Title,
                                CoverImage = b.CoverImg,
                                ReleaseYear = b.ReleaseYear,
                                Rating = b.Rating,
                                AuthorId = a.Id,
                                Author = a.Name,
                                Isbn = b.Isbn,
                                CategoryId = c.Id,
                                Category = c.CategoryName
                            }).Where(b => b.Author.ToLower().Contains(Author.ToLower())).ToList();    // Where, item in table that contains title

            return Authors;
        }

        public List<BookListViewModel> GetBookByISBN(string ISBN)
        {
            var Isbns = (from b in _db.Books
                        join a in _db.Authors on b.AuthorId equals a.Id
                        join c in _db.Categories on b.CategoryId equals c.Id
                        select new BookListViewModel{  // Join into a new model
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            Rating = b.Rating,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Isbn = b.Isbn,
                            CategoryId = c.Id,
                            Category = c.CategoryName
                        }).Where(b => b.Isbn.ToLower().Contains(ISBN.ToLower())).ToList();    // Where, item in table that contains title

            return Isbns;
        }

        public List<CategoriesListViewModel> GetCategories()
        {
            var Categories = (from c in _db.Categories
                            select new CategoriesListViewModel
                            {
                                Id = c.Id,
                                CategoryName = c.CategoryName,
                            }
                            ).ToList();
            return Categories;
        }

        public List<BookListViewModel> GetBookByCategory(int? CatId)
        {
            var Books = (from c in _db.Categories
                        join b in _db.Books on c.Id equals b.CategoryId
                        join a in _db.Authors on b.AuthorId equals a.Id
                        where CatId == c.Id
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            CoverImage = b.CoverImg,
                            ReleaseYear = b.ReleaseYear,
                            AuthorId = a.Id,
                            Author = a.Name,
                            Rating = b.Rating,
                            Isbn = b.Isbn,
                            CategoryId = c.Id,
                            Category = c.CategoryName
                        }).ToList();

            return Books;
        }

        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            var Book = _db.Books.Where(b => b.Id == id).SingleOrDefault();
            _db.Remove(Book);
            _db.SaveChanges();
        }

        public void EditBook(int id, string title, int year, double rating, int author, string isbn, int category, string coverImage)
        {
            var Book = _db.Books.Where(b => b.Id == id).SingleOrDefault();
            Book.Title = title;
            Book.ReleaseYear = year;
            Book.Rating = rating;
            Book.AuthorId = author;
            Book.Isbn = isbn;
            Book.CategoryId = category;
            Book.CoverImg = coverImage;
            _db.SaveChanges();
        }
    }
}


