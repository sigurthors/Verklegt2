using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db;
        public OrderRepo()
        {
            _db = new DataContext();
        }

        public void MakeOrder(OrderInputModel order, string userId)
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("dd/MM/yyyy hh:mm:ss"); //("yyyy, MM, dd, hh, mm, ss")
            var Order = new Order { 
                                    UserId = userId,
                                    CreditCard = order.CreditCard,
                                    BillingAddress = order.BillingAddress,
                                    CCValidate = order.CCValidate,
                                    CCFirstName = order.CCFirstName,
                                    CCLastName = order.CCLastName,
                                    CVV = order.CVV,
                                    Country = order.Country,
                                    PostalCode = order.PostalCode,
                                    EmailAddress = order.EmailAddress,
                                    IsPaid = true,
                                    Time = formattedTime
                                   };
            _db.Add(Order);
            _db.SaveChanges();

            var OrderFromDB = _db.Orders.Where(o => o.Time == formattedTime).SingleOrDefault();
            var Cart = _db.Carts.Where(c => c.UserId == userId).ToList();

            var OrderedBooks = new List<OrderedBook>();
            
            foreach(var cart in Cart){
                OrderedBooks.Add(new OrderedBook { UserId = userId, BookId = cart.BookId, Quantity = cart.Quantity, OrderId = OrderFromDB.Id, Time = formattedTime});
            }

            _db.RemoveRange(Cart);

            _db.AddRange(OrderedBooks);
            _db.SaveChanges();
        }

        public List<OrderViewModel> GetOrders(string userId)
        {
            var Orders = (from o in _db.Orders
                        where o.UserId == userId
                        select new OrderViewModel
                        {
                            Books = (from ob in _db.OrderedBooks
                                    join b in _db.Books on ob.BookId equals b.Id
                                    where o.Time == ob.Time
                                    select new CartViewModel{
                                        Title = b.Title,
                                        Price = b.Price,
                                        Quantity = ob.Quantity
                                    }).ToList(),
                            Address = o.BillingAddress,
                            Country = o.Country,
                            PostalCode = o.PostalCode,
                            EmailAddress = o.EmailAddress,
                            Time = o.Time
                        }).Distinct().ToList();
            return Orders;
        }
    }
}