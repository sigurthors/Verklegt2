using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BookCave.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public string FavoriteBook { get; set; }
        
    }
}