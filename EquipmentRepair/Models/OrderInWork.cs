using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class OrderInWork
    {
        public int OrderId { get; set; }
        public int SpecialistId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Comment { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Specialist Specialist { get; set; } = null!;
    }
}
