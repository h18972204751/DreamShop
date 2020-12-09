using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class Users : BaseModel
    {

        public int LoginsId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 身份姓名
        /// </summary>
        public string CardName { get; set; }
        /// <summary>
        /// 身份证id
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 会员级别
        /// </summary>
        public int UserLevel{ get; set; }

        /// <summary>
        /// 用户余额
        /// </summary>
        public decimal UserMoney { get; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public string UpdateUserId { get; set; }

        public Logins Logins { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
