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
        public MainWindow()
        {
            InitializeComponent();
            foreach (var a in Database.Query("select name from liquid_list")[0])
            {
                Liquid.Items.Add(a);
            }
            Liquid.SelectedIndex = 0;
            var liquidTypeLbl = new Label
                                        {
                                            Name = "Liquid_type_lbl",
                                            Content = "Выберите тип жидкости:",
                                            Width = 144,
                                            Height = 28,
                                            HorizontalAlignment = HorizontalAlignment.Left,
                                            VerticalAlignment = VerticalAlignment.Top,
                                            Margin = new Thickness(12, 12, 0, 0)
                                        };
            var grid = new Grid();
            grid.Name = "MyGrid";
            grid.Children.Add(liquidTypeLbl);
            this.Content = grid;
            var liquidTypeLbl2 = new Label
            {
                Name = "Liquid_type_lbl2",
                Content = "Выберите тип жидкости:",
                Width = 144,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(24, 24, 0, 0)
            };
            grid.Children.Add(liquidTypeLbl2);
        }

        private void Liquid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                Liquid.SelectedIndex = 0;
            }
        }
        
        private void Pressure_Input_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Measure_choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
