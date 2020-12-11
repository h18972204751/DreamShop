using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台用户和权限关系表(除角色中定义的权限以外的加减权限)
    /// </summary>
    public partial class UmsAdminPermissionRelation
    {
        public long Id { get; set; }
        /// <summary>
        /// 后台用户
        /// </summary>
        public long? AdminId { get; set; }
        /// <summary>
        /// 权限关系表
        /// </summary>
        public long? PermissionId { get; set; }
        public int? Type { get; set; }
    }
}
