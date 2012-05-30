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
    public class Begin_Parameters : Window
    {
        public Begin_Parameters()
        {
            //InitializeComponent();
            /*
            var inf = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            System.Threading.Thread.CurrentThread.CurrentCulture = inf;
            inf.NumberFormat.NumberDecimalSeparator = ".";
            */
            MyLabel Liquid_type_lbl = new MyLabel("Liquid_type_lbl", 180, 211, 115, 0, 0, "Выберите тип жидкости:");

            MyComboBox Liquid_type = new MyComboBox("Liquid_type", 140, 380, 116, 12, 0);
            Liquid_type.Items.Add("Чистая жидкость");
            Liquid_type.Items.Add("Бинарная смесь");
            Liquid_type.SelectedIndex = 0;
            Liquid_type.SelectionChanged += Liquid_type_SelectionChanged;

            MyLabel Liquid_lbl = new MyLabel("Liquid_lbl", 527, 115, 0, 0, "Выберите жидкость:");

            MyComboBox Liquid = new MyComboBox("Liquid", 180, 670, 116, 0, 0);

            var a = Database.Query("select name,id from liquid_list");
            for (int i = 0; i < a[0].Count; i++)
            {
                Liquid.Items.Add(a[0][i]);
                id_str.Add(a[1][i]);
            }

            Liquid.Items.Add("Добавить жидкость...");
            Liquid.SelectedIndex = 0;

            Liquid.SelectionChanged += Liquid_SelectionChanged;

            MyLabel Liquid_parameters_lbl = new MyLabel("Liquid_parameters_lbl", 291, 157, 0, 0, "Параметры жидкости на входе", 14);

            MyLabel Pressure_lbl = new MyLabel("Pressure_lbl", 144, 590, 160, 0, 0, "Давление:");

            MyTextBox Pressure_Input = new MyTextBox("Pressure_Input", 88, 670, 160, 0, 0);

            MyComboBox Pressure_Measure_Choose = new MyComboBox("Pressure_Measure_Choose", 90, 760, 160, 0, 0);
            Pressure_Measure_Choose.SelectedIndex = 0;
            Pressure_Measure_Choose.Items.Add("мм рт.ст.");
            Pressure_Measure_Choose.Items.Add("МПа");
            Pressure_Measure_Choose.Items.Add("бар");
            //Pressure_Measure_Choose.SelectionChanged += Pressure_Measure_Choose_SelectionChanged;

            MyLabel Pressure_Input_Help = new MyLabel("Pressure_Input_Help", 665, 181, 0, 0, "Пример: '20'; '12.7'", 10);

            MyLabel Temperature_lbl = new MyLabel("Temperature_lbl", 574, 207, 0, 0, "Температура:");

            MyTextBox Temperature_Input = new MyTextBox("Temperature_Input", 88, 670, 207, 0, 0);

            MyComboBox Temperature_Measure_Choose = new MyComboBox("Temperature_Measure_Choose", 90, 760, 207, 0, 0);
            Temperature_Measure_Choose.SelectedIndex = 0;
            Temperature_Measure_Choose.Items.Add("Цельсий");
            Temperature_Measure_Choose.Items.Add("Кельвин"); ;
            //Temperature_Measure_Choose.SelectionChanged += Temperature_Measure_Choose_SelectionChanged;

            MyLabel Temperature_Input_Help = new MyLabel("Temperature_Input_Help", 665, 227, 0, 0, "Пример: '25'; '293.15'", 10);





            MyLabel Liquid_parameters_Out_lbl = new MyLabel("Liquid_parameters_Out_lbl", 281, 257, 0, 0, "Параметры жидкости на выходе", 14);
            /*
            MyLabel Pressure_Out_lbl = new MyLabel("Pressure_Out_lbl", 144, 590, 260, 0, 0, "Давление:");

            MyTextBox Pressure_Out_Input = new MyTextBox("Pressure_Out_Input", 88, 670, 260, 0, 0);

            MyComboBox Pressure_Out_Measure_Choose = new MyComboBox("Pressure_Out_Measure_Choose", 90, 760, 260, 0, 0);
            Pressure_Out_Measure_Choose.SelectedIndex = 0;
            Pressure_Out_Measure_Choose.Items.Add("МПа");
            Pressure_Out_Measure_Choose.Items.Add("мм.рт.ст.");
            Pressure_Out_Measure_Choose.Items.Add("бар");
            //Pressure_Out_Measure_Choose.SelectionChanged += Pressure_Out_Measure_Choose_SelectionChanged;
            */
            //MyLabel Pressure_Out_Input_Help = new MyLabel("Pressure_Out_Input_Help", 665, 281, 0, 0, "Пример: '20'; '12.7'", 10);

            MyLabel Temperature_Out_lbl = new MyLabel("Temperature_Out_lbl", 574, 260, 0, 0, "Температура:");

            MyTextBox Temperature_Out_Input = new MyTextBox("Temperature_Out_Input", 88, 670, 261, 0, 0);

            MyComboBox Temperature_Out_Measure_Choose = new MyComboBox("Temperature_Out_Measure_Choose", 90, 760, 261, 0, 0);
            Temperature_Out_Measure_Choose.SelectedIndex = 0;
            Temperature_Out_Measure_Choose.Items.Add("Цельсий");
            Temperature_Out_Measure_Choose.Items.Add("Кельвин"); ;
            //Temperature_Out_Measure_Choose.SelectionChanged += Temperature_Out_Measure_Choose_SelectionChanged;

            MyLabel NK_lbl = new MyLabel("NK_lbl", 601, 320, 0, 0, "Доля НК:");
            NK_lbl.Visibility = Visibility.Hidden;

            MyTextBox NK = new MyTextBox("NK", 88, 670, 321, 0, 0);
            NK.Visibility = Visibility.Hidden;

            MyLabel VysPod_lbl = new MyLabel("VysPod_lbl", 561, 290, 0, 0, "Высота подачи:");

            MyTextBox VysPod = new MyTextBox("VysPod", 88, 670, 291, 0, 0);

            MyLabel VysPod_Measure_lbl = new MyLabel("VysPod_Measure_lbl", 755, 290, 0, 0, "метров");

            //MyLabel Temperature_Out_Input_Help = new MyLabel("Temperature_Out_Input_Help", 665, 327, 0, 0, "Пример: '25'; '293.15'", 10);





            MyButton Next_1 = new MyButton("Next_1", 150, 0, 0, 20, 7, "Продолжить");
            Next_1.Height = 30;
            Next_1.Background = Brushes.DarkGreen;
            Next_1.Foreground = Brushes.LightGray;
            Next_1.FontSize = 12;
            Next_1.HorizontalAlignment = HorizontalAlignment.Right;
            Next_1.VerticalAlignment = VerticalAlignment.Bottom;
            Next_1.Click += Next_1_Click;

            MyButton Help = new MyButton("Help", 70, 18, 0, 0, 7, "Справка");
            Help.Height = 30;
            Help.Background = Brushes.DarkGreen;
            Help.HorizontalAlignment = HorizontalAlignment.Left;
            Help.VerticalAlignment = VerticalAlignment.Bottom;
            Help.Foreground = Brushes.LightGray;

            Help.Click += Help_Click;

            MyButton Liquid_Add = new MyButton("Liquid_Add", 180, 340, 0, 0, 60, "Добавление новой жидкости");
            Liquid_Add.Height = 30;
            Liquid_Add.Background = Brushes.DarkGreen;
            Liquid_Add.Foreground = Brushes.LightGray;
            Liquid_Add.VerticalAlignment = VerticalAlignment.Bottom;
            Liquid_Add.Visibility = Visibility.Hidden;
            Liquid_Add.Click += Liquid_Add_Click;

            MyButton Liquid_Solution_Add = new MyButton("Liquid_Add", 180, 340, 0, 0, 74, "Добавление новой смеси");
            Liquid_Solution_Add.Height = 30;
            Liquid_Solution_Add.Background = Brushes.DarkGreen;
            Liquid_Solution_Add.Foreground = Brushes.LightGray;
            Liquid_Solution_Add.VerticalAlignment = VerticalAlignment.Bottom;
            Liquid_Solution_Add.Visibility = Visibility.Hidden;
            Liquid_Solution_Add.Click += Liquid_Solution_Add_Click;

            Image Begin_Parameters_Img_Top = new Image()
            {
                Width = 900,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "First_Img_Top",
                Margin = new Thickness(0, 0, 0, 0),
                //Source = new BitmapSource(C:\EasyPACT\EasyPACT_Graphic\Images\favicon.gif)
            };

            BitmapImage Begin_Parameters_Img_Top_bi = new BitmapImage();
            Begin_Parameters_Img_Top_bi.BeginInit();
            Begin_Parameters_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Begin_Parameters_Top.jpg");
            Begin_Parameters_Img_Top_bi.EndInit();
            Begin_Parameters_Img_Top.Source = Begin_Parameters_Img_Top_bi;

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

            Image Animation = new Image()
            {
                Width = 200,
                Height = 270,
                HorizontalAlignment = HorizontalAlignment.Left,
                Name = "Animation",
                Margin = new Thickness(10, 40, 0, 0)
            };

            BitmapImage Animation_bi = new BitmapImage();
            Animation_bi.BeginInit();
            Animation_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\Animation.png");
            Animation_bi.EndInit();
            Animation.Source = Animation_bi;

            Grid container_1 = new Grid();
            container_1.Name = "container_1";
            container_1.Children.Add(First_Img_Bottom);//0
            container_1.Children.Add(Liquid_type);//1
            container_1.Children.Add(Liquid_lbl);//2
            container_1.Children.Add(Liquid);//3
            container_1.Children.Add(Liquid_parameters_lbl);//4
            container_1.Children.Add(Pressure_lbl);//5
            container_1.Children.Add(Pressure_Input);//6
            container_1.Children.Add(Pressure_Measure_Choose);//7
            container_1.Children.Add(Temperature_lbl);//8
            container_1.Children.Add(Temperature_Input);//9
            container_1.Children.Add(Temperature_Measure_Choose);//10
            container_1.Children.Add(Next_1);//11
            container_1.Children.Add(Liquid_type_lbl);//12
            //container_1.Children.Add(Help);//12!!!!!
            container_1.Children.Add(Liquid_Add);//13
            container_1.Children.Add(Liquid_Solution_Add);//14
            container_1.Children.Add(Pressure_Input_Help);//15
            container_1.Children.Add(Temperature_Input_Help);//16
            container_1.Children.Add(Begin_Parameters_Img_Top);//17
            container_1.Children.Add(Help);//18
            container_1.Children.Add(Liquid_parameters_Out_lbl);//19
            container_1.Children.Add(Temperature_Out_lbl);//20
            container_1.Children.Add(Temperature_Out_Input);//21
            container_1.Children.Add(Temperature_Out_Measure_Choose);//22
            container_1.Children.Add(Animation);//23
            container_1.Children.Add(NK_lbl);//24
            container_1.Children.Add(NK);//25
            container_1.Children.Add(VysPod_lbl);//26
            container_1.Children.Add(VysPod);//27
            container_1.Children.Add(VysPod_Measure_lbl);//28

            this.Content = container_1;
            
            this.Title = "Параметры жидкости - EasyPACT";
            Uri iconUri = new Uri("C://EasyPACT/EasyPACT_Graphic/EasyPACT_Icon.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            this.Width = 908;
            this.Height = 450;
            this.MinWidth = 908;
            this.MaxWidth = 908;
            this.MinHeight = 450;
            this.MaxHeight = 450;

        }

        private void Liquid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Liquid_type = grid.Children[1] as MyComboBox;
            var Liquid = grid.Children[3] as MyComboBox;
            var Liquid_Add = grid.Children[13] as MyButton;
            var Liquid_Solution_Add = grid.Children[14] as MyButton;

            if ((Liquid_type.SelectedIndex == 0) && (Liquid.SelectedIndex == Liquid.Items.Count - 1))
                Liquid_Add.Visibility = Visibility.Visible;
            else
                Liquid_Add.Visibility = Visibility.Hidden;

            if ((Liquid_type.SelectedIndex == 1) && (Liquid.SelectedIndex == Liquid.Items.Count - 1))
                Liquid_Solution_Add.Visibility = Visibility.Visible;
            else
                Liquid_Solution_Add.Visibility = Visibility.Hidden;
        }

        List<string> id_str = new List<string>();

        private void Liquid_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Liquid_type = grid.Children[1] as MyComboBox;
            var Liquid = grid.Children[3] as MyComboBox;
            var NK_lbl = grid.Children[24] as MyLabel;
            var NK = grid.Children[25] as MyTextBox;

            if (Liquid == null)
                return;
            if (Liquid.Items.Count != 0)
            {
                Liquid.Items.Clear();
                id_str.Clear();
            }
            if (Liquid_type.SelectedIndex == 0)
            {
                NK.Visibility = Visibility.Hidden;
                NK_lbl.Visibility = Visibility.Hidden;
                var a = Database.Query("select name,id from liquid_list");
                for (int i = 0; i < a[0].Count; i++)
                {
                    Liquid.Items.Add(a[0][i]);
                    id_str.Add(a[1][i]);
                }
                Liquid.Items.Add("Добавить жидкость...");
                Liquid.SelectedIndex = 0;
            }

            if (Liquid_type.SelectedIndex == 1)
            {
                NK.Visibility = Visibility.Visible;
                NK_lbl.Visibility = Visibility.Visible;
                if (Liquid.Items.Count != 0)
                    Liquid.Items.Clear();
                var id1 = Database.Query("select id1 from boiling_points_from_composition")[0];
                var id2 = Database.Query("select id2 from boiling_points_from_composition")[0];
                for (int i = 1; i < id1.Count; i++)
                {
                    if ((id1[i - 1] == id1[i]) && (id2[i - 1] == id2[i]))
                    {
                        id_str.Add(id1[i] + "," + id2[i]);
                        id1.RemoveAt(i);
                        id2.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < id1.Count; i++)
                {
                    var id1_name = Database.Query(String.Format("select name from liquid_list where id={0}", id1[i]))[0][0];
                    var id2_name = Database.Query(String.Format("select name from liquid_list where id={0}", id2[i]))[0][0];
                    Liquid.Items.Add(String.Format("{0} - {1}", id1_name, id2_name));
                }
                Liquid.Items.Add("Добавить смесь...");
                Liquid.SelectedIndex = 0;
            }

        }


        double Pressure_In = 0;
        double Temperature_In = 0;
        /*
        private void Pressure_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Pressure_Measure_Choose = grid.Children[7] as MyComboBox;

            if (Pressure_Measure_Choose.SelectedIndex == 0)
            {
                Pressure_In *= 760;
            }

            if (Pressure_Measure_Choose.SelectedIndex == 2)
            {
                Pressure_In = 100000 * Pressure_In / 101325 * 760;
            }
        }

        private void Temperature_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Temperature_Measure_Choose = grid.Children[10] as MyComboBox;

            if (Temperature_Measure_Choose.SelectedIndex == 1)
            {
                Temperature_In += 273;
            }
        }
        */
        //double Pressure_Out = 0;
        double Temperature_Out = 0;
        /*
        private void Pressure_Out_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Pressure_Out_Measure_Choose = grid.Children[22] as MyComboBox;

            if ((Pressure_Out_Measure_Choose.SelectedIndex == 0))
            {
                Pressure_In *= 760;
            }

            if (Pressure_Out_Measure_Choose.SelectedIndex == 2)
            {
                Pressure_Out = 100000 * Pressure_Out / 101325 * 760;
            }
        }

        private void Temperature_Out_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Temperature_Out_Measure_Choose = grid.Children[25] as MyComboBox;

            if (Temperature_Out_Measure_Choose.SelectedIndex == 1)
            {
                Temperature_Out += 273;
            }
        }
        */




        private void Next_1_Click(object sender, RoutedEventArgs e)
        {
            bool g = true;
            var grid = this.Content as Grid;
            var Liquid = grid.Children[3] as MyComboBox;
            var Pressure_Input = grid.Children[6] as TextBox;
            var Pressure_Measure_Choose = grid.Children[7] as MyComboBox;
            var Temperature_Input = grid.Children[9] as TextBox;
            var Temperature_Measure_Choose = grid.Children[10] as MyComboBox;

            //var Pressure_Out_Input = grid.Children[21] as MyTextBox;
            //var Pressure_Out_Measure_Choose = grid.Children[22] as MyComboBox;
            var Temperature_Out_Input = grid.Children[21] as MyTextBox;
            var Temperature_Out_Measure_Choose = grid.Children[22] as MyComboBox;

            var Liquid_Type = grid.Children[1] as MyComboBox;
            var NK = grid.Children[25] as MyTextBox;

            var VysPod = grid.Children[27] as MyTextBox;

            double result = 0;

            if ((double.TryParse(Pressure_Input.Text, out result) == false) ||
                (double.TryParse(Temperature_Input.Text, out result) == false) ||
                (double.TryParse(Temperature_Out_Input.Text, out result) == false) ||
                (Liquid.SelectedIndex == Liquid.Items.Count - 1))
                g = false;

            double NK_dou = 0;

            if (NK.Visibility == Visibility.Hidden)
            {
                NK_dou = 0;
            }

            if (NK.Visibility == Visibility.Visible)
            {
                if (double.TryParse(NK.Text, out result) == false)
                {
                    g = false;
                }
                else
                {
                    NK_dou = double.Parse(NK.Text);
                    if ((NK_dou == 0) || (NK_dou >= 1))
                    {
                        g = false;
                    }
                }
            }

            double VP = 0;

            if (double.TryParse(VysPod.Text, out result) == false)
            {
                g = false;
            }
            else
            {
                VP = double.Parse(VysPod.Text);
            }

            if (g == true)
            {
                Pressure_In = double.Parse(Pressure_Input.Text);
                Temperature_In = double.Parse(Temperature_Input.Text);
                Temperature_Out = double.Parse(Temperature_Out_Input.Text);

                if (Pressure_Measure_Choose.SelectedIndex == 1)
                {
                    Pressure_In = Pressure_In * 1000000 / (101325 / 760);
                }
                if (Pressure_Measure_Choose.SelectedIndex == 2)
                {
                    Pressure_In = 100000 * Pressure_In / 101325 * 760;
                }
                if (Temperature_Measure_Choose.SelectedIndex == 1)
                {
                    Temperature_In -= 273;
                }
                if (Temperature_Out_Measure_Choose.SelectedIndex == 1)
                {
                    Temperature_Out -= 273;
                }
                /*
                if (Pressure_Out_Measure_Choose.SelectedIndex == 0)
                {
                    Pressure_Out *= 760;
                }
                if (Pressure_Out_Measure_Choose.SelectedIndex == 2)
                {
                    Pressure_Out = 100000 * Pressure_In / 101325 * 760;
                }
                
                if (Temperature_Out_Measure_Choose.SelectedIndex == 1)
                {
                    Temperature_Out += 273;
                }
                */ 
                //MessageBox.Show("Все круто!");

                bool gg = true;

                if (Temperature_Out < Temperature_In)
                {
                    gg = false;
                }


                EasyPACT.Liquid liq;
                if (gg)
                {
                    try
                    {
                        if (Liquid_Type.SelectedIndex == 0)
                        {
                            liq = new EasyPACT.LiquidPure(id_str[Liquid.SelectedIndex], Temperature_In, Pressure_In);
                        }
                        else
                        {
                            liq = new EasyPACT.LiquidMix(id_str[Liquid.SelectedIndex], NK_dou, Temperature_In, Pressure_In);
                        }
                        Window_Add_Pipeline New_Pipeline = new Window_Add_Pipeline(liq, Temperature_Out, NK_dou, VP);
                        New_Pipeline.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Неправильно введены параметры");
                    }
                }
                else
                {
                    MessageBox.Show("Температура на выходе должна быть больше температуры на входе.");
                }


                

                
            }

            if (g == false)
            {
                MessageBox.Show("Некоторые поля не заполнены / введены неверно");
            }

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow hw1 = new HelpWindow();
            hw1.Show();
        }

        private void Liquid_Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Add_Liquid New_Liquid = new Window_Add_Liquid();
            New_Liquid.Show();
        }

        private void Liquid_Solution_Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Add_Solution New_Solution = new Window_Add_Solution();
            New_Solution.Show();
        }




    }
}
