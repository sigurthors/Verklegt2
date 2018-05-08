using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;
using Microsoft.AspNetCore.Authorization;
using BookCave.Data.EntityModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookRepo _bookRepo;
        private CommentRepo _commentRepo;
        public BookController()
        {
            _bookRepo = new BookRepo();
            _commentRepo = new CommentRepo();
        }

        public IActionResult Index()
        {
            var Books = _bookRepo.GetAllBooks();
            return View(Books);
        }

        public IActionResult Top10()
        {
            var Books = _bookRepo.GetTop10Books();
            return View(Books);
        }

        public IActionResult Details(int? id)
        {
            var Book = _bookRepo.GetBookById(id);
            return View(Book);
        }

        public IActionResult Search(string search)
        {
            var Books = _bookRepo.GetBookByName(search);
            var Authors = _bookRepo.GetBookByAuthor(search);
            var Isbn = _bookRepo.GetBookByISBN(search);

            var BooksAndAuthorsAndISBN = Books.Concat(Authors).Concat(Isbn).ToList();
            
            return View(BooksAndAuthorsAndISBN);
        }

        public IActionResult Categories()
        {
            var Categories = _bookRepo.GetCategories();
            return View(Categories);
        }
        public IActionResult Category(int? id)
        {
            var Books = _bookRepo.GetBookByCategory(id);
            return View(Books);
        }
        public IActionResult Comment()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Comment(string review)
        {
            var NewComment = new Comment {
                Review = review
            };
            _commentRepo.AddComment(NewComment);
            return RedirectToAction("Index", "Details");
        }
        
    }
}