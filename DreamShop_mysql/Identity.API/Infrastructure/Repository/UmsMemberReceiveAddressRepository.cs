using Identity.API.Infrastructure.IRepository;
using Identity.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Infrastructure.Repository
{
    public class UmsMemberReceiveAddressRepository : BaseRepository<UmsMemberReceiveAddress>, IUmsMemberReceiveAddressRepository
    {
        public UmsMemberReceiveAddressRepository(DbContextOptions<DreamShopUserAdminContext> options) : base(options)
        {
        }

    }
}
