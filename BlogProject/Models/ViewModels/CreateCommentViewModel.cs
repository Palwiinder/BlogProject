
using BlogAssignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.Models.ViewModels
{
    public class CreateCommentViewModel
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public string ReasonOfUpdating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}