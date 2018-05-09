using System;
using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}