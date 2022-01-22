using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models.Repository
{
    public class MockCommentRepository : ICommentRepository
    {
        private List<Comment> _commentList;

        public MockCommentRepository()
        {
            _commentList = new List<Comment>()
            {
                new Comment() { Id = 1, Commenter = "Bobby", Comment_String = "Hi i'm Bobby", Comment_Highlighted = false, Comment_Date = DateTime.Today, Comment_Likes = 2, Comment_Replies = 2, Comment_Reply_To_Id = 2 },
                new Comment() { Id = 2, Commenter = "Timon", Comment_String = "Hi i'm Timon", Comment_Highlighted = true, Comment_Date = DateTime.Now, Comment_Likes = 251, Comment_Replies = 121, Comment_Reply_To_Id = 15 },
                new Comment() { Id = 3, Commenter = "Pumba", Comment_String = "Hi i'm Pumba", Comment_Highlighted = false, Comment_Date = DateTime.Now, Comment_Likes = 3, Comment_Replies = 1, Comment_Reply_To_Id = 4 }
            };
        }

        public Comment Add(Comment comment)
        {
            comment.Id = _commentList.Max(c => c.Id) + 1;
            _commentList.Add(comment);
            return comment;
        }

        public Comment Delete(int? id)
        {
            Comment comment = _commentList.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _commentList.Remove(comment);
            }
            return comment;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _commentList;
        }

        public Comment GetComment(int? id)
        {
            return _commentList.FirstOrDefault(c => c.Id == id);
        }

        public Comment Update(Comment commentChanges)
        {
            Comment comment = _commentList.FirstOrDefault(c => c.Id == commentChanges.Id);
            if (comment != null)
            {
                comment.Commenter = commentChanges.Commenter;
                comment.Comment_String = commentChanges.Comment_String;
                comment.Comment_Highlighted = commentChanges.Comment_Highlighted;
                comment.Comment_Date = commentChanges.Comment_Date;
                comment.Comment_Likes = commentChanges.Comment_Likes;
                comment.Comment_Replies = commentChanges.Comment_Replies;
                comment.Comment_Reply_To_Id = commentChanges.Comment_Reply_To_Id;
            }
            return comment;
        }
    }
}
