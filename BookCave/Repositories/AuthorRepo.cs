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
                              //Books = b.Title
                          }).Distinct().SingleOrDefault();
            return Author;
        }
    }
}