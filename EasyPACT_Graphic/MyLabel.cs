using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using EasyPACT;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace EasyPACT_Graphic
{
    public class MyLabel : Label
    {
        public MyLabel(string name, int width, int a, int b, int c, int d, string cont)
        {
            Name = name;
            Width = width;
            Height = 28;
            Margin = new Thickness(a,b,c,d);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
            FontFamily = new FontFamily("Verdana");
            FontSize = 12;
        }

        public MyLabel(string name, int a, int b, int c, int d, string cont)
        {
            Name = name;
            Height = 28;
            Margin = new Thickness(a, b, c, d);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
            FontFamily = new FontFamily("Verdana");
            FontSize = 12;
        }

        public MyLabel(string name, int a, int b, int c, int d, string cont, int size)
        {
            Name = name;
            Height = 28;
            Margin = new Thickness(a, b, c, d);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
            FontFamily = new FontFamily("Verdana");
            FontSize = size;
        }

        public MyLabel(string name, string cont)
        {
            Name = name;
            Height = 28;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
            FontFamily = new FontFamily("Verdana");
            FontSize = 12;
        }
    }
}