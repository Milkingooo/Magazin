using Magazin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Magazin.ViewModel
{
    internal class HelpWindowViewModel
    {
        public void ViewHelp(ListView lv, TextBox tb)
        {
            using (StreamReader sr = new StreamReader("Help.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "#" + SelectedHelpSingleton.helppart + "#")
                    {
                        while ((line = sr.ReadLine()) != "#####")
                        {
                            tb.Text += line + Environment.NewLine;
                        }
                        break;
                    }
                }
            }
        }
        public void ViewList(ListView lv)
        {
            lv.ItemsSource = new List<HelpItem>()
            {
                new HelpItem {Title = "Общее"},
                new HelpItem {Title = "Скоро..."}
            };
        }
    }
    public class HelpItem
    {
        public string Title { get; set; }
        public override string ToString() => $"{Title}";
    }
}
