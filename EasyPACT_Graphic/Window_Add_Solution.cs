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
    public class Window_Add_Solution : Window
    {
        public Window_Add_Solution()
        {
            Grid Grid_Add_Solution = new MyGrid();
            Grid_Add_Solution.Name = "Grid_Add_Solution";

            MyLabel Add_New_Solution_lbl = new MyLabel("Add_New_Solution_lbl", 30, 110, 0, 0, "Выберите компоненты, образующие смесь:");

            MyComboBox First_Compound = new MyComboBox("", 200, 30, 140, 0, 0);
            First_Compound.Items.Add("Выберите компонент");
            foreach (var a in Database.Query("select name from liquid_list")[0])
            {
                First_Compound.Items.Add(a);
            }
            First_Compound.Items.Add("Добавить жидкость...");
            First_Compound.SelectedIndex = 0;
            First_Compound.SelectionChanged += First_Compound_Selection_Changed;

            MyComboBox Second_Compound = new MyComboBox("", 200, 240, 140, 0, 0);
            Second_Compound.Items.Add("Выберите компонент");
            foreach (var a in Database.Query("select name from liquid_list")[0])
            {
                Second_Compound.Items.Add(a);
            }
            Second_Compound.SelectedIndex = 0;
            Second_Compound.SelectionChanged += Second_Compound_Selection_Changed;

            MyButton Add_New_Compound = new MyButton("Liquid_Add", 200, 30, 180, 0, 0, "Добавление новой жидкости");
            Add_New_Compound.Height = 30;
            Add_New_Compound.Visibility = Visibility.Hidden;
            Add_New_Compound.Click += Add_New_Compound_Click;

            MyButton Help = new MyButton("Help", 70, 18, 0, 0, 7, "Справка");
            Help.Height = 30;
            Help.HorizontalAlignment = HorizontalAlignment.Left;
            Help.VerticalAlignment = VerticalAlignment.Bottom;
            Help.Background = Brushes.DarkGreen;
            Help.Click += Help_Click;            

            MyButton Solution_Add = new MyButton("Add_New_Compound", 150, 0, 0, 20, 7, "Добавить смесь");
            Solution_Add.Height = 30;
            Solution_Add.HorizontalAlignment = HorizontalAlignment.Right;
            Solution_Add.VerticalAlignment = VerticalAlignment.Bottom;
            Solution_Add.Background = Brushes.DarkGreen;
            Solution_Add.Click += Solution_Add_Click;
            /*
            MyButton Cancel_Solution_Add = new MyButton("Cancel_Solution_Add", 100, 0, 0, 140, 30, "Отменить");
            Cancel_Solution_Add.Height = 30;
            Cancel_Solution_Add.HorizontalAlignment = HorizontalAlignment.Right;
            Cancel_Solution_Add.VerticalAlignment = VerticalAlignment.Bottom;
            Cancel_Solution_Add.Click += Cancel_Solution_Add_Click;
            */

            Image Add_Solution_Img_Top = new Image()
            {
                Width = 650,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Add_Solution_Img_Top",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Add_Solution_Img_Top_bi = new BitmapImage();
            Add_Solution_Img_Top_bi.BeginInit();
            Add_Solution_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_New_Solution_Top.jpg");
            Add_Solution_Img_Top_bi.EndInit();
            Add_Solution_Img_Top.Source = Add_Solution_Img_Top_bi;



            Image Add_Solution_Img_Bottom = new Image()
            {
                Width = 900,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Add_Solution_Img_Bottom",
                Margin = new Thickness(0, 366, 0, 0)
            };

            BitmapImage Add_Solution_Img_Bottom_bi = new BitmapImage();
            Add_Solution_Img_Bottom_bi.BeginInit();
            Add_Solution_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_New_Solution_Bottom.jpg");
            Add_Solution_Img_Bottom_bi.EndInit();
            Add_Solution_Img_Bottom.Source = Add_Solution_Img_Bottom_bi;





            Grid container_Solution = new Grid();
            container_Solution.Name = "container_Solution";

            container_Solution.Children.Add(Add_Solution_Img_Top);//0
            container_Solution.Children.Add(First_Compound);//1
            container_Solution.Children.Add(Second_Compound);//2
            container_Solution.Children.Add(Add_New_Compound);//3
            container_Solution.Children.Add(Add_New_Solution_lbl);//4
            container_Solution.Children.Add(Add_Solution_Img_Bottom);//5
            container_Solution.Children.Add(Help);//6
            container_Solution.Children.Add(Solution_Add);//7
            //container_Solution.Children.Add(Cancel_Solution_Add);//6

            this.Content = container_Solution;
            this.Title = "Добавление новой смеси";
            this.Width = 658;
            this.Height = 450;
            this.MinWidth = 658;
            this.MaxWidth = 658;
            this.MinHeight = 450;
            this.MaxHeight = 450;
        }

        private void First_Compound_Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var First_Compound = grid.Children[1] as MyComboBox;
            var Second_Compound = grid.Children[2] as MyComboBox;
            var Add_New_Compound = grid.Children[3] as MyButton;
            var Help = grid.Children[6] as MyButton;
            var Solution_Add = grid.Children[7] as MyButton;

            if (First_Compound.SelectedIndex == First_Compound.Items.Count - 1)
            {
                Add_New_Compound.Visibility = Visibility.Visible;
            }
            else
            {
                Add_New_Compound.Visibility = Visibility.Hidden;
            }
        }

        private void Second_Compound_Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var grid = this.Content as Grid;
            var First_Compound = grid.Children[1] as MyComboBox;
            var Second_Compound = grid.Children[2] as MyComboBox;
            var Add_New_Solution = grid.Children[3] as MyButton;
            var Help = grid.Children[6] as MyButton;
            var Solution_Add = grid.Children[7] as MyButton;
        }

        private void Add_New_Compound_Click(object sender, RoutedEventArgs e)
        {
            Window_Add_Liquid New_Liquid = new Window_Add_Liquid();
            New_Liquid.Show();
        }

        private void Solution_Add_Click(object sender, RoutedEventArgs e)
        {
            var grid = this.Content as Grid;
            var First_Compound = grid.Children[1] as MyComboBox;
            var Second_Compound = grid.Children[2] as MyComboBox;
            var Add_New_Solution = grid.Children[3] as MyButton;
            var Help = grid.Children[6] as MyButton;
            var Solution_Add = grid.Children[7] as MyButton;

            if ((First_Compound.SelectedIndex == 0) || (Second_Compound.SelectedIndex == 0))
            {
                MessageBox.Show("Выберите компоненты, образующие жидкость!");
            }

            if ((First_Compound.SelectedIndex == Second_Compound.SelectedIndex) &&
                (First_Compound.SelectedIndex != 0) && (Second_Compound.SelectedIndex != 0))
            {
                MessageBox.Show("Два одинаковых компонента не образуют бинарную смесь. Требуется выбрать 2 разных компонента.");
            }

            if (First_Compound.SelectedIndex == First_Compound.Items.Count - 1)
            {
                MessageBox.Show("Добавьте новую жидкость, или выберите уже существующую из списка.");
            }
            
            MessageBox.Show("Все отлично!");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выбран пункт Помощь в окне добавления новой смеси.");
        }
        /*
        private void Cancel_Solution_Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно будет закрыто.");
            Close();
        }
        */
    }
}