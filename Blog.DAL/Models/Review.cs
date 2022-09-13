using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.DAL.Models
{
    public partial class Review
    {
        public Review()
        {
            SubReviews = new HashSet<SubReview>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public string CreateAt { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SubReview> SubReviews { get; set; }
    }
}
