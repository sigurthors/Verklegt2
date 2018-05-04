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
<<<<<<< HEAD
        public List<BookInAuthorModel> AuthorsBooks { get; set; } 
=======
>>>>>>> fe9e96650794944a1c15259ef27d1e3008998675
        public string Isbn { get; set; }
    }
}