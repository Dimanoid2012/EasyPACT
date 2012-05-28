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
        public int but_left;
        public int but_top;
        public int but_right;
        public int but_bottom;

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", but_left, but_top, but_right, but_bottom);
        }

        public MyButton(string name, int width, int a, int b, int c, int d, string cont)
        {
            Name = name;
            Width = width;
            Height = 28;
            Margin = new Thickness(a, b, c, d);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Content = cont;
            but_left = a;
            but_top = b;
            but_right = c;
            but_bottom = d;
        }
    }
}