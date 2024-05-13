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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            DataContext = new AddClientWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddClientWindowViewModel).AddUser(tblog, tbpass, tbsur, tbname, tbotc);
        }
    }
}
