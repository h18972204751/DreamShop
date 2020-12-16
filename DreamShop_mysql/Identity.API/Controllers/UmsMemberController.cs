using CommonHelp;
using CommonHelp.Redis;
using Identity.API.Infrastructure.IRepository;
using Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UmsMemberController : ControllerBase
    {
        readonly IRedisBasketRepository _redis;
        readonly IUmsMemberRepository _umsMemberRepository;

        public UmsMemberController(IRedisBasketRepository redis, IUmsMemberRepository umsMemberRepository)
        {
            this._redis = redis;
            this._umsMemberRepository = umsMemberRepository;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="loginsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUpUser")]
        public async Task<MessageModel<UmsMember>> SignUpUser([FromBody] UmsMember umsMember)
        {
            if (umsMember == null)
                return new MessageModel<UmsMember>() { Msg = "信息输入有误,请稍后再试!" };
            if (string.IsNullOrWhiteSpace(umsMember.Username) || string.IsNullOrWhiteSpace(umsMember.Password))
                return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空" };
            if (string.IsNullOrWhiteSpace(umsMember.Phone))
                return new MessageModel<UmsMember>() { Msg = "手机号不能为空" };
            if (string.IsNullOrWhiteSpace(umsMember.Nickname))
                return new MessageModel<UmsMember>() { Msg = "昵称不能为空" };

            var loginlist = _umsMemberRepository.GetAsync(o => o.Username == umsMember.Username && o.Password == umsMember.Password);
            if (loginlist !=null)
                return new MessageModel<UmsMember>() { Msg = "登录名已存在!请重新输入" };
            UmsMember ums = new() 
            { 
                Username = umsMember.Username,
                Password = umsMember.Password,
                Nickname= umsMember.Nickname,
                Phone= umsMember.Phone,
                MemberLevelId=4,
            };
            int i = await _umsMemberRepository.AddAsync(ums);
            if (i >0)
            {
                return new MessageModel<UmsMember>()
                {
                    Msg = "注册成功",
                    Success = true,
                    Response = ums
                };
            }
            return  new MessageModel<UmsMember>(){ Msg = "注册失败",Success = false,}; ;
        }



        /// <summary>
        /// 获取用户个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserInfo")]
        [Authorize]
        public async Task<MessageModel<UmsMember>> Get()
        {
            //if(id<=0)
            //    return new MessageModel<UmsMember>() { Msg = "信息有误,请稍后再试!" };
            var loginId = await _redis.GetValue("LoginId");
            var user =await _umsMemberRepository.GetAsync(u => u.Id.ToString() == loginId);
            if(user==null)
                return new MessageModel<UmsMember>() { Msg = "用户信息获取失败!", Success = false };
            await _redis.Set("Users", user, TimeSpan.FromMinutes(30));
            //user = await _redis.Get<UmsMember>("Users");
            return new MessageModel<UmsMember>() { Msg = "获取成功!", Success = true, Response = user };
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        [Authorize]
        public async Task<MessageModel<UmsMember>> Edit([FromForm] UmsMember users)
        {

            return null;
        }



        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Phone"></param>
        /// <param name="checkNum"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("UpdatePassword")]
        public async Task<MessageModel<UmsMember>> UpdatePassword(string username, string password, string Phone, string checkNum)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(checkNum))
                return new MessageModel<UmsMember>() { Msg = "账号和密码不能为空" };
            if (string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(checkNum))
                return new MessageModel<UmsMember>() { Msg = "手机和验证码不能为空" };
            //验证验证码 暂时定死
            if (checkNum != "1234")
                return new MessageModel<UmsMember>() { Msg = "验证码不正确" };
            var user = await _umsMemberRepository.GetAsync(u => u.Phone == Phone && u.Username == username);
            if (user == null)
                return new MessageModel<UmsMember>() { Msg = "账号和手机号不匹配!" };

            user.Password = password;
            int i =await _umsMemberRepository.UpdateAsync(user);
            if (i == 1)
            {
                return new MessageModel<UmsMember>() { Msg = "密码修改成功" };
            }
            return new MessageModel<UmsMember>() { Msg = "密码修改失败" };
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUms")]
        [Authorize]
        public async Task<MessageModel<bool>> DeleteUms(long id)
        {
            if (id<=0)
                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!" };
            var i = await _umsMemberRepository.DeleteIdAsync(id);
            return new MessageModel<bool>() { Msg =i>0?"删除成功!": "删除失败!", Success = i>0 };
        }
    }
}
