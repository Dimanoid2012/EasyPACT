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

namespace EasyPACT_Graphic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class MyLabel : Label
        {

        }

        public class MyButton : Button
        {

        }

        public class MyComboBox : ComboBox
        {

        }

        public class MyTextBox : TextBox
        {
            
        }

        public MainWindow()
        {
            InitializeComponent();

            MyLabel Liquid_type_lbl = new MyLabel()
            {
                Name = "Liquid_type_lbl",
                Content = "Выберите тип жидкости:",
                Width = 144,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(12, 12, 0, 0)
            };

            MyComboBox Liquid_type = new MyComboBox()
            {
                Name = "Liquid_type",
                Width = 313,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 12, 12, 0),
                SelectedItem = 0
            };
            Liquid_type.Items.Add("Чистая жидкость");
            Liquid_type.Items.Add("Бинарная смесь");
            Liquid_type.SelectionChanged += Liquid_type_SelectionChanged;

            MyLabel Liquid_lbl = new MyLabel()
            {
                Name = "Liquid_lbl",
                Content = "Выберите жидкость:",
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(34, 46, 0, 0)
            };

            MyComboBox Liquid = new MyComboBox()
            {
                Name = "Liquid",
                Width = 313,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(178, 46, 0, 0),
            };
            foreach (var a in Database.Query("select name from liquid_list")[0])
            {
                Liquid.Items.Add(a);
            }
            Liquid.Items.Add("Добавить жидкость...");
            Liquid.SelectedIndex = 0;

            Liquid_type.SelectionChanged += Liquid_type_SelectionChanged;

            MyLabel Liquid_parameters_lbl = new MyLabel()
            {
                Name = "Liquid_parameters_lbl",
                Content = "Параметры жидкости:",
                Width = 144,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(26, 80, 0, 0)
            };

            MyLabel Pressure_lbl = new MyLabel()
            {
                Name = "Pressure_lbl",
                Content = "Давление:",
                Width = 144,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(85, 110, 0, 0)
            };

            MyTextBox Pressure_Input = new MyTextBox()
            {
                Name = "Pressure_Input",
                Width = 80,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(178,112,0,0)
            };
            Pressure_Input.TextChanged += Pressure_Input_TextChanged;

            MyLabel Pressure_Measure_lbl = new MyLabel()
            {
                Name = "Pressure_Measure_lbl",
                Content = "Единицы измерения:",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(282, 110, 0, 173)
            };

            MyComboBox Pressure_Measure_Choose = new MyComboBox()
            {
                Name = "Pressure_Measure_Choose",
                Width = 87,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(404, 112, 0, 0),
                SelectedItem = 0
            };
            Pressure_Measure_Choose.Items.Add("МПа");
            Pressure_Measure_Choose.Items.Add("мм.рт.ст.");
            Pressure_Measure_Choose.Items.Add("бар");
            Pressure_Measure_Choose.SelectionChanged += Pressure_Measure_Choose_SelectionChanged;

            MyLabel Temperature_lbl = new MyLabel()
            {
                Name = "Temperature_lbl",
                Content = "Температура:",
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(69, 0, 0, 139)
            };

            MyTextBox Temperature_Input = new MyTextBox()
            {
                Name = "Temperature_Input",
                Width = 80,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(178, 146, 0, 0)
            };
            Temperature_Input.TextChanged += Temperature_Input_TextChanged;

            MyLabel Temperature_Measure_lbl = new MyLabel()
            {
                Name = "Temperature_Measure_lbl",
                Content = "Единицы измерения:",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(282, 144, 0, 0)
            };

            MyComboBox Temperature_Measure_Choose = new MyComboBox()
            {
                Name = "Temperature_Measure_Choose",
                Width = 87,
                Height = 23,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(404, 146, 0, 0),
                SelectedItem = 0
            };
            Temperature_Measure_Choose.Items.Add("Цельсий");
            Temperature_Measure_Choose.Items.Add("Кельвин");;
            Temperature_Measure_Choose.SelectionChanged += Temperature_Measure_Choose_SelectionChanged;

            Grid kontainer = new Grid();
            kontainer.Children.Add(Liquid_type_lbl);
            kontainer.Children.Add(Liquid_type);
            kontainer.Children.Add(Liquid_lbl);
            kontainer.Children.Add(Liquid);
            kontainer.Children.Add(Liquid_parameters_lbl);
            kontainer.Children.Add(Pressure_lbl);
            kontainer.Children.Add(Pressure_Input);
            kontainer.Children.Add(Pressure_Measure_lbl);
            kontainer.Children.Add(Pressure_Measure_Choose);
            kontainer.Children.Add(Temperature_lbl);
            kontainer.Children.Add(Temperature_Input);
            kontainer.Children.Add(Temperature_Measure_lbl);
            kontainer.Children.Add(Temperature_Measure_Choose);
        }

        private void Liquid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((Liquid_type.SelectedIndex == 0) && (Liquid.SelectedIndex == Liquid.Items.Count - 1))
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
        }

        private void Liquid_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void Pressure_Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Pressure_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Temperature_Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Temperature_Measure_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        
    }
}
