using Blog.Common;
using Blog.Common.Req;
using Blog.Common.Rsp;
using Blog.DAL;
using Blog.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep req;

        public UserSvc(IConfiguration Configuration)
        {
            configuration = Configuration;
            req = new UserRep();
        }
        private IConfiguration configuration;

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(User m)
        {
            var res = new SingleRsp();

            var m1 = m.UserId > 0 ? _rep.Read(m.UserId) : _rep.Read(m.UserName);
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

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.UserName = userReq.UserName;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            res = req.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.UserName = userReq.UserName;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            res = req.UpdateUser(user);
            return res;
        }

        public SingleRsp DeleteUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            res = req.DeleteUser(user);
            return res;
        }

        public SingleRsp UserLogin(UserReq userReq)
        {
            var res = new SingleRsp();
            var u = new User();
            if(string.IsNullOrEmpty(userReq.Email) || string.IsNullOrEmpty(userReq.Password))
            {
                res.Data = "Please enter Username and Password";
                return res;
            }
            else
            {
                u = req.CheckUser(userReq.Email);
                if(u == null)
                {
                    res.Data = "Username or Password was incorrect, please try again";
                    return res;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var c = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, u.UserId.ToString()),
                new Claim(ClaimTypes.Name, u.Email),
                };
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                    c, expires: DateTime.Now.AddHours(1), signingCredentials: credentials);
                var tokenString = tokenHandler.WriteToken(token);
                res.Data = tokenString;

                return res;
            }
        }
    }
}
