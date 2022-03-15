using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class Specialist
    {
        public Specialist()
        {
            OrderInWorks = new HashSet<OrderInWork>();
        }

        public string FullName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Phone { get; set; } = null!;
        public int SpecialistId { get; set; }
        public int DataForLoginId { get; set; }

        public virtual DataForLogin DataForLogin { get; set; } = null!;
        public virtual ICollection<OrderInWork> OrderInWorks { get; set; }
    }
}
