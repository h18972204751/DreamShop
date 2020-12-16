using Identity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.IRepository
{
    public interface IUmsMemberRepository:IBaseRepository<UmsMember>
    {
        Task<UmsMember> Login(string username, string password);
    }
}
