using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int SalePointId { get; set; }
        public string? Description { get; set; }
        public int OrderPriorityId { get; set; }
        public int OrderStatusId { get; set; }

        public virtual OrderPriority OrderPriority { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual SalePoint SalePoint { get; set; } = null!;
        public virtual OrderInWork OrderInWork { get; set; } = null!;
    }
}
