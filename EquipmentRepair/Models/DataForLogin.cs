using System;
using System.Collections.Generic;

namespace EquipmentRepair.Models
{
    public partial class DataForLogin
    {
        public int DataForLoginId { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Manager Manager { get; set; } = null!;
        public virtual Specialist Specialist { get; set; } = null!;
    }
}
