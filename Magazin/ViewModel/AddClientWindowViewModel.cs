using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    internal class AddClientWindowViewModel
    {
       public void AddUser(TextBox surn, TextBox name, TextBox otch)
        {
            if (name.Text != "" && surn.Text != "" && otch.Text != "")
            {
                using (StreamWriter stream = new StreamWriter("Users.txt", true))
                {
                    stream.WriteLine(surn.Text + ";" + name.Text + ";" + otch.Text);
                    MessageBox.Show("Пользователь успешно добавлен!");
                    name.Text = "";
                    surn.Text = "";
                    otch.Text = "";
                }
            }
            else MessageBox.Show("Некорректные данные!");
        }
    }
}
