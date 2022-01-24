using EduHome.Controllers;
using EduHome.Data;
using EduHome.Models;
using EduHome.Models.Repository;
using EduHome.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EduHome.Tests
{
    public class CommentControllerTests
    {
        //private readonly CommentController _sut; //sut = System Under Test
        //private readonly Mock<UserManager<ApplicationUser>> _userManager;
        //private readonly Mock<ICommentRepository> _commentRepositoryMock = new Mock<ICommentRepository>();

        //public CommentControllerTests()
        //{
        //    _sut = new CommentController(null, null);
        //}
        //Use the above later to clean code

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfComments()
        {
            // Arrange
            var mockRepo = new Mock<ICommentRepository>();
            mockRepo.Setup(repo => repo.GetAllComments())
                .ReturnsAsync(GetSampleComments());
            var controller = new CommentController(null, mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CommentVM>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.IEComment.Count());
        }

        [Fact]
        public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<ICommentRepository>();
            mockRepo.Setup(repo => repo.GetAllComments())
                .ReturnsAsync(GetSampleComments());
            var controller = new CommentController(null, mockRepo.Object);
            controller.ModelState.AddModelError("Comment_String", "Required");
            var newComment = new CommentVM()
            {
                Comment = new Comment
                {
                    Commenter = "Monty",
                    Comment_String = null, //Error is here
                    Comment_Date = DateTime.Today
                }
            };

            // Act
            var result = await controller.AddComment(newComment);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        private List<Comment> GetSampleComments()
        {
            var sessions = new List<Comment>();
            sessions.Add(new Comment()
            {
                Id = 1,
                Commenter = "Bobby",
                Comment_String = "Hi i'm Bobby",
                Comment_Highlighted = false,
                Comment_Date = DateTime.Today,
                Comment_Likes = 2,
                Comment_Replies = 2,
                Comment_Reply_To_Id = 2
            });

            sessions.Add(new Comment()
            {
                Id = 2,
                Commenter = "Timon",
                Comment_String = "Hi i'm Timon",
                Comment_Highlighted = true,
                Comment_Date = DateTime.Now,
                Comment_Likes = 251,
                Comment_Replies = 121,
                Comment_Reply_To_Id = 15
            });

            sessions.Add(new Comment()
            {
                Id = 3,
                Commenter = "Pumba",
                Comment_String = "Hi i'm Pumba",
                Comment_Highlighted = false,
                Comment_Date = DateTime.Now,
                Comment_Likes = 3,
                Comment_Replies = 1,
                Comment_Reply_To_Id = 4
            });

            return sessions;
        }
    }
}
