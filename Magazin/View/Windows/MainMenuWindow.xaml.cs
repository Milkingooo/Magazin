using Magazin.Model;
using Magazin.ViewModel;
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

namespace Magazin.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            DataContext = new MainMenuViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            curuser.Content = UserSingleton.user;
            lv.ItemsSource = null;
            (DataContext as MainMenuViewModel).FillFilter(cb);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (DataContext as MainMenuViewModel).GetInvent(lv);
            lv.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (DataContext as MainMenuViewModel).GetPerson(lv);
            lv.IsEnabled = true;
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUserSingleton.seluser = lv.SelectedItem.ToString();
            UserInfoWindow userInfoWindow = new UserInfoWindow();
            userInfoWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            cb.SelectedItem = null;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as MainMenuViewModel).FilterList(lv, cb);
        }
    }
}
