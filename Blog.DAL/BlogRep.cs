using Blog.Common.DAL;
using Blog.Common.Rsp;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DAL
{
    public class BlogRep : GenericRep<BloggerWebsiteContext, Post>
    {
        public override Post Read(int id)
        {
            var res = All.FirstOrDefault(p => p.PostId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.PostId == id);
            m = base.Delete(m);
            return m.PostId;
        }

        public SingleRsp CreateBlog(Post post)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Posts.Add(post);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateBlog(Post post)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Posts.Update(post);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteBlog(Post post)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Posts.Remove(post);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
