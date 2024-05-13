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
    /// Логика взаимодействия для HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
            DataContext = new HelpWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as HelpWindowViewModel).ViewList(lv);
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedHelpSingleton.helppart = lv.SelectedItem.ToString();
            (DataContext as HelpWindowViewModel).ViewHelp(lv, tb);
        }
    }
}
