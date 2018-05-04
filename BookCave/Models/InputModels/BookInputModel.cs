namespace BookCave.Models.InputModels
{
    public class BookInputModel
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public string Isbn { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
    }
}