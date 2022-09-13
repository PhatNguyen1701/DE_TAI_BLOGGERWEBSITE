using Blog.BLL;
using Blog.Common.Req;
using Blog.Common.Rsp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllCategory()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCategory(categoryReq);
            return Ok(res);
        }

        [HttpPut("update-category")]
        public IActionResult UpdateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.UpdateCategory(categoryReq);
            return Ok(res);
        }

        [HttpDelete("delete-category")]
        public IActionResult DeleteCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.DeleteCategory(categoryReq);
            return Ok(res);
        }
    }
}
