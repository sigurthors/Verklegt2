using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderViewModel
    {
        public List<CartViewModel> Books { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string Time { get; set; }
        public string TotalPrice { get; set; }
    }
}