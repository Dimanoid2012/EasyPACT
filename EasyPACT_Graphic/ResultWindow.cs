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
    public class ResultWindow : Window
    {
        double Temperature_Out;
        double NK_dou;
        double VP;

        public ResultWindow(double Temperature_Out, double NK_dou, double VP)
        {
            this.Temperature_Out = Temperature_Out;
            this.NK_dou = NK_dou;
            this.VP = VP;

            MyLabel proizv = new MyLabel("proizv", 270, 330, 0, 0, "Введите производительность насоса, кг/с:");

            MyTextBox proizv_txt = new MyTextBox("proizv_txt", 60, 560, 332, 0, 0);

            MyButton proizv_but = new MyButton("", 100, 630, 330, 0, 0, "Добавить");
            proizv_but.Visibility = Visibility.Visible;
            proizv_but.Click += proizv_but_Click;


            MyLabel Machine = new MyLabel("Machine", 270, 130, 0, 0, "Требуемый насос", 15);
            Machine.FontWeight = FontWeights.Bold;

            MyLabel MachineRes = new MyLabel("MachineRes", 270, 160, 0, 0, "");

            MyLabel TO = new MyLabel("TO", 270, 200, 0, 0, "Требуемый теплообменный аппарат", 15);
            TO.FontWeight = FontWeights.Bold;

            MyLabel TORes = new MyLabel("TORes", 270, 230, 0, 0, "");

            Image Result_Img_Top = new Image()
            {
                Width = 900,
                Height = 90,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Result_Img_Top",
                Margin = new Thickness(0, 0, 0, 0)
            };

            BitmapImage Result_Img_Top_bi = new BitmapImage();
            Result_Img_Top_bi.BeginInit();
            Result_Img_Top_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Results.jpg");
            Result_Img_Top_bi.EndInit();
            Result_Img_Top.Source = Result_Img_Top_bi;

            Image Result_Img_Bottom = new Image()
            {
                Width = 900,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "Result_Img_Bottom",
                Margin = new Thickness(0, 366, 0, 0)
            };

            BitmapImage Result_Img_Bottom_bi = new BitmapImage();
            Result_Img_Bottom_bi.BeginInit();
            Result_Img_Bottom_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\EasyPACT_Bottom_First.jpg");
            Result_Img_Bottom_bi.EndInit();
            Result_Img_Bottom.Source = Result_Img_Bottom_bi;

            Image Animation = new Image()
            {
                Width = 200,
                Height = 270,
                HorizontalAlignment = HorizontalAlignment.Left,
                Name = "Animation",
                Margin = new Thickness(10, 40, 0, 0)
            };

            BitmapImage Animation_bi = new BitmapImage();
            Animation_bi.BeginInit();
            Animation_bi.UriSource = new Uri(@"C:\EasyPACT\EasyPACT_Graphic\Animation.png");
            Animation_bi.EndInit();
            Animation.Source = Animation_bi;

            MyButton Next_last = new MyButton("Next_last", 150, 0, 0, 20, 7, "Закрыть");
            Next_last.HorizontalAlignment = HorizontalAlignment.Right;
            Next_last.VerticalAlignment = VerticalAlignment.Bottom;
            Next_last.Background = Brushes.DarkGreen;
            Next_last.FontSize = 12;
            //Next_0.FontWeight = FontWeights.Bold;
            Next_last.Foreground = Brushes.LightGray;
            Next_last.Click += Next_last_Click;

            MyButton Cred = new MyButton("Cred", 80, 18, 0, 0, 7, "Разработчики");
            Cred.Foreground = Brushes.LightGray;
            Cred.VerticalAlignment = VerticalAlignment.Bottom;
            Cred.Background = Brushes.DarkGreen;
            Cred.FontSize = 10;
            Cred.Click += OpenCredits_Click;

            
            
            
            
            Grid ResultWindow = new MyGrid();
            ResultWindow.Name = "ResultWindow";
            ResultWindow.Children.Add(Result_Img_Top);//0
            ResultWindow.Children.Add(Result_Img_Bottom);//1
            ResultWindow.Children.Add(Animation);//2
            ResultWindow.Children.Add(Machine);//3
            ResultWindow.Children.Add(MachineRes);//4
            ResultWindow.Children.Add(TO);//5
            ResultWindow.Children.Add(TORes);//6
            ResultWindow.Children.Add(Next_last);//7
            ResultWindow.Children.Add(Cred);//8
            ResultWindow.Children.Add(proizv);//9
            ResultWindow.Children.Add(proizv_txt);//10
            ResultWindow.Children.Add(proizv_but);//11
            


            this.Content = ResultWindow;
            this.Title = "Ввод результатов - EasyPACT";
            this.MinWidth = 908;
            this.MaxWidth = 908;
            this.MinHeight = 450;
            this.MaxHeight = 450;

        }

        private void Next_last_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenCredits_Click(object sender, RoutedEventArgs e)
        {
            Credits crd = new Credits();
            crd.Show();
        }

        private void proizv_but_Click(object sender, RoutedEventArgs e)
        {
            var ResultWindow = this.Content as MyGrid;
            var proizv_txt = ResultWindow.Children[10] as MyTextBox;
            var MachineRes = ResultWindow.Children[4] as MyLabel;
            var TORes = ResultWindow.Children[6] as MyLabel;
            var proizv_but = ResultWindow.Children[11] as MyButton;
            
            //double proizv_ch = 0;
            double result = 0;
            if (double.TryParse(proizv_txt.Text, out result))
            {
                Network.Get().SetProductivity(result);
                if ((Network.Get().HeatExchanger == null) & (Network.Get().Pump == null))
                {
                    MyLabel SpeedIn = new MyLabel("SpeedIn", 10, 180, 0, 0, "", 10);

                    MyLabel SpeedOut = new MyLabel("SpeedOut", 100, 100, 0, 0, "", 10);

                    

                    proizv_but.Visibility = Visibility.Hidden;
                    proizv_txt.IsEnabled = false;
                    try
                    {
                        Network.Get().ChooseHeatExchanger(Temperature_Out, Temperature_Out + 20);
                        TORes.Content = Network.Get().HeatExchanger.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно подобрать теплообменный аппарат");
                    }
                    try
                    {
                        Network.Get().ChooseCentrifugalPump(VP);
                        ResultWindow.Children.Add(new MyLabel("PumpFr", 42, 234, 0, 0, String.Format("{0:f2} об/с", Network.Get().Pump.FrequencyOfRotation), 10));//15
                        ResultWindow.Children.Add(new MyLabel("PumpPr", 44, 248, 0, 0, String.Format("{0:f2} кВт", Network.Get().Pump.Capacity), 10));
                        MachineRes.Content = Network.Get().Pump.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно подобрать насос");
                    }
                    ResultWindow.Children.Add(new MyLabel("SpeedIn", 10, 202, 0, 0, String.Format("{0:f2} м/с", Network.Get().VacuumLine.Speed), 10));//12
                    ResultWindow.Children.Add(new MyLabel("SpeedOut", 93, 93, 0, 0, String.Format("{0:f2} м/с", Network.Get().ForcingLine.Speed), 10));//13
                    ResultWindow.Children.Add(new MyLabel("TempIn", 30, 320, 0, 0, String.Format("{0:f2} C", Network.Get().VacuumLine.Liquid.Temperature), 10));//14
                    ResultWindow.Children.Add(new MyLabel("TempOut", 150, 140, 0, 0, String.Format("{0:f2} C", Temperature_Out), 10));
                }
            }
            else
            {
                MessageBox.Show("Введите числовое значение производительности в кг/с");
            }
            //Network.Get().SetProductivity(double.Parse(proizv_txt.Text));// это поле
            
        }

    }
}