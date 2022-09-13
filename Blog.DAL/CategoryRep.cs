using Blog.Common.DAL;
using Blog.Common.Rsp;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DAL
{
    public class CategoryRep : GenericRep<BloggerWebsiteContext, Category>
    {
        #region -- Overrides --

        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        #endregion

        #region -- Methods --
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Add(category);
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

        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Update(category);
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

        public SingleRsp DeleteCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Remove(category);
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

        #endregion
    }
}
