using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Req
{
    public class BlogReq
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? PostStatus { get; set; }
        public string Images { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
    }
}
