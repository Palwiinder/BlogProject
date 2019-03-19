using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAssignment.Models.ViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [AllowHtml]
        [Required]
        public string Body { get; set; }
        public bool Published { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public HttpPostedFileBase Media { get; set; }
        public string MediaUrl { get; set; }

        //public BlogPost()
        //{
        //    Comments = new List<Comment>();
        //    this.Created = DateTime.Now;
        //}
    }
}