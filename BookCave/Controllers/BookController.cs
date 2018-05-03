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

        public IActionResult Top5()
        {
            var Books = _bookRepo.GetTop5Books();
            return View(Books);
        }
    }
}