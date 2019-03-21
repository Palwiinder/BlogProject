using System;
using BlogProject.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.ViewModels
{
    public class ShowCommentViewModel
    {
        public string Body { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string UserId { get;set; }
        public string ReasonOfUpdating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
      
    }
}