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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public Order AddedOrder { get; set; }=new Order();
        public List<OrderPriority> OrdersPriority { get; set; }=Session.context.OrderPriorities.ToList();
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddedOrder.Date=DateTime.Now;
            AddedOrder.OrderStatusId = 1;
            //AddedOrder.OrderStatus = Session.context.OrderStatuses.Find(1);
            this.Close();
        }
    }
}
