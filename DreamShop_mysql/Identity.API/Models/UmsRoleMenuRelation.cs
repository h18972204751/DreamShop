using System;
using System.Collections.Generic;

namespace Identity.API.Models
{

    /// <summary>
    /// 后台角色菜单关系表
    /// </summary>
    public partial class UmsRoleMenuRelation
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long? RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long? MenuId { get; set; }
    }
}
