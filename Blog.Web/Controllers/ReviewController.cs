using Blog.BLL;
using Blog.Common.Req;
using Blog.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private ReviewSvc reviewSvc;
        public ReviewController()
        {
            reviewSvc = new ReviewSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getReviewById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = reviewSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllReview()
        {
            var res = new SingleRsp();
            res.Data = reviewSvc.All;
            return Ok(res);
        }

        [HttpPost("create-review")]
        public IActionResult CreateBlog([FromBody] ReviewReq reqReview)
        {
            var res = reviewSvc.CreateReview(reqReview);
            return Ok(res);
        }

        [HttpPut("update-review")]
        public IActionResult UpdateBlog([FromBody] ReviewReq reqReview)
        {
            var res = reviewSvc.UpdateReview(reqReview);
            return Ok(res);
        }

        [HttpDelete("delete-review")]
        public IActionResult DeleteBlog([FromBody] ReviewReq reqReview)
        {
            var res = reviewSvc.DeleteReview(reqReview);
            return Ok(res);
        }
    }
}
