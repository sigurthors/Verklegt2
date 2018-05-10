using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = BuildWebHost(args);
            //Fall sem skoðar hvort það séu gögn í gagnagrunninum
            //SeedData();
            Host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            //Breyta fyrir gagnagrunninn
            var db = new DataContext();


            var InitialAuthors = new List<Author>()
            {
                new Author { Name = "Joanne K. Rowling", BirthDate = "31071965", AuthorImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/J._K._Rowling_2010.jpg/440px-J._K._Rowling_2010.jpg", Details = "Born in Yate, Gloucestershire, England" },
                new Author { Name = "John Ronald Reuel Tolkien", BirthDate = "03011892", AuthorImage = "https://upload.wikimedia.org/wikipedia/commons/b/b4/Tolkien_1916.jpg", Details = "Born in South Africa" },
                new Author { Name = "Dan Brown", BirthDate = "22061964", AuthorImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Dan_Brown_November_2015.jpg/440px-Dan_Brown_November_2015.jpg", Details = "Born in Exeter, New Hampshire, U.S." }
            };

            var InitialBooks = new List<Book>()
            {
                new Book { Title = "Harry Potter and the Chamber of Secrets", ReleaseYear = 2013, Rating = 8.2, AuthorId = 1 },
                new Book { Title = "The Hobbit", ReleaseYear = 1920, Rating = 9.2, AuthorId = 2 },
                new Book { Title = "The Da Vince Code", ReleaseYear = 1987, Rating = 5.2, AuthorId = 3 }
            };

            //Fall sem leyfir okkur að bæta inn lista
            //Til að bæta bara einu tilviki myndum við nota Add í stað AddRange
            db.AddRange(InitialAuthors);
            db.AddRange(InitialBooks);
            //Vistar breytingar
            db.SaveChanges();
            
        }
    }
}
