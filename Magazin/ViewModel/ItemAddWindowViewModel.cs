using Magazin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    internal class ItemAddWindowViewModel
    {
        public void GetItemInfo(System.Windows.Controls.Label name, System.Windows.Controls.Label acc, TextBox count, ComboBox cb)
        {
            string nameitem = SelectedItemSingleton.selitem.ToString();
            string namei = nameitem.Substring(11, nameitem.IndexOf("Доступно") - 12).Trim();
            name.Content = namei;

            using (StreamReader sr = new StreamReader("Products.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    if (strings[0] == namei)
                    {
                        acc.Content = $"Доступно: {strings[1]} Из: {strings[1]}";
                        break;
                    }

                }
            }

            AddUsers(cb);
        }
        public void AddUsers(ComboBox cb)
        {
            using (StreamReader sr = new StreamReader("Users.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    cb.Items.Add(strings[0]);
                }
            }
        }

        public void GiveItem(TextBox count, string nameitem, ComboBox client)
        {
            string[] seller = UserSingleton.user.Split(' ');
            List<string> items = new List<string>();
            int onclient = Convert.ToInt32(count.Text);

            try
            {
                if (client.SelectedIndex != -1 && count.Text.Length > 0 && !count.Text.Contains(" ") && Convert.ToInt32(count.Text) != 0)
                {
                    bool itemFound = false;

                    using (StreamReader sr = new StreamReader("Products.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] strings = sr.ReadLine().Split(';');
                            int qursuma = Convert.ToInt32(strings[1]);
                            if (onclient <= qursuma && nameitem == strings[0])
                            {
                                qursuma -= onclient;
                                items.Add(strings[0] + ";" + qursuma + ";" + strings[2]);
                                itemFound = true;
                            }
                            else
                            {
                                items.Add(strings[0] + ";" + qursuma + ";" + strings[2]);
                            }
                        }

                        if (!itemFound)
                        {
                            MessageBox.Show("Недостаточно товара!");
                            return; 
                        }
                    }

                    using (StreamWriter sw = new StreamWriter("UsersBying.txt", true))
                    {
                        sw.WriteLine(client.SelectedItem + ";" + count.Text + ";" + nameitem + ";" + seller[0]);
                        MessageBox.Show($"Успешно выдан {client.SelectedItem}!");
                    }

                    using (StreamWriter sr = new StreamWriter("Products.txt"))
                    {
                        foreach (string item in items)
                        {
                            sr.WriteLine(item);
                        }
                    }

                }
                else { MessageBox.Show("Получатель не выбран или введено некорректное количество товара!"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
