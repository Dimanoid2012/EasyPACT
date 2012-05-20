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
    public class Window_Add_Liquid : Window
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

        public Window_Add_Liquid()
            {
                Grid Grid_Add_Liquid = new Grid();
                Grid_Add_Liquid.Name = "Grid_Add_Liquid";





                MyButton OK_Add_Liquid = new MyButton()
                {
                    Name = "OK_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 30, 30),
                    Content = "Добавить"
                };
                OK_Add_Liquid.Click += OK_Add_Liquid_Click;

                MyButton Help_Add_Liquid = new MyButton()
                {
                    Name = "Help_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(30, 0, 0, 30),
                    Content = "Помощь"
                };
                Help_Add_Liquid.Click += Help_Add_Liquid_Click;

                MyButton Cancel_Add_Liquid = new MyButton()
                {
                    Name = "Cancel_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 140, 30),
                    Content = "Отменить"
                };
                Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;

                MyLabel New_Liquid_Name_lbl = new MyLabel()
                {
                    Width = 160,
                    Height = 28,
                    Name = "New_Liquid_Name_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 130, 0, 0),
                    Content = "Название жидкости:"
                };

                MyTextBox New_Liquid_Name = new MyTextBox()
                {
                    MinWidth = 100,
                    Name = "New_Liquid_Name",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(150, 130, 0, 0)
                };

                MyLabel New_Liquid_Name_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Liquid_Name_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 155, 0, 0),
                    Content = "Пример: 'Ацетон'; 'Азотная кислота, 50%'"
                };

                MyLabel New_Chemical_Formula_lbl = new MyLabel()
                {
                    Width = 170,
                    Height = 28,
                    Name = "New_Chemical_Formula_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(350, 130, 0, 0),
                    Content = "Химическая формула:"
                };

                MyTextBox New_Chemical_Formula = new MyTextBox()
                {
                    Width = 100,
                    Name = "New_Chemical_Formula",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(480, 130, 0, 0)
                };

                MyLabel New_Chemical_Formula_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Chemical_Formula_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(370, 155, 0, 0),
                    Content = "Пример: 'CH3COCH3', 'NH3', 'HNO3'"
                };

                MyLabel New_Molar_Mass_lbl = new MyLabel()
                {
                    Name = "New_Molar_Mass_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(655, 130, 0, 0),
                    Content = "Молярная масса:"
                };

                MyTextBox New_Molar_Mass = new MyTextBox()
                {
                    Width = 100,
                    Name = "New_Molar_Mass",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(760, 130, 0, 0),
                };

                MyLabel New_Molar_Mass_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Molar_Mass_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(700, 155, 0, 0),
                    Content = "Пример: '63,01', '17,03'"
                };


                MyLabel Table_Data_lbl = new MyLabel()
                {
                    Name = "Table_Data_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(430, 190, 0, 0),
                    Content = "Зависимости"
                };

                MyLabel New_Temp_Viscosity_lbl = new MyLabel()
                {
                    Name = "New_Temp_Viscosity_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(70, 210, 0, 0),
                    Content = "Вязкость от температуры"
                };

                MyLabel New_Temp_Density_lbl = new MyLabel()
                {
                    Name = "New_Temp_Density_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(390, 210, 0, 0),
                    Content = "Плотность от температуры"
                };

                MyLabel New_Pressure_BoilingPoint_lbl = new MyLabel()
                {
                    Name = "New_Pressure_BoilingPoint_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(685, 210, 0, 0),
                    Content = "Точка кипения от давления"
                };

                MyLabel First_Temperature_lbl = new MyLabel()
                {
                    Name = "First_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(40, 240, 0, 0),
                    Content = "Температура"
                };

                MyTextBox First_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "First_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 260, 0, 0)
                };

                MyLabel First_Viscosity_lbl = new MyLabel()
                {
                    Name = "First_Viscosity_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(165, 240, 0, 0),
                    Content = "Вязкость"
                };

                MyTextBox First_Viscosity = new MyTextBox()
                {
                    Width = 100,
                    Name = "First_Viscosity",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(145, 260, 0, 0)
                };

                MyLabel Second_Temperature_lbl = new MyLabel()
                {
                    Name = "Second_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(370, 240, 0, 0),
                    Content = "Температура"
                };

                MyTextBox Second_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "Second_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(360, 260, 0, 0)
                };

                MyLabel Second_Density_lbl = new MyLabel()
                {
                    Name = "Second_Density_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(490, 240, 0, 0),
                    Content = "Плотность"
                };

                MyTextBox Second_Density = new MyTextBox()
                {
                    Width = 100,
                    Name = "Second_Density",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(475, 260, 0, 0)
                };

                MyLabel Third_Pressure_lbl = new MyLabel()
                {
                    Name = "Third_Pressure_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(675, 240, 0, 0),
                    Content = "Давление"
                };

                MyTextBox Third_Pressure = new MyTextBox()
                {
                    Width = 100,
                    Name = "Third_Pressure",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(655, 260, 0, 0)
                };

                MyLabel Third_Temperature_lbl = new MyLabel()
                {
                    Name = "Third_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(775, 240, 0, 0),
                    Content = "Точка кипения"
                };

                MyTextBox Third_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "Third_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(770, 260, 0, 0)
                };





                MyButton Add_Temp_Viscosity = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Temp_Viscosity",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(75, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Temp_Viscosity.Click += Add_Temp_Viscosity_Click;

                MyButton Add_Temp_Density = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Temp_Density",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(405, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Temp_Density.Click += Add_Temp_Density_Click;

                MyButton Add_Pressure_BoilingPoint = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Pressure_BoilingPoint",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(705, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Pressure_BoilingPoint.Click += Add_Pressure_BoilingPointy_Click;







                Grid_Add_Liquid.Children.Add(New_Liquid_Name_lbl);
                Grid_Add_Liquid.Children.Add(New_Liquid_Name);
                Grid_Add_Liquid.Children.Add(New_Liquid_Name_Help);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_lbl);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_Help);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_lbl);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_Help);
                Grid_Add_Liquid.Children.Add(OK_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Cancel_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Help_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Table_Data_lbl);
                Grid_Add_Liquid.Children.Add(New_Temp_Viscosity_lbl);
                Grid_Add_Liquid.Children.Add(New_Temp_Density_lbl);
                Grid_Add_Liquid.Children.Add(New_Pressure_BoilingPoint_lbl);
                Grid_Add_Liquid.Children.Add(First_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(First_Temperature);
                Grid_Add_Liquid.Children.Add(First_Viscosity_lbl);
                Grid_Add_Liquid.Children.Add(First_Viscosity);
                Grid_Add_Liquid.Children.Add(Second_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(Second_Temperature);
                Grid_Add_Liquid.Children.Add(Second_Density_lbl);
                Grid_Add_Liquid.Children.Add(Second_Density);
                Grid_Add_Liquid.Children.Add(Third_Pressure_lbl);
                Grid_Add_Liquid.Children.Add(Third_Pressure);
                Grid_Add_Liquid.Children.Add(Third_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(Third_Temperature);
                Grid_Add_Liquid.Children.Add(Add_Temp_Viscosity);
                Grid_Add_Liquid.Children.Add(Add_Temp_Density);
                Grid_Add_Liquid.Children.Add(Add_Pressure_BoilingPoint);

                Name = "Window_Add_Liquid";
                Content = Grid_Add_Liquid;
                Width = 900;
                Height = 500;
                Title = "Добавление новой жидкости";
            }

            private void Liquid_Add_Click(object sender, RoutedEventArgs e)
            {
                /*
                MyButton OK_Add_Liquid = new MyButton()
                {
                    Name = "OK_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 30, 30),
                    Content = "Добавить"
                };
                OK_Add_Liquid.Click += OK_Add_Liquid_Click;

                MyButton Help_Add_Liquid = new MyButton()
                {
                    Name = "Help_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(30, 0, 0, 30),
                    Content = "Помощь"
                };
                Help_Add_Liquid.Click += Help_Add_Liquid_Click;

                MyButton Cancel_Add_Liquid = new MyButton()
                {
                    Name = "Cancel_Add_Liquid",
                    Width = 100,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 140, 30),
                    Content = "Отменить"
                };
                Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;

                MyLabel New_Liquid_Name_lbl = new MyLabel()
                {
                    Width = 160,
                    Height = 28,
                    Name = "New_Liquid_Name_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 130, 0, 0),
                    Content = "Название жидкости:"
                };

                MyTextBox New_Liquid_Name = new MyTextBox()
                {
                    MinWidth = 100,
                    Name = "New_Liquid_Name",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(150, 130, 0, 0)
                };

                MyLabel New_Liquid_Name_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Liquid_Name_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 155, 0, 0),
                    Content = "Пример: 'Ацетон'; 'Азотная кислота, 50%'"
                };

                MyLabel New_Chemical_Formula_lbl = new MyLabel()
                {
                    Width = 170,
                    Height = 28,
                    Name = "New_Chemical_Formula_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(350, 130, 0, 0),
                    Content = "Химическая формула:"
                };

                MyTextBox New_Chemical_Formula = new MyTextBox()
                {
                    Width = 100,
                    Name = "New_Chemical_Formula",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(480, 130, 0, 0)
                };

                MyLabel New_Chemical_Formula_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Chemical_Formula_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(370, 155, 0, 0),
                    Content = "Пример: 'CH3COCH3', 'NH3', 'HNO3'"
                };

                MyLabel New_Molar_Mass_lbl = new MyLabel()
                {
                    Name = "New_Molar_Mass_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(655, 130, 0, 0),
                    Content = "Молярная масса:"
                };

                MyTextBox New_Molar_Mass = new MyTextBox()
                {
                    Width = 100,
                    Name = "New_Molar_Mass",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(760, 130, 0, 0),
                };

                MyLabel New_Molar_Mass_Help = new MyLabel()
                {
                    Height = 28,
                    Name = "New_Molar_Mass_Help",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(700, 155, 0, 0),
                    Content = "Пример: '63,01', '17,03'"
                };


                MyLabel Table_Data_lbl = new MyLabel()
                {
                    Name = "Table_Data_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(430, 190, 0, 0),
                    Content = "Зависимости"
                };

                MyLabel New_Temp_Viscosity_lbl = new MyLabel()
                {
                    Name = "New_Temp_Viscosity_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(70, 210, 0, 0),
                    Content = "Вязкость от температуры"
                };

                MyLabel New_Temp_Density_lbl = new MyLabel()
                {
                    Name = "New_Temp_Density_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(390, 210, 0, 0),
                    Content = "Плотность от температуры"
                };

                MyLabel New_Pressure_BoilingPoint_lbl = new MyLabel()
                {
                    Name = "New_Pressure_BoilingPoint_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(685, 210, 0, 0),
                    Content = "Точка кипения от давления"
                };

                MyLabel First_Temperature_lbl = new MyLabel()
                {
                    Name = "First_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(40, 240, 0, 0),
                    Content = "Температура"
                };

                MyTextBox First_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "First_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(30, 260, 0, 0)
                };

                MyLabel First_Viscosity_lbl = new MyLabel()
                {
                    Name = "First_Viscosity_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(165, 240, 0, 0),
                    Content = "Вязкость"
                };

                MyTextBox First_Viscosity = new MyTextBox()
                {
                    Width = 100,
                    Name = "First_Viscosity",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(145, 260, 0, 0)
                };

                MyLabel Second_Temperature_lbl = new MyLabel()
                {
                    Name = "Second_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(370, 240, 0, 0),
                    Content = "Температура"
                };

                MyTextBox Second_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "Second_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(360, 260, 0, 0)
                };

                MyLabel Second_Density_lbl = new MyLabel()
                {
                    Name = "Second_Density_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(490, 240, 0, 0),
                    Content = "Плотность"
                };

                MyTextBox Second_Density = new MyTextBox()
                {
                    Width = 100,
                    Name = "Second_Density",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(475, 260, 0, 0)
                };

                MyLabel Third_Pressure_lbl = new MyLabel()
                {
                    Name = "Third_Pressure_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(675, 240, 0, 0),
                    Content = "Давление"
                };

                MyTextBox Third_Pressure = new MyTextBox()
                {
                    Width = 100,
                    Name = "Third_Pressure",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(655, 260, 0, 0)
                };

                MyLabel Third_Temperature_lbl = new MyLabel()
                {
                    Name = "Third_Temperature_lbl",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(775, 240, 0, 0),
                    Content = "Точка кипения"
                };

                MyTextBox Third_Temperature = new MyTextBox()
                {
                    Width = 100,
                    Name = "Third_Temperature",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(770, 260, 0, 0)
                };





                MyButton Add_Temp_Viscosity = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Temp_Viscosity",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(75, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Temp_Viscosity.Click += Add_Temp_Viscosity_Click;

                MyButton Add_Temp_Density = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Temp_Density",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(405, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Temp_Density.Click += Add_Temp_Density_Click;

                MyButton Add_Pressure_BoilingPoint = new MyButton()
                {
                    Width = 120,
                    Name = "Add_Pressure_BoilingPoint",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(705, 285, 0, 0),
                    Content = "Добавить точку"
                };
                Add_Pressure_BoilingPoint.Click += Add_Pressure_BoilingPointy_Click;


                
                Grid Grid_Add_Liquid = new Grid();
                Grid_Add_Liquid.Name = "Grid_Add_Liquid";
                
                Grid_Add_Liquid.Children.Add(New_Liquid_Name_lbl);
                Grid_Add_Liquid.Children.Add(New_Liquid_Name);
                Grid_Add_Liquid.Children.Add(New_Liquid_Name_Help);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_lbl);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula);
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_Help);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_lbl);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass);
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_Help);
                Grid_Add_Liquid.Children.Add(OK_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Cancel_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Help_Add_Liquid);
                Grid_Add_Liquid.Children.Add(Table_Data_lbl);
                Grid_Add_Liquid.Children.Add(New_Temp_Viscosity_lbl);
                Grid_Add_Liquid.Children.Add(New_Temp_Density_lbl);
                Grid_Add_Liquid.Children.Add(New_Pressure_BoilingPoint_lbl);
                Grid_Add_Liquid.Children.Add(First_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(First_Temperature);
                Grid_Add_Liquid.Children.Add(First_Viscosity_lbl);
                Grid_Add_Liquid.Children.Add(First_Viscosity);
                Grid_Add_Liquid.Children.Add(Second_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(Second_Temperature);
                Grid_Add_Liquid.Children.Add(Second_Density_lbl);
                Grid_Add_Liquid.Children.Add(Second_Density);
                Grid_Add_Liquid.Children.Add(Third_Pressure_lbl);
                Grid_Add_Liquid.Children.Add(Third_Pressure);
                Grid_Add_Liquid.Children.Add(Third_Temperature_lbl);
                Grid_Add_Liquid.Children.Add(Third_Temperature);
                Grid_Add_Liquid.Children.Add(Add_Temp_Viscosity);
                Grid_Add_Liquid.Children.Add(Add_Temp_Density);
                Grid_Add_Liquid.Children.Add(Add_Pressure_BoilingPoint);
                /*
                Window Window_Add_Liquid = new Window()
                {
                    Name = "Window_Add_Liquid",
                    Content = Grid_Add_Liquid,
                    Width = 900,
                    Height = 500,
                    Title = "Добавление новой жидкости"
                };

                Window_Add_Liquid.Show();
                 */
            }

            private void OK_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Выбран пункт Добавить");
            }

            private void Help_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Выбран пункт Помощь в добавлении новой жидкости");
            }

            private void Cancel_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Выбран пункт Отменить добавление новой жидкости");
            }
            int a = 285;
            private void Add_Temp_Viscosity_Click(object sender, RoutedEventArgs e)
            {
                a += 25;
                var Grid_Add_Liquid = this.Content as Grid;
                var Add_Temp_Viscosity = Grid_Add_Liquid.Children[28] as MyButton;
                Add_Temp_Viscosity.Margin = new Thickness(75, a, 0, 0);
                //MessageBox.Show("Выбран пункт Добавить точку для таблицы Температура-Вязкость");
            }

            private void Add_Temp_Density_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Выбран пункт Добавить точку для таблицы Температура-Плотность");
            }

            private void Add_Pressure_BoilingPointy_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Выбран пункт Добавить точку для таблицы Давление-Точка кипения");
            }
        }
    }