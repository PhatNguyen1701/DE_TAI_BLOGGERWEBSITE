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
    public class PostController : ControllerBase
    {
        private BlogSvc blogSvc;
        public PostController()
        {
            blogSvc = new BlogSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getBlogById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = blogSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllBlog()
        {
            var res = new SingleRsp();
            res.Data = blogSvc.All;
            return Ok(res);
        }

        [HttpPost("create-blog")]
        public IActionResult CreateBlog([FromBody] BlogReq reqBlog)
        {
            var res = blogSvc.CreateBlog(reqBlog);
            return Ok(res);
        }

        [HttpPut("update-blog")]
        public IActionResult UpdateBlog([FromBody] BlogReq reqBlog)
        {
            var res = blogSvc.UpdateBlog(reqBlog);
            return Ok(res);
        }

        [HttpDelete("delete-blog")]
        public IActionResult DeleteBlog([FromBody] BlogReq reqBlog)
        {
            var res = blogSvc.DeleteBlog(reqBlog);
            return Ok(res);
        }
    }
}
