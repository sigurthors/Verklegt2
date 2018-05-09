namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CreditCard { get; set; }
        public string BillingAddress { get; set; }
        public string CCValidate { get; set; }
        public string CCFirstName { get; set; }
        public string CCLastName { get; set; }
        public int CVV { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public bool IsPaid { get; set; }
    }
}