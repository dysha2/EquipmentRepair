using EquipmentRepair.Models;
using EquipmentRepair.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipmentRepair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //LoginBox.Focus();
        }

        private void LoginSystem(object sender, RoutedEventArgs e)
        {
            DataForLogin user = Session.context.DataForLogins.FirstOrDefault(us => us.Login == LoginBox.Text);
            if (user != null)
            {
                if (user.Password == PassBox.Password)
                {
                    Session.context.Entry(user).Reference(u => u.Manager).Load();
                    Session.context.Entry(user).Reference(u => u.Specialist).Load();
                    if (user.Manager == null)
                    {
                        SpecialistWindow specialistWindow = new SpecialistWindow(user.Specialist);
                        specialistWindow.Show();
                        this.Close();
                    } else
                    {
                        Session.context.Entry(user.Manager).Reference(u => u.SalePoint).Load();
                        ManagerWindow managerWindow = new ManagerWindow(user.Manager);
                        managerWindow.Show();
                        this.Close();
                    }
                } else
                {
                    LabelError.Content = "Пароль неверен";
                }
            } else
            {
                LabelError.Content = "Пользователь не найден";
            }
        }

        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == true)
            {
                PassBox.Visibility = Visibility.Collapsed;
                PassBoxShowed.Visibility = Visibility.Visible;
                PassBoxShowed.Text = PassBox.Password;
            }
            else
            {
                PassBox.Visibility = Visibility.Visible;
                PassBoxShowed.Visibility = Visibility.Collapsed;
                PassBox.Password = PassBoxShowed.Text;
            }
        }

        private void PassBoxShowed_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassBox.Password=PassBoxShowed.Text;
        }
    }
}
