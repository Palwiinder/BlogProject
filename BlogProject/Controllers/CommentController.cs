using BlogAssignment.Controllers;
using BlogAssignment.Models;
using BlogProject.Models.Domain;
using BlogProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private ApplicationDbContext DbContext;

        public CommentController()
        {
            DbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult Create(CreateCommentViewModel formData)
        {
            return SaveComment(null, formData);
        }
        private ActionResult SaveComment(int? id, CreateCommentViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Comment comment;
            if (!id.HasValue)
            {
                var userId = User.Identity.GetUserId();
                var user = DbContext.Users.FirstOrDefault(p => p.Id == userId);
                var post = DbContext.PostDatabase.FirstOrDefault(p => p.PostId == formData.PostId);

                if (post == null)
                {
                    return View();
                }

                comment = new Comment();
                comment.Body = formData.Body;

                comment.AuthorId = userId;               
                comment.UserId = userId;
                comment.User = user;

                DbContext.CommentDatabase.Add(comment);
                post.Comments.Add(comment);
            }
            else
            {
                comment = DbContext.CommentDatabase.FirstOrDefault(p => p.CommentId == id);
                if (comment == null)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                comment.Body = formData.Body;
                comment.ReasonOfUpdating = formData.ReasonOfUpdating;
                comment.DateUpdated = DateTime.Now;
            }
            DbContext.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }
            string userId = User.Identity.GetUserId();
            var comment = DbContext.CommentDatabase.FirstOrDefault(p => p.CommentId == id);

            if (comment == null)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }

            var model = new CreateCommentViewModel();
            model.Body = comment.Body;
            model.ReasonOfUpdating = comment.ReasonOfUpdating;

            model.DateUpdated = comment.DateUpdated;


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, CreateCommentViewModel formData)
        {
            return SaveComment(id, formData);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }
            string userId = User.Identity.GetUserId();
            var comment = DbContext.CommentDatabase.FirstOrDefault(p => p.CommentId == id && p.UserId == userId);
            if (comment != null)
            {
                DbContext.CommentDatabase.Remove(comment);
                DbContext.SaveChanges();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }

}
