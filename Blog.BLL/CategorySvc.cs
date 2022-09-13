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
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        CategoryRep req = new CategoryRep();
        #region -- Overrides --


        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }


        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.CategoryName);
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

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        #endregion

        #region -- Methods --

        public CategorySvc() { }

        public SingleRsp CreateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryId = categoryReq.CategoryId;
            category.CategoryName = categoryReq.CategoryName;
            res = req.CreateCategory(category);
            return res;
        }

        public SingleRsp UpdateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryId = categoryReq.CategoryId;
            category.CategoryName = categoryReq.CategoryName;
            res = req.UpdateCategory(category);
            return res;
        }

        public SingleRsp DeleteCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryId = categoryReq.CategoryId;
            res = req.DeleteCategory(category);
            return res;
        }
        #endregion
    }
}
