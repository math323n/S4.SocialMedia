using System;
using System.Collections.Generic;

namespace S4.SocialMedia.Entities.Models
{
    public partial class Comment
    {
        public int PkCommentId { get; set; }
        public string FkUserId { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int FkPostId { get; set; }

        public virtual Post FkPost { get; set; }
        public virtual User FkUser { get; set; }
    }
}
