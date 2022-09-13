using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.DAL.Models
{
    public partial class SubReview
    {
        public int SubCommentId { get; set; }
        public int? CommentId { get; set; }

        public virtual Review Comment { get; set; }
    }
}
