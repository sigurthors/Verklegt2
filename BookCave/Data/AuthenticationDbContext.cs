using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookCave.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 
    }
}