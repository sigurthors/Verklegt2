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
    public class HomeController : Controller
    {
        private BookRepo _bookRepo;
        public HomeController()
        {
            _bookRepo = new BookRepo();
        }

        public IActionResult Index()
        {
            var Books = _bookRepo.GetTop10Books();
            return View(Books);
        }
    }
}
