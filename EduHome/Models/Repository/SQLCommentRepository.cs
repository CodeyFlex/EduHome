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

        public async Task<Comment> GetComment(int? id)
        {
            return await _db.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await Task.FromResult(_db.Comments);
        }

        public async Task <Comment> AddAsync(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> Update(Comment commentChanges)
        {
            var comment = _db.Comments.Attach(commentChanges);
            comment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
            return commentChanges;
        }

        public async Task<Comment> Delete(int? id)
        {
            Comment comment = _db.Comments.Find(id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
            }
            return comment;
        }
    }
}
