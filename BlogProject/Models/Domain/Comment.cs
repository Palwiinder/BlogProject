using BlogAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Domain
{
    public class Comment
    {
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public string AuthorId { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string ReasonOfUpdating { get; set; }
        public Comment()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
    }
}