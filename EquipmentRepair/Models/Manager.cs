using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class Manager
    {
        public int SalePointId { get; set; }
        public int ManagerId { get; set; }
        public string FullName { get; set; } = null!;
        public int DataForLoginId { get; set; }

        public virtual DataForLogin DataForLogin { get; set; } = null!;
        public virtual SalePoint SalePoint { get; set; } = null!;
    }
}
