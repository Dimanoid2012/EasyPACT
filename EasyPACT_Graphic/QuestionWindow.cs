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
    public class QuestionWindow : Window
    {
        public QuestionWindow()
        {
            Grid QuestionWindowGrid = new Grid();
            QuestionWindowGrid.Name = "QuestionWindow";

            MyLabel EndAddingLiquid_lbl = new MyLabel("EndAddingLiqiud_lbl", "Вы действительно хотите отменить добавление новой жидкости?");

            MyButton yesButton = new MyButton("yesButton", 50, 0, 0, 10, 10, "Да");
            yesButton.HorizontalAlignment = HorizontalAlignment.Right;
            yesButton.VerticalAlignment = VerticalAlignment.Bottom;
            yesButton.Height = 23;
            yesButton.Click += yesButton_Click;

            MyButton noButton = new MyButton("noButton", 50, 0, 0, 65, 10, "Нет");
            noButton.HorizontalAlignment = HorizontalAlignment.Right;
            noButton.VerticalAlignment = VerticalAlignment.Bottom;
            noButton.Height = 23;
            noButton.Click += noButton_Click;

            QuestionWindowGrid.Children.Add(EndAddingLiquid_lbl);
            QuestionWindowGrid.Children.Add(yesButton);
            QuestionWindowGrid.Children.Add(noButton);

            Content = QuestionWindowGrid;
            Width = 400;
            Height = 100;
            Title = "Отмена добавления новой жидкости";
        }

        bool returnClosing = false;
        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажато Да");
            //var QuestionWindowGrid = this.Content as MyGrid;
            //var Press_Yes = QuestionWindowGrid.Children[2] as MyButton;
            Close();
            returnClosing = true;
        }

        
        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажато Нет");
            Close();
            //var Cancel_Third_Pressure_Add = Grid_Add_Liquid.GetElementByName("Third_Pressure_" + (i + 1).ToString()) as MyTextBox;

        }

    }
}