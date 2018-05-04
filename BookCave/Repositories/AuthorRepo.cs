using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db;

        public AuthorRepo()
        {
            _db = new DataContext();
        }

        public List<AuthorListViewModel> GetAllAuthors()
        {
            var Authors = (from a in _db.Authors
                          join b in _db.Books on a.Id equals b.AuthorId
                          orderby a.Name
                          select new AuthorListViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              BirthDate = a.BirthDate,
                              AuthorImage = a.AuthorImage,
                              Details = a.Details,
                              //Bæta bókum í lista?
                          }).Distinct().ToList();

            return Authors;
        }

        public AuthorListViewModel GetAuthorById(int? AuthId)
        {
            //var BookListByAuthor = new List<string>();
            //List<string> BookListByAuthor = (from a in _db.Authors
            //                       join b in _db.Books on a.Id equals b.AuthorId
            //                     where AuthId == b.AuthorId
            //                   select b.Title).ToList();

            var Author = (from a in _db.Authors
                          join b in _db.Books on a.Id equals b.AuthorId
                          where AuthId == a.Id
                          select new AuthorListViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              BirthDate = a.BirthDate,
                              AuthorImage = a.AuthorImage,
                              Details = a.Details,
                              /*Books = (from a in _db.Authors
                                       join b in _db.Books on a.Id equals b.AuthorId
                                       where AuthId == b.AuthorId
                                       select b.Title).ToList()*/
                              Books = (from a in _db.Authors
                                       join b in _db.Books on a.Id equals b.AuthorId
                                       where AuthId == b.AuthorId
                                       select new BookInAuthorModel
                                       {
                                           Id = b.Id,
                                           Title = b.Title,
                                           CoverImage = b.CoverImg,
                                           AuthorId = a.Id,
                                           Author = a.Name
                                       }).ToList()
                          }).FirstOrDefault();
            return Author;
        }
    }
}