using Magazin.Model;
using Magazin.View.Windows;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    internal class LoginWindowViewModel
    {
        public bool GetClient(string path, TextBox log, TextBox pass, Label warn)
        {
            bool found = false;
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    if (log.Text == strings[0] && pass.Text == strings[1])
                    {
                        found = true;
                        UserSingleton.user = strings[2] + " " + strings[3] + " " + strings[4];
                        MainMenuWindow window = new MainMenuWindow();
                        window.Show();
                        return true;
                    }
                }
                if (!found)
                {
                    warn.Content = "Неверный логин или пароль!";
                    return false;
                }
            }
            return false;
        }
        public void CheckData(TextBox log, TextBox pass)
        {
            if (log.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Ничего не введено или строка имеет недопустимые символы!");
            }
        }
    }
}
