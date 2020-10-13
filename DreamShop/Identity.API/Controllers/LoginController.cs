using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp;
using Identity.API.Data;
using Identity.API.Model;
using Identity.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IdentityDbContext _context;


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
        [Route("test"), Route("test1")]
        public async Task<MessageModel<Logins>> Login([FromForm] string loginName, [FromForm] string loginPassword)
        {
            if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(loginPassword))
                return new MessageModel<Logins>() {  Msg ="账号和密码不能为空="+ loginName +'='+ loginPassword };
            var logins = await _context.Logins.FirstOrDefaultAsync(l => l.LoginName == loginName && l.LoginPassword == loginPassword);
            if (logins == null)
                return new MessageModel<Logins>() { Msg = "账户和密码错误" };
            if (logins.Status == Enums.UserStatus.Normal)
            {
                //获取token
                
                return new MessageModel<Logins>() 
                {
                    Msg = "登录成功",
                    Response= logins,
                    Success=true
                    
                };
            }
            return new MessageModel<Logins>() { Msg = "账号和密码不能为空" };
        }

        [HttpPost]
        public async Task<MessageModel<Logins>> SignUpUser([FromBody] LoginsViewModel loginsViewModel)
        {
            var login = await _context.Logins.AddAsync(loginsViewModel);

            return null;
        }


    }
}
