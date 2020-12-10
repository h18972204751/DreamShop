using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class Roles:BaseModel
    {

        public string RoleName { get; set; }

        public string Remark { get; set; }

        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int UpdateUserId { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
