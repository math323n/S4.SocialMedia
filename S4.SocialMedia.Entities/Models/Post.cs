using System;
using System.Collections.Generic;

namespace S4.SocialMedia.Entities.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int PkPostId { get; set; }
        public int FkUserId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsEdited { get; set; }

        public virtual User FkUser { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
