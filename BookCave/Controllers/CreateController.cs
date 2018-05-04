using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;
using BookCave.Models.InputModels;
using System.Dynamic;
using BookCave.Data.EntityModels;

namespace BookCave.Controllers
{
    public class CreateController : Controller
    {
        private BookRepo _bookRepo;
        private AuthorRepo _authorRepo;

        public CreateController()
        {
            _bookRepo = new BookRepo();
            _authorRepo = new AuthorRepo();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            dynamic mymodel = new ExpandoObject();  
            mymodel.Categories = _bookRepo.GetCategories();  
            mymodel.Authors = _authorRepo.GetAllAuthors();
            return View(mymodel);
        }
        
        [HttpPost]
        public IActionResult Create(string title, int year, double rating, int author, string isbn, int category, string coverImage)
        {
            var NewBook = new Book{ 
                                    Title = title,
                                    ReleaseYear = year,
                                    Rating = rating,
                                    AuthorId = author,
                                    Isbn = isbn,
                                    CategoryId = category,
                                    CoverImg = coverImage
                                  }; 
            _bookRepo.AddBook(NewBook);
            return RedirectToAction("Index", "Create");
        }
    }
}