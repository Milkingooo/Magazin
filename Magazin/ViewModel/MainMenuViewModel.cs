using Magazin.Model;
using Magazin.View.Windows;
using System.IO;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    public class MainMenuViewModel
    {
        public void GetInvent(ListView listView)
        {
            listView.ItemsSource = null;
            listView.Items.Clear();
            listView.ItemsSource = new Item[]
           {
                new Item {Name = "Гвоздь длинный", Count = 10, Type = "Гвоздь"},
                new Item {Name = "Грабли", Count = 1000, Type = "Грабли"}
           };
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
}