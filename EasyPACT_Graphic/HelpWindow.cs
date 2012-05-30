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
    public class HelpWindow : Window
    {
        public HelpWindow()
        {
            Image Help_Img = new Image()
            {
                Width = 900,
                Height = 416,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Help_Img",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Help_Img_bi = new BitmapImage();
            Help_Img_bi.BeginInit();
            Help_Img_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Help.jpg");
            Help_Img_bi.EndInit();
            Help_Img.Source = Help_Img_bi;





            Grid container_Help = new Grid();
            container_Help.Name = "container_Help";

            container_Help.Children.Add(Help_Img);

            this.Content = container_Help;
            this.MinHeight = 450;
            this.MinWidth = 900;
            this.MaxHeight = 450;
            this.MaxWidth = 900;
            this.Title = "Справка - EasyPACT";
            Uri iconUri = new Uri("C://EasyPACT/EasyPACT_Graphic/EasyPACT_Icon.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }
    }
}