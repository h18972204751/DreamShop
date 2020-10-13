﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
