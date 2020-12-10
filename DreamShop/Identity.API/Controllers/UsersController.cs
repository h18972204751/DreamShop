using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp;
using Identity.API.Data;
using Identity.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        readonly IdentityDbContext _context;

        public UsersController(IdentityDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 获取用户个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserInfo")]
        [Authorize]
        public async Task<MessageModel<Users>> Get() 
        {
            //if(id<=0)
            //    return new MessageModel<Users>() { Msg = "信息有误,请稍后再试!" };
            var user = await _context.Users.FindAsync(1);
            return new MessageModel<Users>() { Msg = "成功!",Success=true,Response= user };
            
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel<Users>> Put([FromForm] Users users)
        {


            return null;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<bool>> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!" };
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            return new MessageModel<bool>() { Msg = "删除成功!", Success = true };
        }

    }
}
