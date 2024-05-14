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
    /// Логика взаимодействия для ItemAddWindow.xaml
    /// </summary>
    public partial class ItemAddWindow : Window
    {
        public ItemAddWindow()
        {
            InitializeComponent();
            DataContext = new ItemAddWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ItemAddWindowViewModel).GetItemInfo(nameitem, access, tb, cb);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ItemAddWindowViewModel).GiveItem(tb, nameitem.Content.ToString(), cb);
        }
    }
}
