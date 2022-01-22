using EduHome.Data;
using EduHome.Models;
using EduHome.Models.Repository;
using EduHome.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICommentRepository _commentRepository;

        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, ICommentRepository commentRepository)
        {
            _db = db;
            _userManager = userManager;
            _commentRepository = commentRepository;
        }

        //Get-Index
        public IActionResult Index()
        {
            CommentVM commentVM = new CommentVM()
            {
                IEComment = _commentRepository.GetAllComments()
            };
            return View(commentVM);
        }

        //Post-Index
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CommentVM model)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Commenter = _userManager.GetUserName(User),
                    Comment_String = model.Comment.Comment_String,
                    Comment_Date = DateTime.Now
                };

                _commentRepository.Add(comment);
            }
            return RedirectToAction("Index");
        }

        //Post Delete
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _commentRepository.GetComment(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _commentRepository.Delete(id);
            }

            return RedirectToAction("Index");
        }

        //Highlight Update
        [Authorize(Roles = "Admin")]
        public IActionResult Highlight(int? id)
        {
            var obj = _commentRepository.GetComment(id);
            obj.Comment_Highlighted = true; //Changing highlight value
            _commentRepository.Update(obj);

            return RedirectToAction("Index");
        }

        //UnHighlight Update
        [Authorize(Roles = "Admin")]
        public IActionResult UnHighlight(int? id)
        {
            var obj = _commentRepository.GetComment(id);
            obj.Comment_Highlighted = false; //Changing highlight value
            _commentRepository.Update(obj);

            return RedirectToAction("Index");
        }
    }
}
