using System;
using System.Collections.Generic;

namespace ContainerizedDataAccess.Entities
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
