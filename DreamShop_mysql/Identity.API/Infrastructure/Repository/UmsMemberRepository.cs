using Identity.API.Infrastructure.IRepository;
using Identity.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.Repository
{
    public class UmsMemberRepository: BaseRepository<UmsMember>,IUmsMemberRepository
    {
        public UmsMemberRepository(DbContextOptions<DreamShopUserAdminContext> options) : base(options)
        {
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UmsMember> Login(string username, string password)
        {
            var umsMember = await base.GetAsync(o => o.Username == username && o.Password == password);
            return umsMember;
        }

    }
}
