using Magazin.Model;
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
    internal class UserInfoWindowViewModel
    {
        public void GetUserInfo(ListView lv)
        {
            try
            {
                MessageBox.Show(SelectedUserSingleton.seluser);
                lv.Items.Clear();
                List<PersonBuy> lists = new List<PersonBuy>();
                string[] buyer = SelectedUserSingleton.seluser.ToString().Split(' ');
                using (StreamReader stream = new StreamReader("UsersBying.txt"))
                {
                    while (!stream.EndOfStream)
                    {
                        string[] items = stream.ReadLine().Split(';');
                        if (items[0] == buyer[1])
                        {
                            lists.Add(new PersonBuy { Item = items[2], Count = Convert.ToInt32(items[1]), NameDiller = items[3]});
                        }
                    }
                }
                lv.ItemsSource = lists;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
    public class PersonBuy
    {
        public string Item { get; set; }
        public int Count { get; set; }

        public string NameDiller { get; set; }
        public override string ToString() => $" Название : {Item} \n Выдано: {Count} \n Кем выдан: {NameDiller}";
    }

}
