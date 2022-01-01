using EduHome.Data;
using EduHome.Models;
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
            IEnumerable<Comment> objList = _db.Comments;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
