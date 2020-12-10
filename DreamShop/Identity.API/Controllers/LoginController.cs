using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp;
using Identity.API.Data;
using Identity.API.Model;
using Identity.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Controller]
    public class LoginController : ControllerBase
    {
        readonly IdentityDbContext _context;


        public LoginController(IdentityDbContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<MessageModel<Logins>> Login([FromForm] string username, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new MessageModel<Logins>() { Msg = "账号和密码不能为空=" + username + '=' + password };
            var logins = await _context.Logins.FirstOrDefaultAsync(l => l.LoginName == username && l.LoginPassword == password);
            if (logins == null)
                return new MessageModel<Logins>() { Msg = "账户和密码错误" };
            if (logins.Status == Enums.UserStatus.Normal)
            {
                //获取token
                var token = await GetTokenResponse.GetTokenClient();
                return new MessageModel<Logins>()
                {
                    Msg = token,
                    Response = logins,
                    Success = true
                };
            }
            return new MessageModel<Logins>() { Msg = "账号和密码不能为空" };
        }
        //废弃的
        //[HttpPost]
        //public async Task<MessageModel<Logins>> Login1([FromBody] Logins logins)
        //{
        //    if (string.IsNullOrWhiteSpace(logins.LoginName) || string.IsNullOrWhiteSpace(logins.LoginPassword))
        //        return new MessageModel<Logins>() { Msg = "账号和密码不能为空=" + logins.LoginName + '=' + logins.LoginPassword };
        //    var loginss = await _context.Logins.FirstOrDefaultAsync(l => l.LoginName == logins.LoginName && l.LoginPassword == logins.LoginPassword);
        //    if (loginss == null)
        //        return new MessageModel<Logins>() { Msg = "账户和密码错误" };
        //    if (loginss.Status == Enums.UserStatus.Normal)
        //    {
        //        //获取token
        //        var token = await GetTokenResponse.GetTokenClient();
        //        return new MessageModel<Logins>()
        //        {
        //            Msg = token,
        //            Response = loginss,
        //            Success = true
        //        };
        //    }
        //    return new MessageModel<Logins>() { Msg = "账号和密码不能为空" };
        //}
        

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="loginsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUpUser")]
        public async Task<MessageModel<Users>> SignUpUser([FromBody] LoginsViewModel loginsViewModel) 
        {
            if(loginsViewModel==null)
                return new MessageModel<Users>() { Msg = "信息输入有误,请稍后再试!" };
            if (string.IsNullOrWhiteSpace(loginsViewModel.LoginName) || string.IsNullOrWhiteSpace(loginsViewModel.LoginPassword))
                return new MessageModel<Users>() { Msg = "账号和密码不能为空"};
            if (string.IsNullOrWhiteSpace(loginsViewModel.Phone) && string.IsNullOrWhiteSpace(loginsViewModel.Email))
                return new MessageModel<Users>() { Msg = "手机号或邮箱不能为空" };
            if (string.IsNullOrWhiteSpace(loginsViewModel.Account) )
                return new MessageModel<Users>() { Msg = "昵称不能为空" };

            var loginlist = _context.Logins.Where(l => l.LoginName == loginsViewModel.LoginName);
            if(loginlist.Count()>0)
                return new MessageModel<Users>() { Msg = "登录名已存在!请重新输入" };
            var login = await _context.Logins.AddAsync(loginsViewModel);
            Users user = new Users();
            if (login.IsKeySet)
            {
                 user = new Users()
                {
                    Account = loginsViewModel.Account,
                    LoginsId = login.Entity.Id,
                    Email = loginsViewModel.Email,
                    Phone = loginsViewModel.Phone
                };
                user = (await _context.Users.AddAsync(user)).Entity;
            }
            var i = await _context.SaveChangesAsync();
            if (i == 2)
            {
                return new MessageModel<Users>() 
                { 
                    Msg = "注册成功", 
                    Success = true, 
                    Response= user
                } ;
            }
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
        public async Task<MessageModel<Logins>> UpdatePassword(string username, string password,string Phone,string checkNum)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(checkNum))
                return new MessageModel<Logins>() { Msg = "账号和密码不能为空"};
            if ( string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(checkNum))
                return new MessageModel<Logins>() { Msg = "手机和验证码不能为空" };

            //验证验证码 暂时定死
            if(checkNum!="1234")
                return new MessageModel<Logins>() { Msg = "验证码不正确" };


            var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == Phone && u.Logins.LoginName == username);
            if (user == null)
                return new MessageModel<Logins>() { Msg = "账号和手机号不匹配!" };

            var login = user.Logins;
            login.LoginPassword = password;
            login = _context.Logins.Update(login).Entity;

            var i = await _context.SaveChangesAsync();
            if (i == 1)
            {
                return new MessageModel<Logins>() { Msg = "密码修改成功" };
            }
            return new MessageModel<Logins>() { Msg = "密码修改失败" };
        }

    }
}
