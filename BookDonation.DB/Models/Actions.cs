﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB
{
    public class Actions
    {
        [Key]
        public virtual int ActionId { get; set; }
        public virtual string Name { get; set; }
    }
}
