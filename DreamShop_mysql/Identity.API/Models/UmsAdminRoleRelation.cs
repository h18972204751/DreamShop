using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台用户和角色关系表
    /// </summary>
    public partial class UmsAdminRoleRelation
    {
        public long Id { get; set; }
        public long? AdminId { get; set; }
        public long? RoleId { get; set; }
    }
}
