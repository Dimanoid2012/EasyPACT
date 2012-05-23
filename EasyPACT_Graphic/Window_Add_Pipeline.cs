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

            MyButton OK_Add_Pipeline = new MyButton("OK_Add_Liquid", 100, 0, 0, 30, 30, "Добавить");
            OK_Add_Pipeline.Height = 30;
            OK_Add_Pipeline.HorizontalAlignment = HorizontalAlignment.Right;
            OK_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //OK_Add_Liquid.Click += OK_Add_Liquid_Click;

            MyButton Help_Add_Pipeline = new MyButton("Help_Add_Liquid", 100, 30, 0, 0, 30, "Помощь");
            Help_Add_Pipeline.Height = 30;
            Help_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //Help_Add_Liquid.Click += Help_Add_Liquid_Click;

            MyButton Cancel_Add_Pipeline = new MyButton("Cancel_Add_Pipeline", 100, 0, 0, 140, 30, "Отменить");
            Cancel_Add_Pipeline.Height = 30;
            Cancel_Add_Pipeline.HorizontalAlignment = HorizontalAlignment.Right;
            Cancel_Add_Pipeline.VerticalAlignment = VerticalAlignment.Bottom;
            //Cancel_Add_Liquid.Click += Cancel_Add_Liquid_Click;

            MyLabel Add_New_Pipeline_lbl = new MyLabel("Add_New_Pipeline_lbl", 330, 75, 0, 0, "Давление");

            MyLabel Pipeline_Type_lbl = new MyLabel("Pipeline_Type_lbl", 12, 120, 0, 0, "Давление");

            MyComboBox Pipeline_Type = new MyComboBox("Pipeline_Type", 450, 125, 120, 0, 0);
            foreach (var a in Database.Query("select name from XII")[0])
            {
                Pipeline_Type.Items.Add(a);
            }

            Grid_Add_Pipeline.Children.Add(OK_Add_Pipeline);
            Grid_Add_Pipeline.Children.Add(Cancel_Add_Pipeline);
            Grid_Add_Pipeline.Children.Add(Help_Add_Pipeline);
            Grid_Add_Pipeline.Children.Add(Add_New_Pipeline_lbl);
            Grid_Add_Pipeline.Children.Add(Pipeline_Type_lbl);
            Grid_Add_Pipeline.Children.Add(Pipeline_Type);

            Content = Grid_Add_Pipeline;
            Width = 900;
            Height = 500;
            Title = "Добавление нового трубопровода";
        }
    }
}