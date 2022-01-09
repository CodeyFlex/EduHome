﻿using EduHome.Data;
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
                    Comment_String = i.Comment_String,
                    Comment_Likes = i.Comment_Likes,
                    Comment_Replies = i.Comment_Replies,
                    Comment_Reply_To_Id = i.Comment_Reply_To_Id,
                    Comment_Highlighted = i.Comment_Highlighted
                })

        };
            return View(commentVM);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Delete
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Comments.Find(id);
            if(id == null)
            {
                return NotFound();
            }

            _db.Comments.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
