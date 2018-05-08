using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class CommentRepo
    {
        private DataContext _db;
        public CommentRepo()
        {
            _db = new DataContext();
        }
        public void AddComment(Comment comment)
        {
            _db.Add(comment);
            _db.SaveChanges();
        }
    }
}