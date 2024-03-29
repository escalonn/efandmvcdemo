﻿using System;
using System.Collections.Generic;

namespace ContainerizedDataAccess.Entities
{
    public partial class Account
    {
        public Account()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
