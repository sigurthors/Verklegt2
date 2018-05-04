namespace BookCave.Models.InputModels
{
    public class BookInputModel
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
    }
}