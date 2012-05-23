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
    public class MyButton : Button
    {
        public MyButton(string name, int width, int a, int b, int c, int d, string cont)
        {
            Name = name;
            Width = width;
            Height = 28;
            Margin = new Thickness(a, b, c, d);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
        }
    }
}