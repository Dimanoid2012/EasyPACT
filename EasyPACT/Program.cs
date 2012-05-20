using System;
using System.Globalization;

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
            var liq = new LiquidMix("6,7", 0.28, 20, 760);
            var pip = new PipelineRound(33, 1, 0.083, 0.003, 8.1);
            var vacLip = new LiquidInPipeline(liq, pip);
            pip = new PipelineRound(33, 1, 0.069, 0.003, 50);
            var forLip = new LiquidInPipeline(liq, pip);
            var pump = new CentrifugalPump(37);
            var network = Network.Create(vacLip, forLip, pump);
            network.Pump.Run(20.0928*60);
            Console.WriteLine(network.Productivity*liq.Density*3600/1000);
            Console.ReadKey();
        }
    }
}
