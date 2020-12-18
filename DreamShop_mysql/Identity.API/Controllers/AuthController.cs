using CommonHelp;
using CommonHelp.Redis;
using Identity.API.Infrastructure.IRepository;
using Identity.API.Infrastructure.IServices;
using Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Serilog;
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
            Log.Logger.Error("1111111111111111111111111111");
            //int i = Convert.ToInt32("asddsdsd");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空=" + username + '=' + password };

            var member = await _umsMemberRepository.Login(username, password);
            if (member == null)
                return new MessageModel<UmsMember>() { Msg = "账户或密码错误" };
            if (member.Status ==1)
            {
                //获取token
                var token = await GetTokenResponse.GetTokenClient();
                await _redis.SetString("memberId", member.Id.ToString(), TimeSpan.FromMinutes(30));
                return new MessageModel<UmsMember>()
                {
                    Msg = "登录成功!",
                    ResponseJson = new { Token = token, TokenExpires=DateTime.Now, RefreshTokenExpires= DateTime.Now.AddMinutes(30) },
                    Response = member,
                    Success = true
                };
            }
            return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空" };
        }


        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefreshToken")]
        [Authorize]
        public async Task<MessageModel<dynamic>> RefreshToken(string token)
        {

            //获取新token
            var tokens = await GetTokenResponse.GetTokenClient();
            return new MessageModel<dynamic>()
            {
                Msg = "刷新成功!",
                ResponseJson = new { Token = tokens, TokenExpires = DateTime.Now, RefreshTokenExpires = DateTime.Now.AddMinutes(30) },
                Success = true
            };
        }


    }
}
