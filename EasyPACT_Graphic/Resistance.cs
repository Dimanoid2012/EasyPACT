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
using System.Windows.Controls.Primitives;

namespace EasyPACT_Graphic
{
    public class Resistance : Window
    {
        LiquidInPipeline lip_In;
        LiquidInPipeline lip_Out;

        public Resistance(EasyPACT.LiquidInPipeline lip_In, EasyPACT.LiquidInPipeline lip_Out)
        {
            this.lip_In = lip_In;
            this.lip_Out = lip_Out;

            Grid Grid_Add_Resistance = new MyGrid();
            Grid_Add_Resistance.Name = "Grid_Add_Resistance";

            MyLabel Local_Resistance_In_lbl = new MyLabel("Local_Resistance_In_lbl", 30, 100, 0, 0, "Местные сопротивления:");

            MyComboBox Local_Resistance_In = new MyComboBox("Local_Resistance_In_1", 124, 200, 102, 0, 0);
            Local_Resistance_In.Items.Add("Выберите сопротивление");
            Local_Resistance_In.Items.Add("Вход в трубу");
            Local_Resistance_In.Items.Add("Выход и трубы");
            Local_Resistance_In.Items.Add("Диафрагма");
            Local_Resistance_In.Items.Add("Отвод");
            Local_Resistance_In.Items.Add("Колено");
            Local_Resistance_In.Items.Add("Вентиль нормальный");
            Local_Resistance_In.Items.Add("Вентиль прямоточный");
            Local_Resistance_In.Items.Add("Кран пробочный");
            Local_Resistance_In.Items.Add("Задвижка");
            Local_Resistance_In.SelectedIndex = 0;
            Local_Resistance_In.SelectionChanged += Local_Resistance_In_SelectionChanged;

            // Комбобоксы для сопротивлений

            MyComboBox First = new MyComboBox("First_1", 100, 400, 102, 0, 0);
            First.Visibility = Visibility.Hidden;

            MyComboBox Second = new MyComboBox("Second_1", 100, 510, 102, 0, 0);
            Second.Visibility = Visibility.Hidden;

            MyTextBox Third = new MyTextBox("Third_1", 100, 400, 102, 0, 0);
            Third.Visibility = Visibility.Hidden;
            /*
            MyLabel Number_Local_Resistance_In_lbl = new MyLabel("Number_Local_Resistance_In_lbl", 334, 100, 0, 0, "Количество:");

            MyTextBox Number_Local_Resistance_In = new MyTextBox("Number_Local_Resistance_In", 60, 425, 100, 0, 0);

            MyLabel Shtyk = new MyLabel("Shtyk", 489, 100, 0, 0, "штук.");

            MyLabel Size = new MyLabel("Size_1", 556, 100, 0, 0, "Размеры");

            MyComboBox Size_Choose = new MyComboBox("", 100, 620, 102, 0, 0);
            */
            MyButton Add_New_Local_Resistance = new MyButton("Add_New_Local_Resistance", 100, 100, 130, 0, 0, "Добавить");
            Add_New_Local_Resistance.Click += Add_New_Local_Resistance_Click;

            ScrollBar hSBar = new ScrollBar();
            hSBar.Orientation = Orientation.Vertical;
            hSBar.HorizontalAlignment = HorizontalAlignment.Right;
            hSBar.Width = 10;
            hSBar.Height = 200;
            hSBar.Minimum = 0;
            hSBar.Value = 0;
            hSBar.Scroll += scroll;
            hSBar.Visibility = Visibility.Hidden;

            MyButton Next_3 = new MyButton("Next_3", 150, 0, 0, 20, 7, "Далее");
            Next_3.HorizontalAlignment = HorizontalAlignment.Right;
            Next_3.VerticalAlignment = VerticalAlignment.Bottom;
            Next_3.Background = Brushes.DarkGreen;
            Next_3.FontSize = 12;
            Next_3.Foreground = Brushes.White;
            Next_3.Click += Next_3_Click;

            Grid_Add_Resistance.Children.Add(Local_Resistance_In_lbl);//0
            Grid_Add_Resistance.Children.Add(Local_Resistance_In);//1
            Grid_Add_Resistance.Children.Add(Add_New_Local_Resistance);//2
            Grid_Add_Resistance.Children.Add(hSBar);//3
            Grid_Add_Resistance.Children.Add(First);//4
            Grid_Add_Resistance.Children.Add(Second);//5
            Grid_Add_Resistance.Children.Add(Third);//6

            this.Content = Grid_Add_Resistance;
            this.Title = "Местные сопротивления";
        }

