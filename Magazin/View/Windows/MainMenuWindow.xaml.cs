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
            lv1.ItemsSource = null;
            (DataContext as MainMenuViewModel).FillFilter(cb);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lv.Visibility = Visibility.Hidden;
            lv1.Visibility = Visibility.Visible;
            (DataContext as MainMenuViewModel).GetInvent(lv1);
            butadd.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lv.Visibility = Visibility.Visible;
            lv1.Visibility = Visibility.Hidden;
            (DataContext as MainMenuViewModel).GetPerson(lv);
            lv.IsEnabled = true;
            butadd.Visibility = Visibility.Visible;
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv.SelectedItem != null)
            {
                SelectedUserSingleton.seluser = lv.SelectedItem.ToString();
                UserInfoWindow userInfoWindow = new UserInfoWindow();
                userInfoWindow.Show();
            }
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
            cb.SelectedIndex = -1;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as MainMenuViewModel).FilterList(lv1, cb);
        }

        private void lv1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv1.SelectedItem != null)
            {
                SelectedItemSingleton.selitem = lv1.SelectedItem.ToString();
                ItemAddWindow itemAddWindow = new ItemAddWindow();
                itemAddWindow.Show();
            }
        }
    }
}
