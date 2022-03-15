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

namespace EquipmentRepair.View
{
    /// <summary>
    /// Логика взаимодействия для FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : Window
    {
        private Order Order { get; set; }
        public FinishOrderWindow(Order order)
        {
            InitializeComponent();
            Session.context.Entry(order).Reference(u => u.OrderInWork).Load();
            Session.context.Entry(order.OrderInWork).Reference(u => u.Specialist).Load();
            Order = order;
            DataContext = order;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FinishOrder(object sender, RoutedEventArgs e)
        {
            Order.OrderStatusId = 3;
            OrderInWork orderInWork = Order.OrderInWork;
            orderInWork.DateEnd = DateTime.Now;
            if (!String.IsNullOrEmpty(Comment.Text))
            {
                orderInWork.Comment = Comment.Text;
            }
            Session.context.SaveChanges();
            this.Close();
        }
    }
}
