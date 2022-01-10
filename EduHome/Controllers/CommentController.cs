using EduHome.Data;
using EduHome.Models;
using EduHome.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        //Get-Index
        public IActionResult Index()
        {
            CommentVM commentVM = new CommentVM()
            {
                IEComment = _db.Comments.Select(i => new Comment
                {
                    Id = i.Id,
                    Commenter = i.Commenter,
                    Comment_Date = i.Comment_Date,
                    Comment_String = i.Comment_String,
                    Comment_Likes = i.Comment_Likes,
                    Comment_Replies = i.Comment_Replies,
                    Comment_Reply_To_Id = i.Comment_Reply_To_Id,
                    Comment_Highlighted = i.Comment_Highlighted
                })

        };
            return View(commentVM);
        }

        //Post-Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CommentVM model)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Commenter = _userManager.GetUserName(User),
                    Comment_String = model.Comment.Comment_String,
                    Comment_Date = DateTime.Today
                };

                _db.Comments.Add(comment);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Comments.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Comments.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Highlight Update
        public IActionResult Highlight(int? id)
        {
            var obj = _db.Comments.Find(id);
            obj.Comment_Highlighted = true;
            _db.Comments.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //UnHighlight Update
        public IActionResult UnHighlight(int? id)
        {
            var obj = _db.Comments.Find(id);
            obj.Comment_Highlighted = false;
            _db.Comments.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
