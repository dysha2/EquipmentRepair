using EquipmentRepair.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Shapes;

namespace EquipmentRepair.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window, INotifyPropertyChanged
    {
        private bool? _IsAll=false;

        public bool? IsAllOrders
        {
            get { return _IsAll; }
            set 
            { 
                _IsAll = value;
                if (_IsAll == true)
                {
                    Orders.Filter = null;
                }
                else
                {
                    Orders.Filter = obj => ((Order)obj).OrderStatusId==1;
                }
            }
        }

        public Manager UserInSystem { get; set; }
        private ObservableCollection<Order> _orders;
        public ManagerWindow(Manager dataForLogin)
        {
            UserInSystem = dataForLogin;
            _orders = new ObservableCollection<Order>(Session.context.Orders.Where(x => x.SalePointId == UserInSystem.SalePointId).Include(o => o.OrderPriority));
            Orders = new ListCollectionView(_orders);
            Orders.Filter = obj => ((Order)obj).OrderStatusId == 1;
            _orders.CollectionChanged += _orders_CollectionChanged;
            InitializeComponent();
        }

        private void _orders_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Session.context.Orders.Add(e.NewItems[0]as Order);
                    break;
                    case NotifyCollectionChangedAction.Remove:
                    Session.context.Orders.Remove(e.OldItems[0] as Order);
                    break;
            }
            Session.context.SaveChanges();
        }

        public ListCollectionView Orders { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Order a = button.DataContext as Order;
            var bRet = MessageBox.Show("Удалить элемент?", "привет", MessageBoxButton.YesNo);
            if (bRet == MessageBoxResult.Yes)
            {
                _orders.Remove(a);
            }
        }

        private void OrderInfo(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Order order = but.DataContext as Order;
            OrderInfoWindow orderInfoWindow = new OrderInfoWindow(order);
            orderInfoWindow.ShowDialog();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrder = new AddOrderWindow();
            addOrder.AddedOrder.SalePointId = UserInSystem.SalePointId;
            addOrder.AddedOrder.SalePoint = UserInSystem.SalePoint;
            addOrder.ShowDialog();
            _orders.Add(addOrder.AddedOrder);
        }
    }
}
