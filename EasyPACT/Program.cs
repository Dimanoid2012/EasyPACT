using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyPACT
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Разделитель - точка
            var inf = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            System.Threading.Thread.CurrentThread.CurrentCulture = inf;
            inf.NumberFormat.NumberDecimalSeparator = ".";
            // Вывод курсовой
            /*var liq = new LiquidMix("6,7", 0.28, 20, 760);
            var pipIn = new PipelineRound(33, 1, 0.083, 0.003, 8.1);
            pipIn.AddLocalResistance("1 1");
            for (var i = 0; i < 7; i++)
                pipIn.AddLocalResistance("4 90 1.0");
            var lipIn = new LiquidInPipeline(liq, pipIn);
            lipIn.MassFlow = 32.0*1000/3600;
            var pipOut = new PipelineRound(33, 1, 0.069, 0.003, 50);
            pipOut.AddLocalResistance("2 1");
            for (var i = 0; i < 3; i++)
                pipOut.AddLocalResistance("6 80");
            pipOut.AddLocalResistance(7);
            pipOut.AddLocalResistance(String.Format("3 0.0268 {0}", pipOut.Diameter));
            for (var i = 0; i < 10; i++)
                pipOut.AddLocalResistance("4 90 1");
            var lipOut = new LiquidInPipeline(liq, pipOut);
            lipOut.MassFlow = 32.0*1000/3600;
            Console.WriteLine("Затраты давления на создание скорости: {0} Па",lipOut.LossOfPressureUponCreationOfSpeed());
            Console.WriteLine("Потеря давления на трение во вс. ТП: {0} Па",lipIn.LossOfPressureUponAFriction());
            Console.WriteLine("Потеря давления на трение в нагн. ТП: {0} Па",lipOut.LossOfPressureUponAFriction());
            Console.WriteLine("Потеря давления на мс во вс. ТП: {0} Па",lipIn.LossOfPressureUponLocalResistances());
            Console.WriteLine("Потеря давления на мс в нагн. ТП: {0} Па",lipOut.LossOfPressureUponLocalResistances());
            Console.WriteLine("Потеря давления на подъем жидкости: {0} Па", lipOut.LossOfPressureUponLifting(8.4));
            Console.WriteLine("Разность давлений: {0} Па", lipOut.Liquid.Pressure - lipIn.Liquid.Pressure);
            var lossOfPressure = lipOut.LossOfPressureUponCreationOfSpeed() + lipIn.LossOfPressureUponAFriction() +
                                 lipOut.LossOfPressureUponAFriction() + lipIn.LossOfPressureUponLocalResistances() +
                                 lipOut.LossOfPressureUponLocalResistances() + lipOut.LossOfPressureUponLifting(8.4) +
                                 lipOut.Liquid.Pressure - lipIn.Liquid.Pressure;
            Console.WriteLine("Гидравлическое сопротивление ТП: {0} Па", lossOfPressure);*/
            var win = new Window();
            

            //Console.ReadKey();
        }
    }
}
