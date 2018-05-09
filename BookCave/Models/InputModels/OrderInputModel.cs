namespace BookCave.Models.InputModels
{
    public class OrderInputModel
    {
        public string CreditCard { get; set; }
        public string BillingAddress { get; set; }
        public string CCValidate { get; set; }
        public string CCFirstName { get; set; }
        public string CCLastName { get; set; }
        public int CVV { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
    }
}