        private void Local_Resistance_In_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Grid_Add_Resistance = this.Content as MyGrid;
            var Local_Resistance_In = sender as MyComboBox;
            string a = Local_Resistance_In.Name.Split('_')[3];
            var First = Grid_Add_Resistance.GetElementByName("First_" + a) as MyComboBox;
            var Second = Grid_Add_Resistance.GetElementByName("Second_" + a) as MyComboBox;
            var Third = Grid_Add_Resistance.GetElementByName("Third_" + a) as MyTextBox;

            First.Visibility = Visibility.Hidden;
            Second.Visibility = Visibility.Hidden;
            Third.Visibility = Visibility.Hidden;

            switch (Local_Resistance_In.SelectedIndex)
            {
                case 1:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("С острыми краями");
                    First.Items.Add("С закругленными краями");
                    First.SelectedIndex = 0;
                    break;
                case 2:
                    break;
                case 3:
                    Third.Visibility = Visibility.Visible;
                    Second.Visibility = Visibility.Visible;
                    Second.Items.Add("м");
                    Second.Items.Add("мм");
                    Second.SelectedIndex = 0;
                    break;
                case 4:
                    First.Visibility = Visibility.Visible;
                    Second.Visibility = Visibility.Visible;
                    First.Items.Add("Угол отвода,град.");
                    First.Items.Add("20");
                    First.Items.Add("30");
                    First.Items.Add("45");
                    First.Items.Add("60");
                    First.Items.Add("90");
                    First.Items.Add("110");
                    First.Items.Add("130");
                    First.Items.Add("150");
                    First.Items.Add("180");
                    Second.Items.Add("1");
                    Second.Items.Add("2");
                    Second.Items.Add("4");
                    Second.Items.Add("6");
                    Second.Items.Add("15");
                    Second.Items.Add("30");
                    Second.Items.Add("50");
                    First.SelectedIndex = 0;
                    break;
                case 5:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("Условный проход,мм");
                    First.Items.Add("12.5");
                    First.Items.Add("25");
                    First.Items.Add("37");
                    First.Items.Add("50");
                    First.SelectedIndex = 0;
                    break;
                case 6:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("Условный проход,мм");
                    First.Items.Add("13");
                    First.Items.Add("20");
                    First.Items.Add("40");
                    First.Items.Add("80");
                    First.Items.Add("100");
                    First.Items.Add("150");
                    First.Items.Add("200");
                    First.Items.Add("250");
                    First.Items.Add("350");
                    First.SelectedIndex = 0;
                    break;
                case 7:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("Условный проход,мм");
                    First.Items.Add("25");
                    First.Items.Add("38");
                    First.Items.Add("50");
                    First.Items.Add("65");
                    First.Items.Add("76");
                    First.Items.Add("100");
                    First.Items.Add("150");
                    First.Items.Add("200");
                    First.Items.Add("250");
                    First.SelectedIndex = 0;
                    break;
                case 8:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("Условный проход,мм");
                    First.Items.Add("13");
                    First.Items.Add("19");
                    First.Items.Add("25");
                    First.Items.Add("32");
                    First.Items.Add("38");
                    First.Items.Add("50");
                    First.SelectedIndex = 0;
                    break;
                case 9:
                    First.Visibility = Visibility.Visible;
                    First.Items.Add("Условный проход,мм");
                    First.Items.Add("15-100");
                    First.Items.Add("175-200");
                    First.Items.Add("300 и выше");
                    First.SelectedIndex = 0;
                    break;

            }
        }

