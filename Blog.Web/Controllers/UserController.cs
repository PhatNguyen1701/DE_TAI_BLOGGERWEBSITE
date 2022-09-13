using Blog.BLL;
using Blog.Common.Req;
using Blog.Common.Rsp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        private IConfiguration _config;
        public UserController(IConfiguration config)
        {
            userSvc = new UserSvc(config);
            _config = config;
        }

        [HttpPost("get-by-id")]
        public IActionResult getUserById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = userSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllUser()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq reqUser)
        {
            var res = userSvc.CreateUser(reqUser);
            return Ok(res);
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq reqUser)
        {
            var res = userSvc.UpdateUser(reqUser);
            return Ok(res);
        }

        [HttpDelete("delete-user")]
        public IActionResult DeleteUser([FromBody] UserReq reqUser)
        {
            var res = userSvc.DeleteUser(reqUser);
            return Ok(res);
        }

        [HttpPost("user-login")]
        public IActionResult UserLogin([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res.Data = userSvc.UserLogin(userReq);
            return Ok(new
            {
                Username = userReq.Email,
                Password = userReq.Password,
                Token = res
            });
        }
    }
}
