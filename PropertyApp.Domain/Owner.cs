﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain
{
    public class Owner
    {
       public Guid IdOwner { get; set; }
       public string? Name { get; set; }
       public string? Address { get; set; }
        public string? Photo { get; set; }
        public string? Birthday { get; set; }
    }
}
