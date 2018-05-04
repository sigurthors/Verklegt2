using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BirthDate { get; set; }
        public string AuthorImage { get; set; }
        public string Details { get; set; }
        public List<BookInAuthorModel> Books { get; set; }
    }
}