using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.DAL.Models
{
    public partial class Post
    {
        public Post()
        {
            Reviews = new HashSet<Review>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public bool? PostStatus { get; set; }
        public string Images { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
