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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginWindowViewModel).CheckData(log, pass);
            if((DataContext as LoginWindowViewModel).GetClient("AdminList.txt", log, pass, warnlb)) Close();
        }
    }
}
