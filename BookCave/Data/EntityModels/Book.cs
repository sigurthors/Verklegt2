namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int AuthorId { get; set; }
        public string Isbn { get; set; }
        public int CategoryId { get; set; }
        public string CoverImg { get; set; }
        public float Price { get; set; }
    }
}