using EquipmentRepair.Models;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для OrdersInWorkPage.xaml
    /// </summary>
    public partial class OrdersInWorkPage : Page, INotifyPropertyChanged
    {
        public bool? IsActiveOrders { get => _isActiveOrders; set { 
                _isActiveOrders = value;
                if (IsActiveOrders == true)
                {
                    Orders.Filter = obj => ((Order)obj).OrderStatusId == 2 && ((Order)obj).OrderInWork.SpecialistId == specInSystem.SpecialistId;
                } else
                {
                    Orders.Filter = obj => ((Order)obj).OrderStatusId == 3 && ((Order)obj).OrderInWork.SpecialistId == specInSystem.SpecialistId;
                }
                Orders.Refresh();
                OnPropertyChanged();
            } }
        public ListCollectionView Orders { get; set; }
        private Specialist specInSystem;
        private bool? _isActiveOrders=false;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public OrdersInWorkPage(ListCollectionView orders, Specialist spec)
        {
            Orders = orders;
            specInSystem = spec;
            this.Loaded += OrdersInWorkPage_Loaded;
            InitializeComponent();
        }

        private void OrdersInWorkPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsActiveOrders = true;
        }

        private void InfoWindow(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            OrderInfoWindow oiw = new OrderInfoWindow(but.DataContext as Order);
            oiw.ShowDialog();
        }

        private void FinishOrder(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            FinishOrderWindow fow = new FinishOrderWindow(but.DataContext as Order);
            fow.ShowDialog();
            Orders.Refresh();
        }
    }
}
