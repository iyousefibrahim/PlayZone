﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayZone.DAL.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
