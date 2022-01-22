using EduHome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Repository
{
    public class SQLCommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public SQLCommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Comment Add(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return comment;
        }

        public Comment Delete(int? id)
        {
            Comment comment = _db.Comments.Find(id);
            if(comment != null)
            {
                _db.Comments.Remove(comment);
                _db.SaveChanges();
            }
            return comment;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _db.Comments;
        }

        public Comment GetComment(int? id)
        {
            return _db.Comments.Find(id);
        }

        public Comment Update(Comment commentChanges)
        {
            var comment = _db.Comments.Attach(commentChanges);
            comment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return commentChanges;
        }
    }
}
