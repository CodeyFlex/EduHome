using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Repository
{
    public interface ICommentRepository
    {
        Task<Comment> GetComment(int? id);
        Task<IEnumerable<Comment>> GetAllComments();
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> Update(Comment commentChanges);
        Task<Comment> Delete(int? id);
    }
}
