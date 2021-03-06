﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class UserRoles:BaseModel
    {

        public string UsersId { get; set; }

        public string RolesId { get; set; }

        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public string UpdateUserId { get; set; }

        public Users Users { get; set; }

        public Roles Roles { get; set; }


    }
}
