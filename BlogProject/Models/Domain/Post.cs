using BlogProject.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogAssignment.Models.Domain
{
    public class Post
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public bool Published { get; set; }
        public DateTime DateCreated { get; set; }
        public Post()
        {
            Title = "";
            DateCreated = DateTime.Now;
            Slug = MakeSlug(Title);
        }
        public DateTime DateUpdated { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string MediaUrl { get; set; }


        public static string MakeSlug(string title)
        {
            StringBuilder slug = new StringBuilder();
            bool isSpecialChar = true;
            foreach (char character in title)
            {
                if (char.IsLetterOrDigit(character))
                {
                    slug.Append(char.ToLower(character));
                    isSpecialChar = false;
                }
                else if (char.IsWhiteSpace(character) && !isSpecialChar)
                {
                    slug.Append('-');
                    isSpecialChar = true;
                }
            }

            
            if (isSpecialChar && slug.Length > 0)
                slug.Length--;
            return slug.ToString();
        }

    }
}