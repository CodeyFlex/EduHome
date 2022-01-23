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
        Comment Add(Comment comment);
        Comment Update(Comment commentChanges);
        Comment Delete(int? id);
    }
}
