using Blog.Common.DAL;
using Blog.Common.Rsp;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DAL
{
    public class ReviewRep : GenericRep<BloggerWebsiteContext, Review>
    {
        public override Review Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CommentId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.CommentId == id);
            m = base.Delete(m);
            return m.CommentId;
        }

        public SingleRsp CreateReview(Review review)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Reviews.Add(review);
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
        public SingleRsp UpdateReview(Review review)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Reviews.Add(review);
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

        public SingleRsp DeleteReview(Review review)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Reviews.Remove(review);
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
