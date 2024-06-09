using Magazin.Model;
using Magazin.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Magazin.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow()
        {
            InitializeComponent();
            DataContext = new UserInfoWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            curuser.Content = SelectedUserSingleton.seluser.Remove(0, 5);
            (DataContext as UserInfoWindowViewModel).GetUserInfo(lv);

        }

        private void delbut_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as UserInfoWindowViewModel).DelUser(SelectedUserSingleton.seluser.Remove(0, 5));
            Close();
        }
    }
}
