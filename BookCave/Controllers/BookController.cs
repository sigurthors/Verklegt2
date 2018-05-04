using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookRepo _bookRepo;
        public BookController()
        {
            _bookRepo = new BookRepo();
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
    }
}