﻿using BlogProject.Models.Domain;
using BlogProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAssignment.Models.ViewModels
{
    public class ShowPostsViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public bool Published { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public  List<ShowCommentViewModel> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int PostId { get; set; }
        public string MediaUrl { get; set; }
    }
}