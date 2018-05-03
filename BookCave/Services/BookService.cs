using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        
        public BookService()
        {
            _bookRepo = new BookRepo();
        }

        public List<BookListViewModel> GetAllBooks()
        {
            var Books = _bookRepo.GetAllBooks();
            return Books;
        }
    }
}