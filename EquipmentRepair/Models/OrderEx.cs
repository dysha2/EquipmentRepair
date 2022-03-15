using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EquipmentRepair.Models
{
    public partial class Order
    {
        public Brush ColorFromOrderStatus
        {
            get
            {
                switch (OrderStatusId)
                {
                        case 2: return Brushes.Orange;
                    case 3: return Brushes.Green;
                        default: return Brushes.Black;
                }
            }
        } 
    }
}
