using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Req
{
    public class UserReq
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
