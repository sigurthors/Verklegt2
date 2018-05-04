using BookCave.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H30;Persist Security Info=False;User ID=VLN2_2018_H30_usr;Password=freshFoo)80;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
        }
    }
}

//1
//Bætir inn töflu í gagnagrunn
//dotnet ef migrations add .... --context DataContext

//2
//Þetta kemur töflunni í grunninn
//dotnet ef database update --context DataContext