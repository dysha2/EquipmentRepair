using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class SalePoint
    {
        public SalePoint()
        {
            Managers = new HashSet<Manager>();
            Orders = new HashSet<Order>();
        }

        public int SalePointId { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
