using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台用户角色和权限关系表
    /// </summary>
    public partial class UmsRolePermissionRelation
    {
        public long Id { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public long? RoleId { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public long? PermissionId { get; set; }
    }
}