        int a_r = 130;
        int resistance_Count = 1;
        private void Add_New_Local_Resistance_Click(object sender, RoutedEventArgs e)
        {
            resistance_Count++;
            a_r += 30;
            var Grid_Add_Resistance = this.Content as MyGrid;
            var Add_New_Local_Resistance = Grid_Add_Resistance.Children[2] as MyButton;
            var hSBar = Grid_Add_Resistance.Children[3] as ScrollBar;

            Add_New_Local_Resistance.Margin = new Thickness(100, a_r, 0, 0);
            Add_New_Local_Resistance.but_top = a_r;
            a_r -= 30;

            MyLabel Local_Resistance_In_lbl = new MyLabel("Local_Resistance_In_lbl", 30, a_r, 0, 0, "Местные сопротивления:");

            MyComboBox Local_Resistance_In = new MyComboBox("Local_Resistance_In_" + resistance_Count.ToString(), 124, 200, a_r, 0, 0);
            Local_Resistance_In.Items.Add("Выберите сопротивление");
            Local_Resistance_In.Items.Add("Вход в трубу");
            Local_Resistance_In.Items.Add("Выход и трубы");
            Local_Resistance_In.Items.Add("Диафрагма");
            Local_Resistance_In.Items.Add("Отвод");
            Local_Resistance_In.Items.Add("Колено");
            Local_Resistance_In.Items.Add("Вентиль нормальный");
            Local_Resistance_In.Items.Add("Вентиль прямоточный");
            Local_Resistance_In.Items.Add("Кран пробочный");
            Local_Resistance_In.Items.Add("Задвижка");
            Local_Resistance_In.SelectedIndex = 0;
            Local_Resistance_In.SelectionChanged += Local_Resistance_In_SelectionChanged;

            MyComboBox First = new MyComboBox("First_" + resistance_Count.ToString(), 100, 400, a_r, 0, 0);
            First.Visibility = Visibility.Hidden;

            MyComboBox Second = new MyComboBox("Second_" + resistance_Count.ToString(), 100, 510, a_r, 0, 0);
            Second.Visibility = Visibility.Hidden;

            MyTextBox Third = new MyTextBox("Third_" + resistance_Count.ToString(), 100, 400, a_r, 0, 0);
            Third.Visibility = Visibility.Hidden;
            /*
            MyLabel Number_Local_Resistance_In_lbl = new MyLabel("Number_Local_Resistance_In_lbl", 334, a_r, 0, 0, "Количество:");

            MyTextBox Number_Local_Resistance_In = new MyTextBox("Number_Local_Resistance_In", 60, 425, a_r, 0, 0);

            MyLabel Shtyk = new MyLabel("Shtyk", 489, a_r, 0, 0, "штук.");
            */
            Grid_Add_Resistance.Children.Add(Local_Resistance_In_lbl);
            Grid_Add_Resistance.Children.Add(Local_Resistance_In);
            Grid_Add_Resistance.Children.Add(First);
            Grid_Add_Resistance.Children.Add(Second);
            Grid_Add_Resistance.Children.Add(Third);

            //Grid_Add_Resistance.Children.Add(Number_Local_Resistance_In_lbl);
            //Grid_Add_Resistance.Children.Add(Number_Local_Resistance_In);
            //Grid_Add_Resistance.Children.Add(Shtyk);
            a_r += 30;

            if (a_r > 400)
            {
                hSBar.Visibility = Visibility.Visible;
                hSBar.Maximum = a_r - 400;
            }
                
        }

        private void scroll(object sender, EventArgs e)
        {
            var Grid_Add_Resistance = this.Content as MyGrid;

            foreach (var a in Grid_Add_Resistance.Children)
            {
                FrameworkElement b = a as FrameworkElement;
                ScrollBar send = sender as ScrollBar;
                var ar = b.ToString().Split(',');
                List<int> ar1 = new List<int>();
                if ((b != send) & (ar.Length == 4))
                {
                    for (int i = 0; i < ar.Length; i++)
                    {
                        ar1.Add(int.Parse(ar[i]));
                    }
                    b.Margin = new Thickness(ar1[0], ar1[1] - send.Value, ar1[2], ar1[3]);
                }
            }
        }

        private void Next_3_Click(object sender, RoutedEventArgs e)
        {
            var Grid_Add_Resistance = this.Content as MyGrid;

            for (int i = 1; i <= resistance_Count; i++)
            {
                string res_str = "";
                var Local_Resistance_In = Grid_Add_Resistance.GetElementByName("Local_Resistance_In_" + i.ToString()) as MyComboBox;
                res_str += Local_Resistance_In.SelectedIndex.ToString() + " ";
                var First = Grid_Add_Resistance.GetElementByName("First_" + i.ToString()) as MyComboBox;
                var Second = Grid_Add_Resistance.GetElementByName("Second_" + i.ToString()) as MyComboBox;
                var Third = Grid_Add_Resistance.GetElementByName("Third_" + i.ToString()) as MyTextBox;
                if (First.Visibility == Visibility.Visible)
                {
                    res_str += First.SelectedValue;
                    if (Second.Visibility == Visibility.Visible)
                    {
                        res_str += " " + Second.SelectedValue;
                    }
                }
                else
                {
                    if (Third.Visibility == Visibility.Visible)
                    {
                        res_str += Third.Text;
                    }
                }
                lip_In.Pipeline.AddLocalResistance(res_str);

                /*
                // убрать: задаем сеть
                
                Network.Create(lip_In, lip_Out);
                Network.Get().SetProductivity(rashod);
                Network.Get().ChooseHeatExchanger(Temperature_Out, Temperature_Out + 20);
                Network.Get().ChooseCentrifugalPump(rashod, h_geom); // мб расход убрать

                //Network.Get().ForcingLine. обратиться к элементу сети
                */
            }
        }

    }
}