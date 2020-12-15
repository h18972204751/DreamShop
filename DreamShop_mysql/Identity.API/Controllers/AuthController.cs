using CommonHelp;
using CommonHelp.Redis;
using Identity.API.Infrastructure.IRepository;
using Identity.API.Infrastructure.IServices;
using Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IRedisBasketRepository _redis;
        readonly IUmsMemberRepository _umsMemberRepository;

        public AuthController(IRedisBasketRepository redis, IUmsMemberRepository umsMemberRepository)
        {
            this._redis = redis;
            this._umsMemberRepository = umsMemberRepository;
        }

        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<MessageModel<UmsMember>> Login([FromForm] string username, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空=" + username + '=' + password };

            var logins = await _umsMemberRepository.Login(username, password);
            if (logins == null)
                return new MessageModel<UmsMember>() { Msg = "账户或密码错误" };
            if (logins.Status ==1)
            {
                //获取token
                var token = await GetTokenResponse.GetTokenClient();
                await _redis.SetString("LoginId", logins.Id.ToString(), TimeSpan.FromMinutes(30));
                return new MessageModel<UmsMember>()
                {
                    Msg = "登录成功!",
                    ResponseJson = new { Token = token, TokenExpires=DateTime.Now, RefreshTokenExpires= DateTime.Now.AddMinutes(30) },
                    Response = logins,
                    Success = true
                };
            }
            return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空" };
        }


        [HttpPost]
        public async Task<MessageModel<dynamic>> RefreshToken(string token)
        {
            

        }

    }
}
