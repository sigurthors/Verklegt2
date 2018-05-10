namespace BookCave.Models.ViewModels
{
    public class BookInAuthorModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
    }
}