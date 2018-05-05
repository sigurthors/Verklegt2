using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public List<BookInAuthorModel> AuthorsBooks { get; set; } 
        public string Isbn { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}