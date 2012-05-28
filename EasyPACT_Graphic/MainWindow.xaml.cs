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

            MyLabel Choose_Task_lbl = new MyLabel("Choose_Task_lbl", 30, 175, 0, 0, "Выберите задачу, которую требуется решить:", 13);
            RadioButton Choose_Task_First = new RadioButton()
            {
                Content = " Расчет жидкости на выходе из системы по заданным арматуре и состоянии жидкости на входе в систему",
                //Height = 30,
                Name = "Choose_Task_First",
                Margin = new Thickness(50, 215, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontSize = 13,
                FontWeight = FontWeights.Bold,
                IsChecked = true
            };

            RadioButton Choose_Task_Second = new RadioButton()
            {
                Content = " Расчет теплообменного аппарата по заданным арматуре и состояниям жидкости на входе и на выходе из системы",
                //Height = 16,
                Name = "Choose_Task_Second",
                Margin = new Thickness(50, 245, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontSize = 13,
                FontWeight = FontWeights.Bold
            };

            MyButton Next_0 = new MyButton("Next_0", 150, 0, 0, 20, 7, "Далее");
            Next_0.HorizontalAlignment = HorizontalAlignment.Right;
            Next_0.VerticalAlignment = VerticalAlignment.Bottom;
            Next_0.Background = Brushes.DarkGreen;
            Next_0.FontSize = 12;
            Next_0.Foreground = Brushes.White;
            Next_0.Click += Next_0_Click;

            MyButton Help_Choose_Task = new MyButton("Help_Choose_Task", 70, 18, 0, 0, 7, "Справка");
            Help_Choose_Task.VerticalAlignment = VerticalAlignment.Bottom;
            Help_Choose_Task.Background = Brushes.DarkGreen;
            Help_Choose_Task.FontSize = 12;
            Help_Choose_Task.Click += Help_Choose_Task_Click;

            MyButton OpenCredits = new MyButton("OpenCredits", 100, 30, 300, 0, 0, "Разработчики");
            OpenCredits.Background = Brushes.DarkGreen;
            OpenCredits.Click += OpenCredits_Click;


            Image First_Img_Top = new Image()
            {
                Width = 900,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "First_Img_Top",
                Margin = new Thickness(0, 0, 0, 0),
                //Source = new BitmapSource(C:\EasyPACT\EasyPACT_Graphic\Images\favicon.gif)
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
                Margin = new Thickness(0, 366, 0, 0),
                //Source = new BitmapSource(C:\EasyPACT\EasyPACT_Graphic\Images\favicon.gif)
            };

            BitmapImage First_Img_Bottom_bi = new BitmapImage();
            First_Img_Bottom_bi.BeginInit();
            First_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Bottom_First.jpg");
            First_Img_Bottom_bi.EndInit();
            First_Img_Bottom.Source = First_Img_Bottom_bi;
            
            Rectangle exampleRectangle = new Rectangle();

            LinearGradientBrush grad = new LinearGradientBrush();
            grad.StartPoint = new Point(0.5, 0.0);
            grad.EndPoint = new Point(0.5, 1.0);
            grad.GradientStops.Add(new GradientStop(Colors.White, 0.4));
            //grad.GradientStops.Add(new GradientStop(Colors.DarkGreen, 1.0));
            //grad.Opacity = 10.0;*/
            /*
            grad.GradientStops.Add(new GradientStop(Colors.Yellow, 0.4));
            //grad.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
            grad.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            */

            exampleRectangle.Fill = grad;

            Grid Hello_Window = new Grid();
            Hello_Window.Name = "Hello_Window";
            Hello_Window.Children.Add(Welcome);
            Hello_Window.Children.Add(Choose_Task_lbl);
            Hello_Window.Children.Add(Choose_Task_First);
            Hello_Window.Children.Add(Choose_Task_Second);
            Hello_Window.Children.Add(First_Img_Top);
            Hello_Window.Children.Add(First_Img_Bottom);
            Hello_Window.Children.Add(Next_0);
            Hello_Window.Children.Add(Help_Choose_Task);
            Hello_Window.Children.Add(OpenCredits);


            this.Content = Hello_Window;
            this.Title = "Выбор решаемой задачи - EasyPACT";
            this.Background = grad;
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

        private void Help_Choose_Task_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выбран пункт Справка");
        }

        private void OpenCredits_Click(object sender, RoutedEventArgs e)
        {
            Credits crd = new Credits();
            crd.Show();
        }

    }
}
