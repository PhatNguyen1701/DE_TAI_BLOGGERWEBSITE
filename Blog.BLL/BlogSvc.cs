using Blog.Common;
using Blog.Common.Req;
using Blog.Common.Rsp;
using Blog.DAL;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.BLL
{
    public class BlogSvc : GenericSvc<BlogRep, Post>
    {
        BlogRep req = new BlogRep();

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Post m)
        {
            var res = new SingleRsp();

            var m1 = m.PostId > 0 ? _rep.Read(m.PostId) : _rep.Read(m.Title);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.Data = m;

            return res;
        }

        public BlogSvc() { }

        public SingleRsp CreateBlog(BlogReq blogReq)
        {
            var res = new SingleRsp();
            Post post = new Post();
            post.PostId = blogReq.PostId;
            post.Title = blogReq.Title;
            post.Content = blogReq.Content;
            post.PostStatus = blogReq.PostStatus;
            post.Images = blogReq.Images;
            post.CategoryId = blogReq.CategoryId;
            post.UserId = blogReq.UserId;
            res = req.CreateBlog(post);
            return res;
        }

        public SingleRsp UpdateBlog(BlogReq blogReq)
        {
            var res = new SingleRsp();
            Post post = new Post();
            post.PostId = blogReq.PostId;
            post.Title = blogReq.Title;
            post.Content = blogReq.Content;
            post.CreateAt = blogReq.CreatedAt;
            post.PostStatus = blogReq.PostStatus;
            post.Images = blogReq.Images;
            post.CategoryId = blogReq.CategoryId;
            post.UserId = blogReq.UserId;
            res = req.UpdateBlog(post);
            return res;
        }

        public SingleRsp DeleteBlog(BlogReq blogReq)
        {
            var res = new SingleRsp();
            Post post = new Post();
            post.PostId = blogReq.PostId;
            res = req.DeleteBlog(post);
            return res;
        }
    }
}
