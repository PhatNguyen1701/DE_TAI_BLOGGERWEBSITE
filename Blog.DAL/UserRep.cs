using Blog.Common.DAL;
using Blog.Common.Rsp;
using Blog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DAL
{
    public class UserRep : GenericRep<BloggerWebsiteContext, User>
    {
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(p => p.UserId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.UserId == id);
            m = base.Delete(m);
            return m.UserId;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
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
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Update(user);
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

        public SingleRsp DeleteUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new BloggerWebsiteContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Remove(user);
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

        public User CheckUser(string name)
        {
            User u = new User();
            u = All.FirstOrDefault(n => n.Email == name);
            if (u == null)
                return null;
            return u;
        }

        public SingleRsp UserLogin(string username, string password)
        {
            var res = new SingleRsp();
            res.Data = All.FirstOrDefault(u => u.Email == username && u.Password == password);
            return res;
        }

    }
}
