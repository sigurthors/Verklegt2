using System;
using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Cart
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public List<Book> Books { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}