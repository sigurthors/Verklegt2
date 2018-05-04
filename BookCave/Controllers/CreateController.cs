using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class CreateController : Controller
    {
        private BookRepo _bookRepo;

        public CreateController()
        {
            _bookRepo = new BookRepo();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(string title, int year, double rating, string author, string isbn, string coverImage)
        {
            return RedirectToAction("Index", "Create");
        }
    }
}