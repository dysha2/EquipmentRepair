using EquipmentRepair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepair
{
    public class Session
    {
        private static EquipmentRepairContext equipmentRepairContext;
        private Session() { }
        public static EquipmentRepairContext context
        {
            get { return equipmentRepairContext ?? (equipmentRepairContext = new EquipmentRepairContext()); }
        }

    }
}
