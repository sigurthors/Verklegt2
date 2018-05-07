using System;
using BookCave.Data;
using BookCave.Models;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private AuthenticationDbContext _db;
        
        public UserRepo()
        {
            _db = new AuthenticationDbContext();
        }
    }
}