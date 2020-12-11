using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台角色资源关系表
    /// </summary>
    public partial class UmsRoleResourceRelation
    {
        public long Id { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public long? RoleId { get; set; }

        /// <summary>
        /// 资源id
        /// </summary>
        public long? ResourceId { get; set; }
    }
}
