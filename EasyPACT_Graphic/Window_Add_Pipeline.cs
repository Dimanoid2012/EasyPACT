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
    public class Window_Add_Pipeline : Window
    {
        public Window_Add_Pipeline()
        {
            Grid Grid_Add_Pipeline = new MyGrid();
            Grid_Add_Pipeline.Name = "Grid_Add_Pipeline";

            MyButton Next_2 = new MyButton("Next_2", 100, 0, 0, 30, 30, "Добавить");
            Next_2.Height = 30;
            Next_2.HorizontalAlignment = HorizontalAlignment.Right;
            Next_2.VerticalAlignment = VerticalAlignment.Bottom;
            Next_2.Click += Next_2_Click;

            MyButton Help_Add_Pipeline = new MyButton("Help_Add_Liquid", 100, 30, 0, 0, 30, "Помощь");
            Help_Add_Pipeline.Height = 30;
            Help_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //Help_Add_Liquid.Click += Help_Add_Liquid_Click;

            MyButton Cancel_Add_Pipeline = new MyButton("Cancel_Add_Pipeline", 100, 0, 0, 140, 30, "Отменить");
            Cancel_Add_Pipeline.Height = 30;
            Cancel_Add_Pipeline.HorizontalAlignment = HorizontalAlignment.Right;
            Cancel_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;

            //MyLabel Add_New_Pipeline_lbl = new MyLabel("Add_New_Pipeline_lbl", 30, 110, 0, 0, "Всасывающий трубопровод.", 14);

            MyLabel Pipeline_Type_lbl = new MyLabel("Pipeline_Type_lbl_1", 30, 110, 0, 0, "Тип трубопровода:");

            MyComboBox Pipeline_Type = new MyComboBox("Pipeline_Type_1", 460, 163, 112, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Type.Items.Add(a);
            }
            Pipeline_Type.SelectedIndex = 0;

            MyLabel Material_In_lbl = new MyLabel("Material_In_lbl_1", 633, 110, 0, 0, "Материал:");

            MyComboBox Material_In = new MyComboBox("Material_In_1", 150, 713, 112, 0, 0);
            foreach (var a in Database.Query("select name from XXVIII")[0])
            {
                Material_In.Items.Add(a);
            }
            Material_In.SelectedIndex = 0;

            MyLabel Length_In_lbl = new MyLabel("Length_In_lbl_1", 30, 140, 0, 0, "Длина:");

            MyTextBox Length_In = new MyTextBox("Length_In_1", 60, 88, 142, 0, 0);

            MyComboBox Length_In_Measure_Choose = new MyComboBox("Length_In_Measure_Choose_1", 120, 153, 142, 0, 0);
            Length_In_Measure_Choose.SelectedIndex = 0;
            Length_In_Measure_Choose.Items.Add("мм");
            Length_In_Measure_Choose.Items.Add("м");
            Length_In_Measure_Choose.Items.Add("дм");
            Length_In_Measure_Choose.Items.Add("км");
            Length_In_Measure_Choose.Items.Add("мили");
            Length_In_Measure_Choose.Items.Add("дюймы");
            Length_In_Measure_Choose.SelectedIndex = 0;
            //Length_In_Measure_Choose.SelectionChanged += Length_In_Measure_Choose_SelectionChanged;

            MyLabel Length_In_Help = new MyLabel("Length_In_Help", 82, 167, 0, 0, "Пример: '20'; '33.1'; '10.83'", 10);

            MyLabel Diameter_In_lbl = new MyLabel("Diameter_lbl_1", 283, 140, 0, 0, "Диаметр:");

            MyTextBox Diameter_In = new MyTextBox("Diameter_In_1", 60, 360, 142, 0, 0);

            MyComboBox Diameter_In_Measure_Choose = new MyComboBox("Diameter_In_Measure_Choose_1", 120, 425, 142, 0, 0);
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            Diameter_In_Measure_Choose.Items.Add("мм");
            Diameter_In_Measure_Choose.Items.Add("м");
            Diameter_In_Measure_Choose.Items.Add("дм");
            Diameter_In_Measure_Choose.Items.Add("км");
            Diameter_In_Measure_Choose.Items.Add("мили");
            Diameter_In_Measure_Choose.Items.Add("дюймы");
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            //Diameter_In_Measure_Choose.SelectionChanged += Diameter_In_Measure_Choose_SelectionChanged;

            MyLabel Diameter_In_Help = new MyLabel("Diameter_In_Help", 354, 167, 0, 0, "Пример: '12'; '23.1'; '65.34'", 10);

            MyLabel Wall_Width_In_lbl = new MyLabel("Wall_Width_In_lbl_1", 556, 140, 0, 0, "Толщина стенки:");

            MyTextBox Wall_Width_In = new MyTextBox("Wall_Width_In_1", 60, 678, 142, 0, 0);

            MyComboBox Wall_Width_In_Measure_Choose = new MyComboBox("Wall_Width_In_Measure_Choose_1", 120, 743, 142, 0, 0);
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            Wall_Width_In_Measure_Choose.Items.Add("мм");
            Wall_Width_In_Measure_Choose.Items.Add("м");
            Wall_Width_In_Measure_Choose.Items.Add("дм");
            Wall_Width_In_Measure_Choose.Items.Add("км");
            Wall_Width_In_Measure_Choose.Items.Add("мили");
            Wall_Width_In_Measure_Choose.Items.Add("дюймы");
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            //Wall_Width_In_Measure_Choose.SelectionChanged += Wall_Width_In_Measure_Choose_SelectionChanged;

            MyLabel Wall_Width_In_Help = new MyLabel("", 672, 167, 0, 0, "Пример: '2'; '3.4'; '12.15'", 10);

            

            MyButton Add_New_Pipe = new MyButton("Add_New_Pipe", 250, 30, 202, 0, 0, "Добавить новую трубу");
            Add_New_Pipe.Click += Add_New_Pipe_Click;


            /*
            MyLabel Local_Resistance_In_lbl = new MyLabel("Local_Resistance_In_lbl", 30, 200, 0, 0, "Местные сопротивления:");

            MyComboBox Local_Resistance_In = new MyComboBox("Local_Resistance_In", 124, 200, 202, 0, 0);
            Local_Resistance_In.Items.Add("Всякая фигня");
            Local_Resistance_In.SelectedIndex = 0;

            MyLabel Number_Local_Resistance_In_lbl = new MyLabel("Number_Local_Resistance_In_lbl", 334, 200, 0, 0, "Количество:");

            MyTextBox Number_Local_Resistance_In = new MyTextBox("Number_Local_Resistance_In", 60, 425, 202, 0, 0);

            MyLabel Shtyk = new MyLabel("Shtyk", 489, 200, 0, 0, "штук.");

            MyLabel Size = new MyLabel("Size_1", 556, 200, 0, 0, "Размеры");

            MyComboBox Size_Choose = new MyComboBox("", 100, 620, 202, 0, 0);

            */
            


            

            Grid_Add_Pipeline.Children.Add(Next_2);//0
            Grid_Add_Pipeline.Children.Add(Cancel_Add_Pipeline);//1
            Grid_Add_Pipeline.Children.Add(Help_Add_Pipeline);//2
            Grid_Add_Pipeline.Children.Add(Pipeline_Type_lbl);//3
            Grid_Add_Pipeline.Children.Add(Pipeline_Type);//4
            Grid_Add_Pipeline.Children.Add(Material_In_lbl);//5
            Grid_Add_Pipeline.Children.Add(Material_In);//6
            Grid_Add_Pipeline.Children.Add(Length_In_lbl);//7
            Grid_Add_Pipeline.Children.Add(Length_In);//8
            Grid_Add_Pipeline.Children.Add(Length_In_Measure_Choose);//9
            Grid_Add_Pipeline.Children.Add(Length_In_Help);//10
            Grid_Add_Pipeline.Children.Add(Diameter_In_lbl);//11
            Grid_Add_Pipeline.Children.Add(Diameter_In);//12
            Grid_Add_Pipeline.Children.Add(Diameter_In_Measure_Choose);//13
            Grid_Add_Pipeline.Children.Add(Diameter_In_Help);//14
            Grid_Add_Pipeline.Children.Add(Wall_Width_In_lbl);//15
            Grid_Add_Pipeline.Children.Add(Wall_Width_In);//16
            Grid_Add_Pipeline.Children.Add(Wall_Width_In_Measure_Choose);//17
            Grid_Add_Pipeline.Children.Add(Wall_Width_In_Help);//18
            Grid_Add_Pipeline.Children.Add(Add_New_Pipe);//19
            //Grid_Add_Pipeline.Children.Add(Add_New_Pipeline_lbl);//20



            /*
            Grid_Add_Pipeline.Children.Add(Local_Resistance_In_lbl);
            Grid_Add_Pipeline.Children.Add(Local_Resistance_In);
            Grid_Add_Pipeline.Children.Add(Number_Local_Resistance_In_lbl);
            Grid_Add_Pipeline.Children.Add(Number_Local_Resistance_In);
            Grid_Add_Pipeline.Children.Add(Shtyk);
            Grid_Add_Pipeline.Children.Add(Add_New_Local_Resistance);
            

            Grid_Add_Pipeline.Children.Add(Size);
            Grid_Add_Pipeline.Children.Add(Size_Choose);
            */

            Content = Grid_Add_Pipeline;
            Width = 900;
            Height = 500;
            Title = "Добавление нового трубопровода";
        }


        List<int> List_Pipeline_Type_In = new List<int>();
        List<int> List_Material_In = new List<int>();
        List<double> List_Length_In = new List<double>();
        List<double> List_Diameter_In = new List<double>();
        List<double> List_Wall_Width_In = new List<double>();

        int a_in = 200;
        int b_in = 200;
        private void Add_New_Pipe_Click(object sender, RoutedEventArgs e)
        {
            a_in += 100;
            var Grid_Add_Pipeline = this.Content as MyGrid;
            var Add_New_Pipe = Grid_Add_Pipeline.Children[19] as MyButton;
            Add_New_Pipe.Margin = new Thickness(30, a_in, 0, 0);
            a_in -= 100;

            MyLabel Razd = new MyLabel("Razd", 30, a_in, 0, 0, "--------------------------------------------------------------------------------------------------------------------------------------------------------");

            a_in += 30;

            MyLabel Pipeline_Type_lbl = new MyLabel("Pipeline_Type_lbl_" + ((a_in + 70 - b_in) / 100 + 1).ToString(), 30, a_in, 0, 0, "Тип трубопровода:");

            MyComboBox Pipeline_Type = new MyComboBox("Pipeline_Type_" + ((a_in + 70 - b_in) / 100 + 1).ToString(), 460, 163, a_in, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Type.Items.Add(a);
            }
            Pipeline_Type.SelectedIndex = 0;

            MyLabel Material_In_lbl = new MyLabel("Material_In_lbl_1", 633, a_in, 0, 0, "Материал:");

            MyComboBox Material_In = new MyComboBox("Material_In_" + ((a_in + 70 - b_in) / 100 + 1).ToString(), 150, 713, a_in, 0, 0);
            foreach (var a in Database.Query("select name from XXVIII")[0])
            {
                Material_In.Items.Add(a);
            }
            Material_In.SelectedIndex = 0;

            a_in += 30;

            MyLabel Length_In_lbl = new MyLabel("Length_In_lbl_1", 30, a_in, 0, 0, "Длина:");

            MyTextBox Length_In = new MyTextBox("Length_In_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 60, 88, a_in, 0, 0);

            MyComboBox Length_In_Measure_Choose = new MyComboBox("Length_In_Measure_Choose_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 120, 153, a_in, 0, 0);
            Length_In_Measure_Choose.SelectedIndex = 0;
            Length_In_Measure_Choose.Items.Add("мм");
            Length_In_Measure_Choose.Items.Add("м");
            Length_In_Measure_Choose.Items.Add("дм");
            Length_In_Measure_Choose.Items.Add("км");
            Length_In_Measure_Choose.Items.Add("мили");
            Length_In_Measure_Choose.Items.Add("дюймы");
            Length_In_Measure_Choose.SelectedIndex = 0;
            //Length_In_Measure_Choose.SelectionChanged += Length_In_Measure_Choose_SelectionChanged;

            MyLabel Diameter_In_lbl = new MyLabel("Diameter_lbl_1", 283, a_in, 0, 0, "Диаметр:");

            MyTextBox Diameter_In = new MyTextBox("Diameter_In_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 60, 360, a_in, 0, 0);

            MyComboBox Diameter_In_Measure_Choose = new MyComboBox("Diameter_In_Measure_Choose_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 120, 425, a_in, 0, 0);
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            Diameter_In_Measure_Choose.Items.Add("мм");
            Diameter_In_Measure_Choose.Items.Add("м");
            Diameter_In_Measure_Choose.Items.Add("дм");
            Diameter_In_Measure_Choose.Items.Add("км");
            Diameter_In_Measure_Choose.Items.Add("мили");
            Diameter_In_Measure_Choose.Items.Add("дюймы");
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            //Diameter_In_Measure_Choose.SelectionChanged += Diameter_In_Measure_Choose_SelectionChanged;

            MyLabel Wall_Width_In_lbl = new MyLabel("Wall_Width_In_lbl_1", 556, a_in, 0, 0, "Толщина стенки:");

            MyTextBox Wall_Width_In = new MyTextBox("Wall_Width_In_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 60, 678, a_in, 0, 0);

            MyComboBox Wall_Width_In_Measure_Choose = new MyComboBox("Wall_Width_In_Measure_Choose_" + ((a_in + 40 - b_in) / 100 + 1).ToString(), 120, 743, a_in, 0, 0);
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            Wall_Width_In_Measure_Choose.Items.Add("мм");
            Wall_Width_In_Measure_Choose.Items.Add("м");
            Wall_Width_In_Measure_Choose.Items.Add("дм");
            Wall_Width_In_Measure_Choose.Items.Add("км");
            Wall_Width_In_Measure_Choose.Items.Add("мили");
            Wall_Width_In_Measure_Choose.Items.Add("дюймы");
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            //Wall_Width_In_Measure_Choose.SelectionChanged += Wall_Width_In_Measure_Choose_SelectionChanged;

            Grid_Add_Pipeline.Children.Add(Razd);//4
            Grid_Add_Pipeline.Children.Add(Pipeline_Type_lbl);//4
            Grid_Add_Pipeline.Children.Add(Pipeline_Type);//5
            Grid_Add_Pipeline.Children.Add(Length_In_lbl);//6
            Grid_Add_Pipeline.Children.Add(Length_In);//7
            Grid_Add_Pipeline.Children.Add(Length_In_Measure_Choose);//8
            Grid_Add_Pipeline.Children.Add(Material_In_lbl);//9
            Grid_Add_Pipeline.Children.Add(Material_In);//10
            Grid_Add_Pipeline.Children.Add(Diameter_In_lbl);//11
            Grid_Add_Pipeline.Children.Add(Diameter_In);//12
            Grid_Add_Pipeline.Children.Add(Diameter_In_Measure_Choose);//13
            Grid_Add_Pipeline.Children.Add(Wall_Width_In_lbl);//14
            Grid_Add_Pipeline.Children.Add(Wall_Width_In);//15
            Grid_Add_Pipeline.Children.Add(Wall_Width_In_Measure_Choose);//16

            a_in += 40;

            List_Pipeline_Type_In.Add(0);
            List_Material_In.Add(0);
            List_Length_In.Add(0);
            List_Diameter_In.Add(0);
            List_Wall_Width_In.Add(0);

        }

        private void Next_2_Click(object sender, RoutedEventArgs e)
        {
            bool g = true;
            double result = 0;
            var Grid_Add_Pipeline = this.Content as MyGrid;

            List_Pipeline_Type_In.Add(0);
            List_Material_In.Add(0);
            List_Length_In.Add(0);
            List_Diameter_In.Add(0);
            List_Wall_Width_In.Add(0);

            for (int i = 0; i < List_Pipeline_Type_In.Count; i++)
            {
                var New_Pipeline_Type_In = Grid_Add_Pipeline.GetElementByName("Pipeline_Type_" + (i + 1).ToString()) as MyComboBox;
                var New_Material_In = Grid_Add_Pipeline.GetElementByName("Material_In_" + (i + 1).ToString()) as MyComboBox;
                var New_Length_In = Grid_Add_Pipeline.GetElementByName("Length_In_" + (i + 1).ToString()) as MyTextBox;
                var New_Diameter_In = Grid_Add_Pipeline.GetElementByName("Diameter_In_" + (i + 1).ToString()) as MyTextBox;
                var New_Wall_Width_In = Grid_Add_Pipeline.GetElementByName("Wall_Width_In_" + (i + 1).ToString()) as MyTextBox;

                List_Pipeline_Type_In[i] = New_Pipeline_Type_In.SelectedIndex;
                List_Material_In[i] = New_Material_In.SelectedIndex;

                if ((double.TryParse(New_Length_In.Text, out result) == false) || 
                    (double.TryParse(New_Diameter_In.Text, out result) == false) ||
                    (double.TryParse(New_Wall_Width_In.Text, out result) == false))
                    g = false;

                if (g == true)
                {
                    List_Length_In[i] = double.Parse(New_Length_In.Text);
                    List_Diameter_In[i] = double.Parse(New_Diameter_In.Text);
                    List_Wall_Width_In[i] = double.Parse(New_Wall_Width_In.Text);
                }
            }

            if (g == true)
            {
                MessageBox.Show("Все отлично!");
                
                string first = "";
                for (int i = 0; i < List_Pipeline_Type_In.Count; i++)
                {
                    first += List_Pipeline_Type_In[i].ToString() + "";
                }
                MessageBox.Show("Выбранные типы: " + first);

                string second = "";
                for (int i = 0; i < List_Material_In.Count; i++)
                {
                    second += List_Material_In[i].ToString() + "";
                }
                MessageBox.Show("Выбранные материалы: " + second);

                string third = "";
                for (int i = 0; i < List_Length_In.Count; i++)
                {
                    third += List_Length_In[i].ToString() + "";
                }
                MessageBox.Show("Введенные длины: " + third);

                string forth = "";
                for (int i = 0; i < List_Diameter_In.Count; i++)
                {
                    forth += List_Diameter_In[i].ToString() + "";
                }
                MessageBox.Show("Введенные диаметры: " + forth);

                string fifth = "";
                for (int i = 0; i < List_Wall_Width_In.Count; i++)
                {
                    fifth += List_Wall_Width_In[i].ToString() + "";
                }
                MessageBox.Show("Введенные толщины стенок: " + fifth);
            }
            else
            {
                MessageBox.Show("Одно или несколько значений введены неверно.");
                List_Pipeline_Type_In.RemoveAt(List_Pipeline_Type_In.Count - 1);
                List_Material_In.RemoveAt(List_Material_In.Count - 1);
                List_Length_In.RemoveAt(List_Length_In.Count - 1);
                List_Diameter_In.RemoveAt(List_Diameter_In.Count - 1);
                List_Wall_Width_In.RemoveAt(List_Wall_Width_In.Count - 1);
            }

            

            MessageBox.Show(List_Diameter_In.Count.ToString());
        }


    }
}