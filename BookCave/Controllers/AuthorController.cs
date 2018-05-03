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
    public class AuthorController : Controller
    {
        private AuthorRepo _authorRepo;

        public AuthorController()
        {
            _authorRepo = new AuthorRepo();
        }

        public IActionResult Index()
        {
            var Authors = _authorRepo.GetAllAuthors();
            return View(Authors);
        }
    }
}
