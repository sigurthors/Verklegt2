using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class OrderInputModel
    {
        public string TotalPrice { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn kortanúmer")]
        public string CreditCard { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn heimilsfang")]
        public string BillingAddress { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn gildistíma korts")]
        public string CCValidate { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn fyrra nafn")]
        public string CCFirstName { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn seinna nafn")]
        public string CCLastName { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn CVV númer")]
        public int? CVV { get; set; }
        [Required(ErrorMessage = "Vinsamlegast veldu land")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn póstnúmer")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn netfang")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Vinsamlegast sláðu inn borg")]
        public string City { get; set; }
    }
}