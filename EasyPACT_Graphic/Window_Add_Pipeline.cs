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
    public class Window_Add_Pipeline : Window
    {
        EasyPACT.Liquid liq;
        double Temperature_Out;
        double NK_dou;
        double VP;

        public Window_Add_Pipeline(EasyPACT.Liquid liq, double Temperature_Out, double NK_dou, double VP)
        {
            Grid Grid_Add_Pipeline = new MyGrid();
            Grid_Add_Pipeline.Name = "Grid_Add_Pipeline";

            this.liq = liq;
            this.Temperature_Out = Temperature_Out;
            this.NK_dou = NK_dou;
            this.VP = VP;

            MyButton Next_2 = new MyButton("Next_2", 150, 0, 0, 20, 7, "Продолжить");
            Next_2.Height = 30;
            Next_2.FontSize = 12;
            Next_2.Foreground = Brushes.LightGray;
            Next_2.HorizontalAlignment = HorizontalAlignment.Right;
            Next_2.VerticalAlignment = VerticalAlignment.Bottom;
            Next_2.Background = Brushes.DarkGreen;
            Next_2.Click += Next_2_Click;

            MyButton Help_Add_Pipeline = new MyButton("Help_Add_Liquid", 70, 18, 0, 0, 7, "Справка");
            Help_Add_Pipeline.Height = 30;
            Help_Add_Pipeline.Foreground = Brushes.LightGray;
            Help_Add_Pipeline.FontSize = 12;
            Help_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            Help_Add_Pipeline.Background = Brushes.DarkGreen;
            Help_Add_Pipeline.Click += Help_Add_Pipeline_Click;
            /*
            MyButton Cancel_Add_Pipeline = new MyButton("Cancel_Add_Pipeline", 100, 0, 0, 140, 30, "Отменить");
            Cancel_Add_Pipeline.Height = 30;
            Cancel_Add_Pipeline.HorizontalAlignment = HorizontalAlignment.Right;
            Cancel_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;
            */
            //MyLabel Add_New_Pipeline_lbl = new MyLabel("Add_New_Pipeline_lbl", 30, 110, 0, 0, "Всасывающий трубопровод.", 14);

            MyLabel Pipeline_In_lbl = new MyLabel("Pipeline_In_lbl", 30, 100, 0, 0, "Всасывающий трубопровод", 16);
            Pipeline_In_lbl.FontWeight = FontWeights.Bold;

            MyLabel Pipeline_Type_lbl = new MyLabel("Pipeline_Type_lbl_1", 30, 140, 0, 0, "Тип трубопровода:");

            MyComboBox Pipeline_Type = new MyComboBox("Pipeline_Type_1", 460, 163, 142, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Type.Items.Add(a);
            }
            Pipeline_Type.SelectedIndex = 0;

            MyLabel Material_In_lbl = new MyLabel("Material_In_lbl_1", 633, 140, 0, 0, "Материал:");

            MyComboBox Material_In = new MyComboBox("Material_In_1", 150, 713, 142, 0, 0);
            foreach (var a in Database.Query("select name from XXVIII")[0])
            {
                Material_In.Items.Add(a);
            }
            Material_In.SelectedIndex = 0;

            MyLabel Length_In_lbl = new MyLabel("Length_In_lbl_1", 30, 170, 0, 0, "Длина:");

            MyTextBox Length_In = new MyTextBox("Length_In_1", 60, 88, 172, 0, 0);

            MyComboBox Length_In_Measure_Choose = new MyComboBox("Length_In_Measure_Choose_1", 120, 153, 172, 0, 0);
            Length_In_Measure_Choose.SelectedIndex = 0;
            Length_In_Measure_Choose.Items.Add("м");
            Length_In_Measure_Choose.Items.Add("см");
            Length_In_Measure_Choose.Items.Add("мм");
            Length_In_Measure_Choose.SelectedIndex = 0;
            //Length_In_Measure_Choose.SelectionChanged += Length_In_Measure_Choose_SelectionChanged;

            MyLabel Length_In_Help = new MyLabel("Length_In_Help", 82, 197, 0, 0, "Пример: '20'; '33.1'; '10.83'", 10);

            MyLabel Diameter_In_lbl = new MyLabel("Diameter_lbl_1", 283, 170, 0, 0, "Диаметр:");

            MyTextBox Diameter_In = new MyTextBox("Diameter_In_1", 60, 360, 172, 0, 0);

            MyComboBox Diameter_In_Measure_Choose = new MyComboBox("Diameter_In_Measure_Choose_1", 120, 425, 172, 0, 0);
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            Diameter_In_Measure_Choose.Items.Add("м");
            Diameter_In_Measure_Choose.Items.Add("см");
            Diameter_In_Measure_Choose.Items.Add("мм");
            Diameter_In_Measure_Choose.SelectedIndex = 0;
            //Diameter_In_Measure_Choose.SelectionChanged += Diameter_In_Measure_Choose_SelectionChanged;

            MyLabel Diameter_In_Help = new MyLabel("Diameter_In_Help", 354, 197, 0, 0, "Пример: '12'; '23.1'; '65.34'", 10);

            MyLabel Wall_Width_In_lbl = new MyLabel("Wall_Width_In_lbl_1", 556, 170, 0, 0, "Толщина стенки:");

            MyTextBox Wall_Width_In = new MyTextBox("Wall_Width_In_1", 60, 678, 172, 0, 0);

            MyComboBox Wall_Width_In_Measure_Choose = new MyComboBox("Wall_Width_In_Measure_Choose_1", 120, 743, 172, 0, 0);
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            Wall_Width_In_Measure_Choose.Items.Add("м");
            Wall_Width_In_Measure_Choose.Items.Add("см");
            Wall_Width_In_Measure_Choose.Items.Add("мм");
            Wall_Width_In_Measure_Choose.SelectedIndex = 0;
            //Wall_Width_In_Measure_Choose.SelectionChanged += Wall_Width_In_Measure_Choose_SelectionChanged;

            MyLabel Wall_Width_In_Help = new MyLabel("", 672, 197, 0, 0, "Пример: '2'; '3.4'; '12.15'", 10);



            // Нагнетающий

            MyLabel Pipeline_Out_lbl = new MyLabel("Pipeline_Out_lbl", 30, 230, 0, 0, "Нагнетательный трубопровод", 16);
            Pipeline_Out_lbl.FontWeight = FontWeights.Bold;

            MyLabel Pipeline_Out_Type_lbl = new MyLabel("Pipeline_Out_Type_lbl_1", 30, 270, 0, 0, "Тип трубопровода:");

            MyComboBox Pipeline_Out_Type = new MyComboBox("Pipeline_Out_Type_1", 460, 163, 272, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Out_Type.Items.Add(a);
            }
            Pipeline_Out_Type.SelectedIndex = 0;

            MyLabel Material_Out_lbl = new MyLabel("Material_Out_lbl_1", 633, 270, 0, 0, "Материал:");

            MyComboBox Material_Out = new MyComboBox("Material_Out_1", 150, 713, 272, 0, 0);
            foreach (var a in Database.Query("select name from XXVIII")[0])
            {
                Material_Out.Items.Add(a);
            }
            Material_Out.SelectedIndex = 0;

            MyLabel Length_Out_lbl = new MyLabel("Length_In_lbl_1", 30, 300, 0, 0, "Длина:");

            MyTextBox Length_Out = new MyTextBox("Length_Out_1", 60, 88, 302, 0, 0);

            MyComboBox Length_Out_Measure_Choose = new MyComboBox("Length_Out_Measure_Choose_1", 120, 153, 302, 0, 0);
            Length_Out_Measure_Choose.SelectedIndex = 0;
            Length_Out_Measure_Choose.Items.Add("м");
            Length_Out_Measure_Choose.Items.Add("см");
            Length_Out_Measure_Choose.Items.Add("мм");
            Length_Out_Measure_Choose.SelectedIndex = 0;
            //Length_In_Measure_Choose.SelectionChanged += Length_In_Measure_Choose_SelectionChanged;

            MyLabel Length_Out_Help = new MyLabel("Length_Out_Help", 82, 327, 0, 0, "Пример: '20'; '33.1'; '10.83'", 10);

            MyLabel Diameter_Out_lbl = new MyLabel("Diameter_Out_lbl_1", 283, 300, 0, 0, "Диаметр:");

            MyTextBox Diameter_Out = new MyTextBox("Diameter_Out_1", 60, 360, 302, 0, 0);

            MyComboBox Diameter_Out_Measure_Choose = new MyComboBox("Diameter_Out_Measure_Choose_1", 120, 425, 302, 0, 0);
            Diameter_Out_Measure_Choose.SelectedIndex = 0;
            Diameter_Out_Measure_Choose.Items.Add("м");
            Diameter_Out_Measure_Choose.Items.Add("см");
            Diameter_Out_Measure_Choose.Items.Add("мм");
            Diameter_Out_Measure_Choose.SelectedIndex = 0;
            //Diameter_Out_Measure_Choose.SelectionChanged += Diameter_Out_Measure_Choose_SelectionChanged;

            MyLabel Diameter_Out_Help = new MyLabel("Diameter_Out_Help", 354, 327, 0, 0, "Пример: '12'; '23.1'; '65.34'", 10);

            MyLabel Wall_Width_Out_lbl = new MyLabel("Wall_Width_Out_lbl_1", 556, 300, 0, 0, "Толщина стенки:");

            MyTextBox Wall_Width_Out = new MyTextBox("Wall_Width_Out_1", 60, 678, 302, 0, 0);

            MyComboBox Wall_Width_Out_Measure_Choose = new MyComboBox("Wall_Width_Out_Measure_Choose_1", 120, 743, 302, 0, 0);
            Wall_Width_Out_Measure_Choose.SelectedIndex = 0;
            Wall_Width_Out_Measure_Choose.Items.Add("м");
            Wall_Width_Out_Measure_Choose.Items.Add("cм");
            Wall_Width_Out_Measure_Choose.Items.Add("мм");
            Wall_Width_Out_Measure_Choose.SelectedIndex = 0;
            //Wall_Width_Out_Measure_Choose.SelectionChanged += Wall_Width_Out_Measure_Choose_SelectionChanged;

            MyLabel Wall_Width_Out_Help = new MyLabel("", 672, 327, 0, 0, "Пример: '2'; '3.4'; '12.15'", 10);
            /*
            MyLabel Pipeline_Out_Type_lbl = new MyLabel("Pipeline_Out_Type_lbl_1", 30, 110, 0, 0, "Тип трубопровода:");

            MyComboBox Pipeline_Out_Type = new MyComboBox("Pipeline_Out_Type_1", 460, 163, 112, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Type.Items.Add(a);
            }
            Pipeline_Type.SelectedIndex = 0;
            */



            
            /*
            MyButton Add_New_Pipe = new MyButton("Add_New_Pipe", 250, 30, 202, 0, 0, "Добавить новую трубу");
            Add_New_Pipe.Click += Add_New_Pipe_Click;
            */
            Image Add_Pipeline_Img_Top = new Image()
            {
                Width = 900,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Add_Pipeline_Img_Top",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Add_Pipeline_Img_Top_bi = new BitmapImage();
            Add_Pipeline_Img_Top_bi.BeginInit();
            Add_Pipeline_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Pipe_Params.jpg");
            Add_Pipeline_Img_Top_bi.EndInit();
            Add_Pipeline_Img_Top.Source = Add_Pipeline_Img_Top_bi;



            Image Add_Pipeline_Img_Bottom = new Image()
            {
                Width = 900,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Add_Pipeline_Img_Bottom",
                Margin = new Thickness(0, 366, 0, 0)
            };

            BitmapImage Add_Pipeline_Img_Bottom_bi = new BitmapImage();
            Add_Pipeline_Img_Bottom_bi.BeginInit();
            Add_Pipeline_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Bottom_First.jpg");
            Add_Pipeline_Img_Bottom_bi.EndInit();
            Add_Pipeline_Img_Bottom.Source = Add_Pipeline_Img_Bottom_bi;

            /*
            var scrbr = new ScrollBar();
            scrbr.Orientation = Orientation.Vertical;
            scrbr.HorizontalAlignment = HorizontalAlignment.Right;
            scrbr.Width = 20;
            scrbr.Height = 100;
            scrbr.Scroll += scrbr_Scroll;
            */

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




            Grid_Add_Pipeline.Children.Add(Add_Pipeline_Img_Top);//0
            Grid_Add_Pipeline.Children.Add(Add_Pipeline_Img_Bottom);//1
            Grid_Add_Pipeline.Children.Add(Next_2);//2
            Grid_Add_Pipeline.Children.Add(Help_Add_Pipeline);//3
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
            Grid_Add_Pipeline.Children.Add(Pipeline_Type_lbl);//19

            // Нагнетающий
            Grid_Add_Pipeline.Children.Add(Pipeline_Out_Type_lbl);//20
            Grid_Add_Pipeline.Children.Add(Pipeline_Out_Type);//21
            Grid_Add_Pipeline.Children.Add(Material_Out_lbl);//22
            Grid_Add_Pipeline.Children.Add(Material_Out);//23
            Grid_Add_Pipeline.Children.Add(Length_Out_lbl);//24
            Grid_Add_Pipeline.Children.Add(Length_Out);//25
            Grid_Add_Pipeline.Children.Add(Length_Out_Measure_Choose);//26
            Grid_Add_Pipeline.Children.Add(Length_Out_Help);//27
            Grid_Add_Pipeline.Children.Add(Diameter_Out_lbl);//28
            Grid_Add_Pipeline.Children.Add(Diameter_Out);//29
            Grid_Add_Pipeline.Children.Add(Diameter_Out_Measure_Choose);//30
            Grid_Add_Pipeline.Children.Add(Diameter_Out_Help);//31
            Grid_Add_Pipeline.Children.Add(Wall_Width_Out_lbl);//32
            Grid_Add_Pipeline.Children.Add(Wall_Width_Out);//33
            Grid_Add_Pipeline.Children.Add(Wall_Width_Out_Measure_Choose);//34
            Grid_Add_Pipeline.Children.Add(Wall_Width_Out_Help);//35

            Grid_Add_Pipeline.Children.Add(Pipeline_In_lbl);//36
            Grid_Add_Pipeline.Children.Add(Pipeline_Out_lbl);//37

            Content = Grid_Add_Pipeline;
            this.Width = 908;
            this.Height = 450;
            this.MinWidth = 908;
            this.MaxWidth = 908;
            this.MinHeight = 450;
            this.MaxHeight = 450;
            Title = "Добавление нового трубопровода";
        }

        private void Next_2_Click(object sender, RoutedEventArgs e)
        {
            bool g = true;
            double result = 0;
            var Grid_Add_Pipeline = this.Content as MyGrid;
            var Material_In = Grid_Add_Pipeline.Children[6] as MyComboBox;
            var Pipeline_Type = Grid_Add_Pipeline.Children[4] as MyComboBox;
            var Diameter_In = Grid_Add_Pipeline.Children[12] as MyTextBox;
            var Wall_Width_In = Grid_Add_Pipeline.Children[16] as MyTextBox;
            var Length_In = Grid_Add_Pipeline.Children[8] as MyTextBox;

            var Material_Out = Grid_Add_Pipeline.Children[23] as MyComboBox;
            var Pipeline_Out_Type = Grid_Add_Pipeline.Children[21] as MyComboBox;
            var Diameter_Out = Grid_Add_Pipeline.Children[29] as MyTextBox;
            var Wall_Width_Out = Grid_Add_Pipeline.Children[33] as MyTextBox;
            var Length_Out = Grid_Add_Pipeline.Children[25] as MyTextBox;

            var Diameter_In_Measure_Choose = Grid_Add_Pipeline.Children[13] as MyComboBox;
            var Wall_Width_In_Measure_Choose = Grid_Add_Pipeline.Children[17] as MyComboBox;
            var Length_In_Measure_Choose = Grid_Add_Pipeline.Children[9] as MyComboBox;

            var Diameter_Out_Measure_Choose = Grid_Add_Pipeline.Children[30] as MyComboBox;
            var Wall_Width_Out_Measure_Choose = Grid_Add_Pipeline.Children[34] as MyComboBox;
            var Length_Out_Measure_Choose = Grid_Add_Pipeline.Children[26] as MyComboBox;


            if ((double.TryParse(Diameter_In.Text, out result) == false) || (double.TryParse(Wall_Width_In.Text, out result) == false) ||
                (double.TryParse(Length_In.Text, out result) == false) || (double.TryParse(Diameter_Out.Text, out result) == false) ||
                (double.TryParse(Wall_Width_Out.Text, out result) == false) || (double.TryParse(Length_Out.Text, out result) == false))
                g = false;

            if (g == false)
            {
                MessageBox.Show("Некоторые данные введены неправильно");
            }

            if (g == true)
            {
                //MessageBox.Show("Все отлично!");

                double DiaInNew = double.Parse(Diameter_In.Text);
                if (Diameter_In_Measure_Choose.SelectedIndex == 1)
                {
                    DiaInNew /= 100;
                }
                if (Diameter_In_Measure_Choose.SelectedIndex == 2)
                {
                    DiaInNew /= 1000;
                }

                double WallWidthInNew = double.Parse(Wall_Width_In.Text);
                if (Wall_Width_In_Measure_Choose.SelectedIndex == 1)
                {
                    WallWidthInNew /= 100;
                }
                if (Wall_Width_In_Measure_Choose.SelectedIndex == 2)
                {
                    WallWidthInNew /= 1000;
                }

                double LengthInNew = double.Parse(Length_In.Text);
                if (Length_In_Measure_Choose.SelectedIndex == 1)
                {
                    LengthInNew /= 100;
                }
                if (Length_In_Measure_Choose.SelectedIndex == 2)
                {
                    LengthInNew /= 1000;
                }
                
                double DiaOutNew = double.Parse(Diameter_Out.Text);
                if (Diameter_Out_Measure_Choose.SelectedIndex == 1)
                {
                    DiaOutNew /= 100;
                }
                if (Diameter_Out_Measure_Choose.SelectedIndex == 2)
                {
                    DiaOutNew /= 1000;
                }
                
                double WallWidthOutNew = double.Parse(Wall_Width_Out.Text);
                if (Wall_Width_Out_Measure_Choose.SelectedIndex == 1)
                {
                    WallWidthOutNew /= 100;
                }
                if (Wall_Width_Out_Measure_Choose.SelectedIndex == 2)
                {
                    WallWidthOutNew /= 1000;
                }
                
                double LengthOutNew = double.Parse(Length_Out.Text);
                if (Length_Out_Measure_Choose.SelectedIndex == 1)
                {
                    LengthOutNew /= 100;
                }
                if (Length_Out_Measure_Choose.SelectedIndex == 2)
                {
                    LengthOutNew /= 1000;
                }

                var Pip = new PipelineRound(Material_In.SelectedIndex + 1, Pipeline_Type.SelectedIndex + 1, DiaInNew, WallWidthInNew, LengthInNew);
                var lip_In = new LiquidInPipeline(liq, Pip);
                var Pip2 = new PipelineRound(Material_Out.SelectedIndex + 1, Pipeline_Out_Type.SelectedIndex + 1, DiaOutNew, WallWidthOutNew, LengthOutNew);
                var lip_Out = new LiquidInPipeline(liq, Pip2);

                Network.Create(lip_In, lip_Out);

                Resistance rst = new Resistance(lip_In, lip_Out, Temperature_Out,NK_dou,VP);
                rst.Show();
            }
        }

        private void Help_Add_Pipeline_Click(object sender, RoutedEventArgs e)
        {
            var Grid_Add_Pipeline = this.Content as MyGrid;
            var Help_Add_Pipeline = Grid_Add_Pipeline.Children[3] as MyButton;
            MessageBox.Show("Выбран пункт Справка в окне добавления всасывающего трубопровода");
        }


    }
}