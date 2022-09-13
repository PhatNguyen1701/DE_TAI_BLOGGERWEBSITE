using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Req
{
    public class ReviewReq
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string CreateAt { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
}
