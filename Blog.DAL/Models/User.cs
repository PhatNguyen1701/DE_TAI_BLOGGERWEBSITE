using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
