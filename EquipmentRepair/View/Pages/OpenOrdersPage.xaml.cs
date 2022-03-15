using EquipmentRepair.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipmentRepair.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OpenOrdersPage.xaml
    /// </summary>
    public partial class OpenOrdersPage : Page
    {
        public ListCollectionView Orders { get; set; }
        private Specialist specInSystem;
        public OpenOrdersPage(ListCollectionView orders, Specialist spec)
        {
            Orders = orders;
            
            specInSystem = spec;
            this.Loaded += OpenOrdersPage_Loaded;
            InitializeComponent();
        }

        private void OpenOrdersPage_Loaded(object sender, RoutedEventArgs e)
        {
            Orders.Filter = obj => ((Order)obj).OrderStatusId == 1;
        }

        private void GetOrder(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Order order = but.DataContext as Order;
            order.OrderStatusId = 2;
            Orders.Refresh();
            OrderInWork orderInWork = new OrderInWork()
            {
                DateStart = DateTime.Now,
                Specialist = specInSystem,
                SpecialistId = specInSystem.SpecialistId,
                Order = order,
                OrderId = order.OrderId
            };
            order.OrderInWork = orderInWork;
            Session.context.OrderInWorks.Add(orderInWork);
            Session.context.SaveChanges();
        }
    }
}
