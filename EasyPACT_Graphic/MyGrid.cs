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
    public class MyGrid : Grid
    {
        public FrameworkElement GetElementByName(string name)
        {
            return this.Children.OfType<FrameworkElement>().First(f => f.Name == name);
        }
    }
}