﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    public class MainMenuViewModel
    {
        public void GetInvent(ListView listView)
        {
            listView.ItemsSource = null;
            listView.Items.Clear();
            using (StreamReader sr = new StreamReader("Products.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    listView.Items.Add(new Item { Name = strings[0], Count = Convert.ToInt32(strings[1]), Type = strings[2] });
                }
            }

        }
        public void GetPerson(ListView listView)
        {
            listView.ItemsSource = null;
            listView.Items.Clear();
            using (StreamReader sr = new StreamReader("Users.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    listView.Items.Add(new Person { Name = strings[2], Surname = strings[3], Otch = strings[4] });
                }
            }
        }
        public void FillFilter(ComboBox cb)
        {
            using (StreamReader sr = new StreamReader("Products.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    cb.Items.Add(strings[2]);
                }
            }
        }
        public void FilterList(ListView lv, ComboBox cb)
        {
            lv.Items.Clear();
            //for (int i = 0; i < lv.Items.Count + 1; i++)
            //{
            //    if (lv.Items[i] != cb.SelectedItem)
            //    {
            //        lv.Items.Remove(lv.Items[i]);
            //    }
            //}
            using (StreamReader sr = new StreamReader("Products.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] strings = sr.ReadLine().Split(';');
                    if (strings[2] == cb.SelectedItem.ToString())
                    lv.Items.Add(new Item { Name = strings[0], Count = Convert.ToInt32(strings[1]), Type = strings[2] });

                }
            }
            lv.Items.Refresh();

        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public override string ToString() => $" Название : {Name} \n Доступно = {Count} \n Тип: {Type}";
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otch { get; set; }
        public override string ToString() => $"ФИО: {Name}  {Surname}  {Otch}";

    }
}
