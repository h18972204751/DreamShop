using Identity.API.Infrastructure.IRepository;
using Identity.API.Infrastructure.IServices;
using Identity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.Services
{
    public class AuthServices: IAuthServices
    {

        //readonly IUmsMemberRepository _umsMemberRepository;
        //public AuthServices(IUmsMemberRepository umsMemberRepository)
        //{
        //    this._umsMemberRepository=umsMemberRepository;
        //}

        ///// <summary>
        ///// 登录
        ///// </summary>
        ///// <param name="username"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public async Task<UmsMember> Login(string username,string password)
        //{
        //    var umsMember = await _umsMemberRepository.GetAsync(o => o.Username == username && o.Password == password);
        //    return umsMember;
        //}



    }
}
