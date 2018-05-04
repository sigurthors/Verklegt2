using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vinsamlegast sláðu inn netfang")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn notendanafn")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn lykilorð")]
        public string Password { get; set; }
    }
}