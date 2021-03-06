﻿using System;
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
    public class Window_Add_Liquid : Window
    {
        public Window_Add_Liquid()
            {
                Grid Grid_Add_Liquid = new MyGrid();
                Grid_Add_Liquid.Name = "Grid_Add_Liquid";
                
                MyButton OK_Add_Liquid = new MyButton("OK_Add_Liquid", 150, 0, 0, 20, 7, "Добавить");
                OK_Add_Liquid.Height = 30;
                OK_Add_Liquid.HorizontalAlignment = HorizontalAlignment.Right;
                OK_Add_Liquid.VerticalAlignment = VerticalAlignment.Bottom;
                OK_Add_Liquid.Background = Brushes.DarkGreen;
                OK_Add_Liquid.Click += OK_Add_Liquid_Click;

                MyButton Help_Add_Liquid = new MyButton("Help_Add_Liquid", 70, 18, 0, 0, 7, "Справка");
                Help_Add_Liquid.Height = 30;
                Help_Add_Liquid.VerticalAlignment = VerticalAlignment.Bottom;
                Help_Add_Liquid.Background = Brushes.DarkGreen;
                Help_Add_Liquid.Click += Help_Add_Liquid_Click;
                /*
                MyButton Cancel_Add_Liquid = new MyButton("Cancel_Add_Liquid", 100, 0, 0, 140, 30, "Отменить");
                Cancel_Add_Liquid.Height = 30;
                Cancel_Add_Liquid.HorizontalAlignment = HorizontalAlignment.Right;
                Cancel_Add_Liquid.VerticalAlignment = VerticalAlignment.Bottom;
                Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;
                */
                MyLabel New_Liquid_Name_lbl = new MyLabel("New_Liquid_Name_lbl",160, 30, 120, 0, 0, "Название вещества:");
                New_Liquid_Name_lbl.Height = 28;

                MyTextBox New_Liquid_Name = new MyTextBox("New_Liquid_Name", 100, 171, 121, 0, 0);

                MyLabel New_Liquid_Name_Help = new MyLabel("New_Liquid_Name_Help", 30, 145, 0, 0, "Пример: 'Ацетон'; 'Азотная кислота, 50%'", 10);

                MyLabel New_Chemical_Formula_lbl = new MyLabel("New_Chemical_Formula_lbl", 170, 332, 120, 0, 0, "Химическая формула:");

                MyTextBox New_Chemical_Formula = new MyTextBox("New_Chemical_Formula", 100, 483, 121, 0, 0);

                MyLabel New_Chemical_Formula_Help = new MyLabel("New_Chemical_Formula_Help", 332, 145, 0, 0, "Пример: 'CH3COCH3'; 'NH3', 'HNO3'", 10);

                MyLabel New_Molar_Mass_lbl = new MyLabel("New_Molar_Mass_lbl",640, 120, 0, 0,"Молярная масса:");

                MyTextBox New_Molar_Mass = new MyTextBox("New_Molar_Mass", 100, 760, 121, 0, 0);

                MyLabel New_Molar_Mass_Help = new MyLabel("New_Molar_Mass_Help", 640, 145, 0, 0, "Пример: '63.01'; '17.03'", 10);

                MyLabel Table_Data_lbl = new MyLabel("Table_Data_lbl", 397, 178, 0, 0,"Зависимости", 14);

                MyLabel New_Temp_Viscosity_lbl = new MyLabel("New_Temp_Viscosity_lbl",58, 210, 0, 0,"Вязкость от температуры");

                MyLabel New_Temp_Density_lbl = new MyLabel("New_Temp_Density_lbl",360, 210, 0, 0,"Плотность от температуры");

                MyLabel New_Pressure_BoilingPoint_lbl = new MyLabel("New_Pressure_BoilingPoint_lbl", 667, 210, 0, 0, "Точка кипения от давления");
                
                MyLabel First_Temperature_lbl = new MyLabel("First_Temperature_lbl",35, 240, 0, 0,"Температура");

                MyTextBox First_Temperature = new MyTextBox("First_Temperature_1", 100, 30, 260, 0, 0);

                MyLabel First_Viscosity_lbl = new MyLabel("First_Viscosity_lbl", 163, 240, 0, 0, "Вязкость");

                MyTextBox First_Viscosity = new MyTextBox("First_Viscosity_1", 100, 145, 260, 0, 0);

                MyLabel Second_Temperature_lbl = new MyLabel("Second_Temperature_lbl",343, 240, 0, 0,"Температура");

                MyTextBox Second_Temperature = new MyTextBox("Second_Temperature_1", 100, 337, 260, 0, 0);

                MyLabel Second_Density_lbl = new MyLabel("Second_Density_lbl",465, 240, 0, 0,"Плотность");

                MyTextBox Second_Density = new MyTextBox("Second_Density_1", 100, 452, 260, 0, 0);

                MyLabel Third_Pressure_lbl = new MyLabel("Third_Pressure_lbl", 660, 240, 0, 0,"Давление");

                MyTextBox Third_Pressure = new MyTextBox("Third_Pressure_1", 100, 645, 260, 0, 0);

                MyLabel Third_Temperature_lbl = new MyLabel("Third_Temperature_lbl",758, 240, 0, 0,"Точка кипения");

                MyTextBox Third_Temperature = new MyTextBox("Third_Temperature_1", 100, 760, 260, 0, 0);

                MyButton Add_Temp_Viscosity = new MyButton("Add_Temp_Viscosity", 120, 77, 285, 0, 0, "Добавить точку");
                Add_Temp_Viscosity.Click += Add_Temp_Viscosity_Click;

                MyButton Add_Temp_Density = new MyButton("Add_Temp_Density", 120, 385, 285, 0, 0, "Добавить точку");
                Add_Temp_Density.Click += Add_Temp_Density_Click;

                MyButton Add_Pressure_BoilingPoint = new MyButton("Add_Pressure_BoilingPoint", 120, 695, 285, 0, 0, "Добавить точку");
                Add_Pressure_BoilingPoint.Click += Add_Pressure_BoilingPointy_Click;


                Image Add_Liquid_Img_Top = new Image()
                {
                    Width = 900,
                    Height = 90,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Name = "Add_Liquid_Img_Top",
                    Margin = new Thickness(0, 0, 0, 0)
                };

                BitmapImage Add_Liquid_Img_Top_bi = new BitmapImage();
                Add_Liquid_Img_Top_bi.BeginInit();
                Add_Liquid_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Add_New_Liquid.jpg");
                Add_Liquid_Img_Top_bi.EndInit();
                Add_Liquid_Img_Top.Source = Add_Liquid_Img_Top_bi;



                Image Add_Liquid_Img_Bottom = new Image()
                {
                    Width = 900,
                    Height = 50,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Name = "Add_Liquid_Img_Bottom",
                    Margin = new Thickness(0, 366, 0, 0)
                };

                BitmapImage Add_Liquid_Img_Bottom_bi = new BitmapImage();
                Add_Liquid_Img_Bottom_bi.BeginInit();
                Add_Liquid_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Bottom_First.jpg");
                Add_Liquid_Img_Bottom_bi.EndInit();
                Add_Liquid_Img_Bottom.Source = Add_Liquid_Img_Bottom_bi;








                Grid_Add_Liquid.Children.Add(Add_Liquid_Img_Top);//0
                Grid_Add_Liquid.Children.Add(New_Liquid_Name);//1
                Grid_Add_Liquid.Children.Add(New_Liquid_Name_Help);//2
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_lbl);//3
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula);//4
                Grid_Add_Liquid.Children.Add(New_Chemical_Formula_Help);//5
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_lbl);//6
                Grid_Add_Liquid.Children.Add(New_Molar_Mass);//7
                Grid_Add_Liquid.Children.Add(New_Molar_Mass_Help);//8
                Grid_Add_Liquid.Children.Add(Add_Liquid_Img_Bottom);//9
                Grid_Add_Liquid.Children.Add(OK_Add_Liquid);//10
                //Grid_Add_Liquid.Children.Add(Cancel_Add_Liquid);//11
                Grid_Add_Liquid.Children.Add(Help_Add_Liquid);//11
                Grid_Add_Liquid.Children.Add(Table_Data_lbl);//12
                Grid_Add_Liquid.Children.Add(New_Temp_Viscosity_lbl);//13
                Grid_Add_Liquid.Children.Add(New_Temp_Density_lbl);//14
                Grid_Add_Liquid.Children.Add(New_Pressure_BoilingPoint_lbl);//15
                Grid_Add_Liquid.Children.Add(First_Temperature_lbl);//16
                Grid_Add_Liquid.Children.Add(First_Temperature);//17
                Grid_Add_Liquid.Children.Add(First_Viscosity_lbl);//18
                Grid_Add_Liquid.Children.Add(First_Viscosity);//19
                Grid_Add_Liquid.Children.Add(Second_Temperature_lbl);//20
                Grid_Add_Liquid.Children.Add(Second_Temperature);//21
                Grid_Add_Liquid.Children.Add(Second_Density_lbl);//22
                Grid_Add_Liquid.Children.Add(Second_Density);//23
                Grid_Add_Liquid.Children.Add(Third_Pressure_lbl);//24
                Grid_Add_Liquid.Children.Add(Third_Pressure);//25
                Grid_Add_Liquid.Children.Add(Third_Temperature_lbl);//26
                Grid_Add_Liquid.Children.Add(Third_Temperature);//27
                Grid_Add_Liquid.Children.Add(Add_Temp_Viscosity);//28
                Grid_Add_Liquid.Children.Add(Add_Temp_Density);//29
                Grid_Add_Liquid.Children.Add(Add_Pressure_BoilingPoint);//30
                Grid_Add_Liquid.Children.Add(New_Liquid_Name_lbl);//31

                Name = "Window_Add_Liquid";
                Content = Grid_Add_Liquid;
                Uri iconUri = new Uri("C://EasyPACT/EasyPACT_Graphic/EasyPACT_Icon.jpg", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
                this.MinWidth = 908;
                this.MaxWidth = 908;
                this.MinHeight = 450;
                this.MaxHeight = 450;
                Title = "Добавление новой жидкости - EasyPACT";
            }
            
            List<double> ListFirstTemp = new List<double>();
            List<double> ListFirstViscosity = new List<double>();
            int a = 285;
            int d = 285;
            private void Add_Temp_Viscosity_Click(object sender, RoutedEventArgs e)
            {
                a += 25;
                var Grid_Add_Liquid = this.Content as MyGrid;
                var Add_Temp_Viscosity = Grid_Add_Liquid.Children[28] as MyButton;
                Add_Temp_Viscosity.Margin = new Thickness(77, a, 0, 0);
                a -= 25;
                MyTextBox First_Temperature = new MyTextBox("First_Temperature_" + ((a + 25 - d) / 25 + 1).ToString(), 100, 30, a, 0, 0);
                Grid_Add_Liquid.Children.Add(First_Temperature);
                MyTextBox First_Viscosity = new MyTextBox("First_Viscosity_" + ((a + 25 - d) / 25 + 1).ToString(), 100, 145, a, 0, 0);
                Grid_Add_Liquid.Children.Add(First_Viscosity);
                a += 25;
                ListFirstTemp.Add(0);
                ListFirstViscosity.Add(0);
            }
            
            List<double> ListSecondTemp = new List<double>();
            List<double> ListSecondDensity = new List<double>();
            int b = 285;
            private void Add_Temp_Density_Click(object sender, RoutedEventArgs e)
            {
                b += 25;
                var Grid_Add_Liquid = this.Content as MyGrid;
                var Add_Temp_Density = Grid_Add_Liquid.Children[29] as MyButton;
                Add_Temp_Density.Margin = new Thickness(385, b, 0, 0);
                b -= 25;
                MyTextBox Second_Temperature = new MyTextBox("Second_Temperature_" + ((b + 25 - d) / 25 + 1).ToString(), 100, 337, b, 0, 0);
                Grid_Add_Liquid.Children.Add(Second_Temperature);
                MyTextBox Second_Density = new MyTextBox("Second_Density_" + ((b + 25 - d) / 25 + 1).ToString(), 100, 452, b, 0, 0);
                Grid_Add_Liquid.Children.Add(Second_Density);
                b += 25;
                ListSecondTemp.Add(0);
                ListSecondDensity.Add(0);
            }

            List<double> ListThirdPressure = new List<double>();
            List<double> ListThirdTemp = new List<double>();
            int c = 285;
            private void Add_Pressure_BoilingPointy_Click(object sender, RoutedEventArgs e)
            {
                c += 25;
                var Grid_Add_Liquid = this.Content as MyGrid;
                var Add_Temp_Density = Grid_Add_Liquid.Children[30] as MyButton;
                Add_Temp_Density.Margin = new Thickness(695, c, 0, 0);
                c -= 25;
                MyTextBox Third_Pressure = new MyTextBox("Third_Pressure_" + ((c + 25 - d) / 25 + 1).ToString(), 100, 645, c, 0, 0);
                Grid_Add_Liquid.Children.Add(Third_Pressure);
                MyTextBox Third_Temperature = new MyTextBox("Third_Temperature_" + ((c + 25 - d) / 25 + 1).ToString(), 100, 760, c, 0, 0);
                Grid_Add_Liquid.Children.Add(Third_Temperature);
                c += 25;
                ListThirdPressure.Add(0);
                ListThirdTemp.Add(0);
            }

            string LiquidName = "";
            string LiquidChemicalFormula = "";
            double MolarMass = 0;
            private void OK_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                bool g = true;
                double result = 0;
                var Grid_Add_Liquid = this.Content as MyGrid;
                var New_Liquid_Name = Grid_Add_Liquid.Children[1] as MyTextBox;
                var New_Chemical_Formula = Grid_Add_Liquid.Children[4] as MyTextBox;
                var New_Molar_Mass = Grid_Add_Liquid.Children[7] as MyTextBox;

                LiquidName = New_Liquid_Name.Text;
                LiquidChemicalFormula = New_Chemical_Formula.Text;
                if (double.TryParse(New_Molar_Mass.Text, out result) == false)
                    g = false;

                if (g == true)
                {
                    MolarMass = double.Parse(New_Molar_Mass.Text);
                }

                ListFirstTemp.Add(0);
                ListFirstViscosity.Add(0);
                ListSecondTemp.Add(0);
                ListSecondDensity.Add(0);
                ListThirdPressure.Add(0);
                ListThirdTemp.Add(0);
                //1
                for (int i = 0; i < ListFirstTemp.Count; i++)
                {
                    var New_First_Temp_Add = Grid_Add_Liquid.GetElementByName("First_Temperature_" + (i + 1).ToString()) as MyTextBox;
                    var New_First_Viscosity_Add = Grid_Add_Liquid.GetElementByName("First_Viscosity_" + (i + 1).ToString()) as MyTextBox;
                    
                    if ((double.TryParse(New_First_Temp_Add.Text, out result) == false) ||
                        (double.TryParse(New_First_Viscosity_Add.Text, out result) == false))
                        g = false;

                    if (g == true)
                    {
                        ListFirstTemp[i] = double.Parse(New_First_Temp_Add.Text);
                        ListFirstViscosity[i] = double.Parse(New_First_Viscosity_Add.Text);
                    }
                }
                //2
                for (int i = 0; i < ListSecondTemp.Count; i++)
                {
                    var New_Second_Temp_Add = Grid_Add_Liquid.GetElementByName("Second_Temperature_" + (i + 1).ToString()) as MyTextBox;
                    var New_Second_Density_Add = Grid_Add_Liquid.GetElementByName("Second_Density_" + (i + 1).ToString()) as MyTextBox;

                    if ((double.TryParse(New_Second_Temp_Add.Text, out result) == false) ||
                        (double.TryParse(New_Second_Density_Add.Text, out result) == false))
                        g = false;

                    if (g == true)
                    {
                        ListSecondTemp[i] = double.Parse(New_Second_Temp_Add.Text);
                        ListSecondDensity[i] = double.Parse(New_Second_Density_Add.Text);
                    }
                }
                //3
                for (int i = 0; i < ListThirdTemp.Count; i++)
                {
                    var New_Third_Pressure_Add = Grid_Add_Liquid.GetElementByName("Third_Pressure_" + (i + 1).ToString()) as MyTextBox;
                    var New_Third_Temp_Add = Grid_Add_Liquid.GetElementByName("Third_Temperature_" + (i + 1).ToString()) as MyTextBox;

                    if ((double.TryParse(New_Third_Pressure_Add.Text, out result) == false) ||
                        (double.TryParse(New_Third_Temp_Add.Text, out result) == false))
                        g = false;

                    if (g == true)
                    {
                        ListThirdPressure[i] = double.Parse(New_Third_Pressure_Add.Text);
                        ListThirdTemp[i] = double.Parse(New_Third_Temp_Add.Text);
                    }
                }

                if (g == true)
                {
                    MessageBox.Show("Все отлично!");

                    MessageBox.Show("Название вещества: " + LiquidName);
                    MessageBox.Show("Формула вещества: " + LiquidChemicalFormula);
                    MessageBox.Show("Молярная масса: " + MolarMass.ToString());


                    string firstTempTry = "Значения первой температуры: ";
                    for (int i = 0; i < ListFirstTemp.Count; i++)
                    {
                        firstTempTry += ListFirstTemp[i].ToString() + "";
                    }
                    MessageBox.Show(firstTempTry);

                    string firstViscosityTry = "Значения первой вязкости: ";
                    for (int i = 0; i < ListFirstViscosity.Count; i++)
                    {
                        firstViscosityTry += ListFirstViscosity[i].ToString() + "";
                    }
                    MessageBox.Show(firstViscosityTry);

                    string secondTempTry = "Значения второй температуры: ";
                    for (int i = 0; i < ListSecondTemp.Count; i++)
                    {
                        secondTempTry += ListSecondTemp[i].ToString() + "";
                    }
                    MessageBox.Show(secondTempTry);

                    string secondDensityTry = "Значения второй плотности: ";
                    for (int i = 0; i < ListSecondDensity.Count; i++)
                    {
                        secondDensityTry += ListSecondDensity[i].ToString() + "";
                    }
                    MessageBox.Show(secondDensityTry);

                    string thirdPressureTry = "Значения третьего давления: ";
                    for (int i = 0; i < ListThirdPressure.Count; i++)
                    {
                        thirdPressureTry += ListThirdPressure[i].ToString() + "";
                    }
                    MessageBox.Show(thirdPressureTry);

                    string thirdTempTry = "Значения третьей температуры: ";
                    for (int i = 0; i < ListThirdTemp.Count; i++)
                    {
                        thirdTempTry += ListThirdTemp[i].ToString() + "";
                    }
                    MessageBox.Show(thirdTempTry);

                }
                else
                {
                    MessageBox.Show("Одно или несколько значений введены неверно.");
                    ListFirstTemp.RemoveAt(ListFirstTemp.Count - 1);
                    ListFirstViscosity.RemoveAt(ListFirstViscosity.Count - 1);
                    ListSecondTemp.RemoveAt(ListSecondTemp.Count - 1);
                    ListSecondDensity.RemoveAt(ListSecondDensity.Count - 1);
                    ListThirdPressure.RemoveAt(ListThirdPressure.Count - 1);
                    ListThirdTemp.RemoveAt(ListThirdTemp.Count - 1);
                }

            }

            private void Help_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                HelpWindow hw1 = new HelpWindow();
                hw1.Show();
            }

            private void Cancel_Add_Liquid_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Окно будет закрыто.");
                Close();
            }
        }
    }