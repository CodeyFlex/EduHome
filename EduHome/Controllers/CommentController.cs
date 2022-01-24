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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICommentRepository _commentRepository;

        public CommentController(UserManager<ApplicationUser> userManager, ICommentRepository commentRepository)
        {
            _userManager = userManager;
            _commentRepository = commentRepository;
        }

        //Get-Index
        public async Task<IActionResult> Index()
        {
            CommentVM commentVM = new CommentVM()
            {
                IEComment = await _commentRepository.GetAllComments()
            };
            return View(commentVM);
        }

        //Post-Index
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(CommentVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Commenter = _userManager.GetUserName(User),
                    Comment_String = model.Comment.Comment_String,
                    Comment_Date = DateTime.Now
                };

                await _commentRepository.AddAsync(comment);
            }
            return RedirectToAction("Index");
        }

        //Post Delete
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int? id)
        {
            var comment = _commentRepository.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                await _commentRepository.Delete(id);
            }

            return RedirectToAction("Index");
        }

        //Highlight Update
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Highlight(int? id)
        {
            var comment = await _commentRepository.GetComment(id);
            comment.Comment_Highlighted = true; //Changing highlight value
            await _commentRepository.Update(comment);

            return RedirectToAction("Index");
        }

        //UnHighlight Update
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnHighlight(int? id)
        {
            var comment = await _commentRepository.GetComment(id);
            comment.Comment_Highlighted = false; //Changing highlight value
            await _commentRepository.Update(comment);

            return RedirectToAction("Index");
        }
    }
}
