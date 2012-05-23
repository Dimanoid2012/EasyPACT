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

            MyLabel Liquid_type_lbl = new MyLabel("Liquid_type_lbl", 150, 280, 150, 0, 0, "Выберите тип жидкости:");

            MyComboBox Liquid_type = new MyComboBox("Liquid_type", 160, 446, 150, 12, 0);
            Liquid_type.Items.Add("Чистая жидкость");
            Liquid_type.Items.Add("Бинарная смесь");
            Liquid_type.SelectedIndex = 0;
            Liquid_type.SelectionChanged += Liquid_type_SelectionChanged;

            MyLabel Liquid_lbl = new MyLabel("Liquid_lbl", 302, 184, 0, 0,"Выберите жидкость:");

            MyComboBox Liquid = new MyComboBox("Liquid", 160, 446, 184, 0, 0);

            foreach (var a in Database.Query("select name from liquid_list")[0])
            {
                Liquid.Items.Add(a);
            }
            Liquid.Items.Add("Добавить жидкость...");
            Liquid.SelectedIndex = 0;

            Liquid.SelectionChanged += Liquid_SelectionChanged;

            MyLabel Liquid_parameters_lbl = new MyLabel("Liquid_parameters_lbl", 144, 295, 230, 0, 0,"Параметры жидкости:");

            MyLabel Pressure_lbl = new MyLabel("Pressure_lbl", 144, 355, 256, 0, 0, "Давление:");

            MyTextBox Pressure_Input = new MyTextBox("Pressure_Input", 78, 446, 256, 0, 0);
            Pressure_Input.TextChanged += Pressure_Input_TextChanged;

            MyComboBox Pressure_Measure_Choose = new MyComboBox("Pressure_Measure_Choose", 80, 527, 256, 0, 0);
            Pressure_Measure_Choose.SelectedIndex = 0;
            Pressure_Measure_Choose.Items.Add("МПа");
            Pressure_Measure_Choose.Items.Add("мм.рт.ст.");
            Pressure_Measure_Choose.Items.Add("бар");
            Pressure_Measure_Choose.SelectionChanged += Pressure_Measure_Choose_SelectionChanged;

            MyLabel Temperature_lbl = new MyLabel("Temperature_lbl", 340, 282, 0, 0,"Температура:");

            MyTextBox Temperature_Input = new MyTextBox("Temperature_Input", 78, 446, 282, 0, 0);
            Temperature_Input.TextChanged += Temperature_Input_TextChanged;

            MyComboBox Temperature_Measure_Choose = new MyComboBox("Temperature_Measure_Choose", 80, 527, 282, 0, 0);
            Temperature_Measure_Choose.SelectedIndex = 0;
            Temperature_Measure_Choose.Items.Add("Цельсий");
            Temperature_Measure_Choose.Items.Add("Кельвин");;
            Temperature_Measure_Choose.SelectionChanged += Temperature_Measure_Choose_SelectionChanged;

            MyButton Next_1 = new MyButton("Next_1", 100, 0, 0, 30, 30, "Далее");
            Next_1.Height = 30;
            Next_1.HorizontalAlignment = HorizontalAlignment.Right;
            Next_1.VerticalAlignment = VerticalAlignment.Bottom;
            Next_1.Click += Next_1_Click;

            MyButton Help = new MyButton("Help", 100, 30, 0, 0, 30, "Помощь");
            Help.Height = 30;
            Help.HorizontalAlignment = HorizontalAlignment.Left;
            Help.VerticalAlignment = VerticalAlignment.Bottom;

            Help.Click += Help_Click;

            MyButton Liquid_Add = new MyButton("Liquid_Add", 200, 300, 320, 0, 0,"Добавление новой жидкости");
            Liquid_Add.Height = 30;
            Liquid_Add.Visibility = Visibility.Hidden;
            Liquid_Add.Click += Liquid_Add_Click;

            Grid container_1 = new Grid();
            container_1.Name = "container_1";
            container_1.Children.Add(Liquid_type_lbl);//0
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
            container_1.Children.Add(Help);//12
            container_1.Children.Add(Liquid_Add);//13

            this.Content = container_1;
            this.Width = 750;
            this.Height = 500;
        }

        private void Liquid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Liquid_type = grid.Children[1] as MyComboBox;
            var Liquid = grid.Children[3] as MyComboBox;
            var Liquid_Add = grid.Children[13] as MyButton;

            if ((Liquid_type.SelectedIndex == 0) && (Liquid.SelectedIndex == Liquid.Items.Count - 1))
                Liquid_Add.Visibility = Visibility.Visible;
            else
                Liquid_Add.Visibility = Visibility.Hidden;
                /*
            {
                
                Liquid_Add.Visibility = Visibility.Visible;
                Liquid_Add.Margin = new Thickness(26,80,0,0);
                Liquid_parameters_lbl.Margin = new Thickness(85, 110, 0, 0);
                Pressure_lbl.Margin = new Thickness(69, 144, 0, 0);
                Pressure_Input.Margin = new Thickness(178, 146, 0, 0);
                Pressure_Measure_lbl.Margin = new Thickness(282, 144, 0, 0);
                Pressure_Measure_Choose.Margin = new Thickness(404, 146, 0, 0);
                Temperature_lbl.Margin = new Thickness(26, 178, 0, 110);
                Temperature_Input.Margin = new Thickness(178, 178, 0, 0);
                Temperature_Measure_lbl.Margin = new Thickness(282, 176, 0, 0);
                Temperature_Measure_Choose.Margin = new Thickness(404, 178, 0, 0);
            }
            else
                Liquid_Add.Visibility = Visibility.Hidden;
                 */
        }

        private void Liquid_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var Liquid_type = grid.Children[1] as MyComboBox;
            var Liquid = grid.Children[3] as MyComboBox;

            if (Liquid == null)
                return;
            if(Liquid.Items.Count != 0)
                Liquid.Items.Clear();
            if (Liquid_type.SelectedIndex == 0)
            {
                foreach (var a in Database.Query("select name from liquid_list")[0])
                {
                    Liquid.Items.Add(a);
                }
                Liquid.Items.Add("Добавить жидкость...");
                Liquid.SelectedIndex = 0;
            }

            if (Liquid_type.SelectedIndex == 1)
            {
                if (Liquid.Items.Count != 0)
                    Liquid.Items.Clear();
                var id1 = Database.Query("select id1 from boiling_points_from_composition")[0];
                var id2 = Database.Query("select id2 from boiling_points_from_composition")[0];
                for (int i = 1; i < id1.Count; i++)
                {
                    if ((id1[i-1] == id1[i]) && (id2[i-1] == id2[i]))
                    {
                        id1.RemoveAt(i);
                        id2.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < id1.Count; i++)
                {
                    var id1_name = Database.Query(String.Format("select name from liquid_list where id={0}",id1[i]))[0][0];
                    var id2_name = Database.Query(String.Format("select name from liquid_list where id={0}", id2[i]))[0][0];
                    Liquid.Items.Add(String.Format("{0} - {1}",id1_name,id2_name));
                }
                Liquid.Items.Add("Добавить смесь...");
                Liquid.SelectedIndex = 0;
            }
             
        }

        private void Pressure_Input_TextInput(object sender, TextCompositionEventArgs e)
        {
            /*
            var grid = this.Content as Grid;
            var Pressure_Input = grid.Children[6] as TextBox;
             */
        }

        //double Pressure_In = -10;
        private void Pressure_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            var grid = this.Content as Grid;
            var Pressure_Measure_Choose = grid.Children[7] as MyComboBox;
            var Pressure_Input = grid.Children[6] as MyTextBox;
            double result = 0;
            if (double.TryParse(Pressure_Input.Text, out result) == true)
            {
                MyLabel PressureInputError2 = new MyLabel("PressureInputError2", 200, 0, 40, 0, 0, "норм");
                grid.Children.Add(PressureInputError2);

                if (Pressure_Input.Text.Length > 0)
                    Pressure_In = int.Parse(Pressure_Input.Text);
                else
                    Pressure_In = -10;
            }
            else
            {
                MyLabel PressureInputError = new MyLabel("PressureInputError", 200, 0, 0, 0, 0, "Введено неправильное значение.");
                grid.Children.Add(PressureInputError);
            }
            */ 
            
            /*
            if ((Pressure_Measure_Choose.SelectedIndex == 0) && (Pressure_In >= 0))
            {
                Pressure_In *= 760;
                MyLabel proba = new MyLabel("proba", 100, 0, 0, 0, 0, Pressure_In.ToString() + " мм.рт.ст.");
                grid.Children.Add(proba);
            }

            if ((Pressure_Measure_Choose.SelectedIndex == 2) && (Pressure_In >= 0))
            {
                Pressure_In = 100000 * Pressure_In / 101325 * 760;
                MyLabel proba = new MyLabel("proba", 100, 0, 30, 0, 0, Pressure_In.ToString() + " мм.рт.ст.");
                grid.Children.Add(proba);
            }*/
        }

        private void Pressure_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            var grid = this.Content as Grid;
            var Pressure_Measure_Choose = grid.Children[7] as MyComboBox;

            if ((Pressure_Measure_Choose.SelectedIndex == 0) && (Pressure_In >= 0))
            {
                Pressure_In *= 760;
                MyLabel proba = new MyLabel("proba", 100, 0, 0, 0, 0, Pressure_In.ToString() + " мм.рт.ст.");
                grid.Children.Add(proba);
            }

            if ((Pressure_Measure_Choose.SelectedIndex == 2) && (Pressure_In >= 0))
            {
                Pressure_In = 100000 * Pressure_In / 101325 * 760;
                MyLabel proba = new MyLabel("proba", 100, 0, 30, 0, 0, Pressure_In.ToString() + " мм.рт.ст.");
                grid.Children.Add(proba);
            }
             */
        }

        //int Temperature_In = -10;
        private void Temperature_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            var grid = this.Content as Grid;
            var Temperature_Measure_Choose = grid.Children[10] as MyComboBox;
            var Temperature_Input = grid.Children[9] as MyTextBox;
            if (Temperature_Input.Text.Length > 0)
                Temperature_In = int.Parse(Temperature_Input.Text);
            else
                Temperature_In = -10;
            if ((Temperature_Measure_Choose.SelectedIndex == 1) && (Temperature_In >= 0))
            {
                Temperature_In += 273;
            }
             */
        }

        private void Temperature_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            var grid = this.Content as Grid;
            var Temperature_Measure_Choose = grid.Children[10] as MyComboBox;

            if ((Temperature_Measure_Choose.SelectedIndex == 1) && (Temperature_In >= 0))
            {
                Temperature_In += 273;
            }
             */
        }

        double Pressure_In = 0;
        double Temperature_In = 0;
        private void Next_1_Click(object sender, RoutedEventArgs e)
        {
            bool g = true;
            var grid = this.Content as Grid;
            var Pressure_Input = grid.Children[6] as TextBox;
            var Pressure_Measure_Choose = grid.Children[7] as MyComboBox;
            var Temperature_Input = grid.Children[9] as TextBox;
            var Temperature_Measure_Choose = grid.Children[10] as MyComboBox;
            double result = 0;

            if ((double.TryParse(Pressure_Input.Text, out result) == false) ||
                (double.TryParse(Temperature_Input.Text, out result) == false))
                g = false;

            if (g == true)
            {
                Pressure_In = double.Parse(Pressure_Input.Text);
                Temperature_In = double.Parse(Temperature_Input.Text);

                if (Pressure_Measure_Choose.SelectedIndex == 0)
                {
                    Pressure_In *= 760;
                }
                if (Pressure_Measure_Choose.SelectedIndex == 2)
                {
                    Pressure_In = 100000 * Pressure_In / 101325 * 760;
                }
                if (Temperature_Measure_Choose.SelectedIndex == 1)
                {
                    Temperature_In += 273;
                }
                MessageBox.Show("Все круто!");
                Window_Add_Pipeline New_Pipeline = new Window_Add_Pipeline();
                New_Pipeline.Show();
            }

            if (g == false)
            {
                MessageBox.Show("Некоторые поля не заполнены/введены неверно.");
            }
            
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выбран пункт Помощь");
        }
        
        private void Liquid_Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Add_Liquid New_Liquid = new Window_Add_Liquid();
            New_Liquid.Show();
        }
        
        
        

    }
}
