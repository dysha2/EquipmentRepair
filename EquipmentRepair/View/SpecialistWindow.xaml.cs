using EquipmentRepair.Models;
using EquipmentRepair.View.Pages;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace EquipmentRepair.View
{
    /// <summary>
    /// Логика взаимодействия для SpecialistWindow.xaml
    /// </summary>
    public partial class SpecialistWindow : Window, INotifyPropertyChanged
    {
        public OpenOrdersPage OpenOrdersP { get; set; }
        public OrdersInWorkPage OrdersWorkP { get; set; }

        private ObservableCollection<Order> _orders;
        private string titleNow = "Активные заявки";
        public event PropertyChangedEventHandler? PropertyChanged;
        public Specialist SpecialistInSystem { get; set; }
        public string TitleNow { get => titleNow; set { titleNow = value; OnPropertyChanged(); }}
        public ListCollectionView Orders { get; set; }
        public SpecialistWindow(Specialist spec)
        {
            Session.context.OrderInWorks.Load();
            Session.context.SalePoints.Load();
            Session.context.OrderPriorities.Load();
            Session.context.Orders.Load();
            _orders = Session.context.Orders.Local.ToObservableCollection();
            Orders=new ListCollectionView(_orders);
            SpecialistInSystem = spec;
            OrdersWorkP = new OrdersInWorkPage(Orders, spec);
            OpenOrdersP=new OpenOrdersPage(Orders,spec);
            Orders.SortDescriptions.Add(new SortDescription("OrderPriorityId", ListSortDirection.Descending));
            InitializeComponent();
        }
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private void GoToPage(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            TitleNow = but.Content.ToString();
            Page page = but.DataContext as Page;
            MainFrame.Navigate(page);
        }
    }
}
