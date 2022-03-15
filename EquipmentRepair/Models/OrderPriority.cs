using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class OrderPriority
    {
        public OrderPriority()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderPriorityId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
