using EquipmentRepair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepair.View
{
    /// <summary>
    /// Логика взаимодействия для OrderInfoWindow.xaml
    /// </summary>
    public partial class OrderInfoWindow : Window
    {
        public OrderInfoWindow(Order order)
        {
            InitializeComponent();

            Session.context.Entry(order).Reference(u => u.OrderInWork).Load();
            Session.context.Entry(order.OrderInWork).Reference(u => u.Specialist).Load();
            DataContext = order;
        }
    }
}
