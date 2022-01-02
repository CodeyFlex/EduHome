using EduHome.Data;
using EduHome.Models;
using EduHome.Models.ViewModels;
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

        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            CommentVM commentVM = new CommentVM()
            {
                IEComment = _db.Comments.Select(i => new Comment
                {
                    Commenter = i.Commenter,
                    Comment_Date = i.Comment_Date,
                    Comment_String = i.Comment_String
                })

        };
            return View(commentVM);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
