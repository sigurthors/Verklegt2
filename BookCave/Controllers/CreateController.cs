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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            var Books = _bookRepo.GetAllBooks();
            return View(Books);
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


        public IActionResult Remove(int id)
        {
            _bookRepo.RemoveBook(id);
            return RedirectToAction("Index", "Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            dynamic mymodel = new ExpandoObject();  
            mymodel.Categories = _bookRepo.GetCategories();  
            mymodel.Authors = _authorRepo.GetAllAuthors();
            mymodel.Book = _bookRepo.GetBookById(id);
            
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Edit(int id, string title, int year, double rating, int author, string isbn, int category, string coverImage)
        {
            _bookRepo.EditBook(id, title, year, rating, author, isbn, category, coverImage);
            return RedirectToAction("Index", "Create");
        }
    }
}