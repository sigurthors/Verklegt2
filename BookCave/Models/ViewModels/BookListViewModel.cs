namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}