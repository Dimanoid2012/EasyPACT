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
using System.Windows.Resources;
using System.IO;

namespace EasyPACT_Graphic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var inf = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            System.Threading.Thread.CurrentThread.CurrentCulture = inf;
            inf.NumberFormat.NumberDecimalSeparator = ".";

            MyLabel Welcome = new MyLabel("Welcome", 30, 130, 0, 0, "Добро пожаловать в EasyPACT!", 16);

            MyLabel Task_lbl = new MyLabel("Task_lbl", 30, 175, 0, 0, "Задача, которую решает программа:", 13);

            MyLabel Task1 = new MyLabel("Task1", 50, 205, 0, 0, "Расчет теплообменного аппарата и насоса", 14);
            Task1.FontWeight = FontWeights.Bold;

            MyLabel Task2 = new MyLabel("Task2", 50, 230, 0, 0, "по заданным арматуре и состояниям жидкости на входе и на выходе из системы", 14);
            Task2.FontWeight = FontWeights.Bold;

            MyButton Next_0 = new MyButton("Next_0", 150, 0, 0, 20, 7, "Продолжить");
            Next_0.HorizontalAlignment = HorizontalAlignment.Right;
            Next_0.VerticalAlignment = VerticalAlignment.Bottom;
            Next_0.Background = Brushes.DarkGreen;
            Next_0.FontSize = 12;
            Next_0.Foreground = Brushes.LightGray;
            Next_0.Click += Next_0_Click;

            MyButton Help_Choose_Task = new MyButton("Help_Choose_Task", 80, 18, 0, 0, 7, "Разработчики");
            Help_Choose_Task.Foreground = Brushes.LightGray;
            Help_Choose_Task.VerticalAlignment = VerticalAlignment.Bottom;
            Help_Choose_Task.Background = Brushes.DarkGreen;
            Help_Choose_Task.FontSize = 10;
            Help_Choose_Task.Click += OpenCredits_Click;

            Image First_Img_Top = new Image()
            {
                Width = 900,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "First_Img_Top",
                Margin = new Thickness(0, 0, 0, 0)
            };
            
            BitmapImage First_Img_Top_bi = new BitmapImage();
            First_Img_Top_bi.BeginInit();
            First_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_First.jpg");
            First_Img_Top_bi.EndInit();
            First_Img_Top.Source = First_Img_Top_bi;

            Image First_Img_Bottom = new Image()
            {
                Width = 900,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "First_Img_Bottom",
                Margin = new Thickness(0, 366, 0, 0)
            };

            BitmapImage First_Img_Bottom_bi = new BitmapImage();
            First_Img_Bottom_bi.BeginInit();
            First_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Bottom_First.jpg");
            First_Img_Bottom_bi.EndInit();
            First_Img_Bottom.Source = First_Img_Bottom_bi;
            
            Grid Hello_Window = new Grid();
            Hello_Window.Name = "Hello_Window";
            Hello_Window.Children.Add(Welcome);
            Hello_Window.Children.Add(Task_lbl);
            Hello_Window.Children.Add(Task1);
            Hello_Window.Children.Add(Task2);
            Hello_Window.Children.Add(First_Img_Top);
            Hello_Window.Children.Add(First_Img_Bottom);
            Hello_Window.Children.Add(Next_0);
            Hello_Window.Children.Add(Help_Choose_Task);
            this.Content = Hello_Window;
            this.Title = "Выбор решаемой задачи - EasyPACT";
            Uri iconUri = new Uri("C://EasyPACT/EasyPACT_Graphic/EasyPACT_Icon.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            this.Width = 908;
            this.Height = 450;
            this.MinWidth = 908;
            this.MaxWidth = 908;
            this.MinHeight = 450;
            this.MaxHeight = 450;
        }

        private void Next_0_Click(object sender, RoutedEventArgs e)
        {
            Begin_Parameters bpm = new Begin_Parameters();
            bpm.Show();
        }

        private void OpenCredits_Click(object sender, RoutedEventArgs e)
        {
            Credits crd = new Credits();
            crd.Show();
        }

    }
}
