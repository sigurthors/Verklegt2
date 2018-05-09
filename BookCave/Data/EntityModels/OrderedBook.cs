namespace BookCave.Data.EntityModels
{
    public class OrderedBook
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public string Time { get; set; }
    }
}