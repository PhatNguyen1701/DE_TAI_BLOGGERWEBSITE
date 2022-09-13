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
    public class ReviewSvc : GenericSvc<ReviewRep, Review>
    {
        ReviewRep req = new ReviewRep();

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Review m)
        {
            var res = new SingleRsp();

            var m1 = m.PostId > 0 ? _rep.Read(m.CommentId) : _rep.Read(m.Content);
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

        public ReviewSvc() { }

        public SingleRsp CreateReview(ReviewReq reviewReq)
        {
            var res = new SingleRsp();
            Review review = new Review();
            review.CommentId = reviewReq.CommentId;
            review.Content = reviewReq.Content;
            review.CreateAt = reviewReq.CreateAt;
            review.UserId = reviewReq.UserId;
            review.PostId = reviewReq.PostId;
            res = req.CreateReview(review);
            return res;
        }

        public SingleRsp UpdateReview(ReviewReq reviewReq)
        {
            var res = new SingleRsp();
            Review review = new Review();
            review.CommentId = reviewReq.CommentId;
            review.Content = reviewReq.Content;
            review.CreateAt = reviewReq.CreateAt;
            review.UserId = reviewReq.UserId;
            review.PostId = reviewReq.PostId;
            res = req.UpdateReview(review);
            return res;
        }

        public SingleRsp DeleteReview(ReviewReq reviewReq)
        {
            var res = new SingleRsp();
            Review review = new Review();
            review.CommentId = reviewReq.CommentId;
            res = req.DeleteReview(review);
            return res;
        }
    }
}
