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
    public class Credits : Window
    {
        public Credits()
        {
            Image Credits_Img_Top = new Image()
            {
                Width = 450,
                Height = 45,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Credits_Img_Top",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Credits_Img_Top_bi = new BitmapImage();
            Credits_Img_Top_bi.BeginInit();
            Credits_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Credits_Top.jpg");
            Credits_Img_Top_bi.EndInit();
            Credits_Img_Top.Source = Credits_Img_Top_bi;

            MyLabel University = new MyLabel("University", 20, 50, 0, 0, "Российский Химико-Технологический Университет", 15);

            MyLabel University_Name = new MyLabel("University_Name", 125, 70, 0, 0, "имени Д. И. Менделеева", 14);

            MyLabel Faculty = new MyLabel("Faculty", 30, 100, 0, 0, "Факультет Информационных Технологий и Управления", 13);

            MyLabel Work_Name = new MyLabel("Work_Name", 3, 137, 0, 0, "Курсовой проект по объектно-ориентированному программированию");

            MyLabel Students = new MyLabel("Students", 30, 170, 0, 0, "Выполнили студенты группы К-31");

            MyLabel Dima = new MyLabel("Dima", 95, 205, 0, 0, "Вильшанский Дмитрий Владимирович", 14);
            Dima.FontWeight = FontWeights.Bold;

            MyLabel Dima_Info = new MyLabel("Dima_Info", 95, 225, 0, 0, "Разработка расчетной части программы", 10);

            MyLabel Nikita = new MyLabel("Nikita", 95, 270, 0, 0, "Шорыгин Никита Валерьевич", 14);
            Nikita.FontWeight = FontWeights.Bold;

            MyLabel Nikita_Info = new MyLabel("Nikita_Info", 95, 290, 0, 0, "Разработка пользовательского интерфейса", 10);

            Image Dima_Photo = new Image()
            {
                Width = 60,
                Height = 60,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Dima_Photo",
                Margin = new Thickness(30, 198, 0, 0)
            };

            BitmapImage Dima_Photo_bi = new BitmapImage();
            Dima_Photo_bi.BeginInit();
            Dima_Photo_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Dima.png");
            Dima_Photo_bi.EndInit();
            Dima_Photo.Source = Dima_Photo_bi;

            Image Nikita_Photo = new Image()
            {
                Width = 60,
                Height = 60,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Nikita_Photo",
                Margin = new Thickness(30, 263, 0, 0)
            };

            BitmapImage Nikita_Photo_bi = new BitmapImage();
            Nikita_Photo_bi.BeginInit();
            Nikita_Photo_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Nikita.png");
            Nikita_Photo_bi.EndInit();
            Nikita_Photo.Source = Nikita_Photo_bi;

            MyLabel Supervisor = new MyLabel("Supervisor", 3, 335, 0, 0, "Руководитель проекта: Иванов Святослав Игоревич", 12);

            MyLabel Dean = new MyLabel("Dean", 3, 360, 0, 0, "Декан факультета: д.т.н., проф. Меньшутина Наталья Васильевна", 12);

            MyLabel Copyright = new MyLabel("Copyright", 3, 0, 0, -2, "Copyright 2012", 8);
            Copyright.VerticalAlignment = VerticalAlignment.Bottom;

            MyLabel AllRightsReserved = new MyLabel("", 3, 0, 0, -12, "Все права защищены", 8);
            AllRightsReserved.VerticalAlignment = VerticalAlignment.Bottom;

            MyButton Close_Credits = new MyButton("", 90, 0, 0, 5, 2, "З а к р ы т ь");
            Close_Credits.Height = 16;
            Close_Credits.FontSize = 7;
            Close_Credits.Background = Brushes.DarkGreen;
            Close_Credits.Foreground = Brushes.LightGray;
            Close_Credits.HorizontalAlignment = HorizontalAlignment.Right;
            Close_Credits.VerticalAlignment = VerticalAlignment.Bottom;
            Close_Credits.Click += Close_Credits_Click;

            Image Credits_Img_Bottom = new Image()
            {
                Width = 450,
                Height = 25,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Name = "Credits_Img_Bottom",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Credits_Img_Bottom_bi = new BitmapImage();
            Credits_Img_Bottom_bi.BeginInit();
            Credits_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Credits_Bottom.jpg");
            Credits_Img_Bottom_bi.EndInit();
            Credits_Img_Bottom.Source = Credits_Img_Bottom_bi;



            Grid container_Credits = new Grid();
            container_Credits.Name = "container_Credits";
            container_Credits.Children.Add(Credits_Img_Top);//0
            container_Credits.Children.Add(University);//1
            container_Credits.Children.Add(University_Name);//2
            container_Credits.Children.Add(Faculty);//3
            container_Credits.Children.Add(Work_Name);//4
            container_Credits.Children.Add(Students);//5
            container_Credits.Children.Add(Dima);//6
            container_Credits.Children.Add(Nikita);//7
            container_Credits.Children.Add(Dima_Photo);//8
            container_Credits.Children.Add(Dima_Info);//9
            container_Credits.Children.Add(Nikita_Photo);//10
            container_Credits.Children.Add(Nikita_Info);//11
            container_Credits.Children.Add(Supervisor);//12
            container_Credits.Children.Add(Credits_Img_Bottom);//13
            container_Credits.Children.Add(Dean);//14
            container_Credits.Children.Add(Copyright);//15
            container_Credits.Children.Add(AllRightsReserved);//16
            container_Credits.Children.Add(Close_Credits);//17

            this.MinWidth = 458;
            this.MinHeight = 460;
            this.MaxWidth = 458;
            this.MaxHeight = 460;
            Uri iconUri = new Uri("C://EasyPACT/EasyPACT_Graphic/EasyPACT_Icon.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            this.Content = container_Credits;
            this.Title = "Информация о разработчиках - EasyPACT";
        }

        private void Close_Credits_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}