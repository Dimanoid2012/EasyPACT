﻿using System;
using System.Data;
using System.Data.SqlServerCe;
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
            //var ans = Database.Query("insert into liquid_list(name,formula,molar_mass) values('Бутан','C4H10',58.1)");
            //var ans = Database.Query("select * from liquid_list");
            /*string ConnectionString = "Data Source=|DataDirectory|\\EasyPACT.sdf";
            SqlCeConnection Connect = new SqlCeConnection(ConnectionString);
            Connect.Open();
            var command = Connect.CreateCommand();
            command.CommandTimeout = Connect.ConnectionTimeout;
            command.Connection = Connect;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from liquid_list";
            var table = new DataTable();
            var adapter = new SqlCeDataAdapter(command);
            adapter.Fill(table);
            command.CommandText = "insert into liquid_list ([name],[formula],molar_mass) values('Бутан','C4H10',58.01)";
            adapter.UpdateCommand = command;
            var row = table.NewRow();
            row.BeginEdit();
            row.SetField("name", "Бутан");
            row.SetField("formula", "C4H10");
            row.SetField("molar_mass", Convert.ToSingle(58.01));
            row.EndEdit();
            table.Rows.Add(row);
            table.AcceptChanges();
            adapter.Update(table);
            table.AcceptChanges();  
            //table.AcceptChanges();
            
            
            Connect.Close();*/
            //var ht = new HeatExchangerPipe(14);
            var liq = new LiquidMix("11,12", 0.28, 20, 760);
            var pip = new PipelineRound(33, 1, 0.069, 0.0025, 52);
            pip.AddLocalResistance(1);
            pip.AddLocalResistance(12);
            pip.AddLocalResistance(65.5);
            pip.AddLocalResistance(2.1);
            pip.AddLocalResistance(7);
            var lip = new LiquidInPipeline(liq, pip);
            pip = new PipelineRound(33, 1, 0.092, 0.0025, 6);
            pip.AddLocalResistance("1 1");
            for (var i = 0; i < 7; i++)
                pip.AddLocalResistance("4 90 1");
            var lip2 = new LiquidInPipeline(liq, pip);
            var net = Network.Create(lip2, lip);
            net.SetProductivity(30000/3600.0);
            Network.Get().ChooseHeatExchanger(liq.BoilingPoint, liq.BoilingPoint + 20);
            net.ChooseCentrifugalPump(5.6);
            Console.WriteLine("Смесь: {0}", liq.Name);
            Console.WriteLine("\tТемпература: {0} град.", liq.Temperature);
            Console.WriteLine("\tДавление: {0} мм рт. ст.", liq.Pressure);
            Console.WriteLine("\tТемпература кипения: {0} град.", liq.BoilingPoint);
            Console.WriteLine("\tВязкость: {0} Па*с", liq.ViscosityDynamic);
            Console.WriteLine("\tТеплоемкость: {0} Дж/кг К", liq.ThermalCapacity);
            Console.WriteLine("\t: {0} Дж/кг К", liq.ThermalCapacity);
            Console.WriteLine("Трубопровод всасывающий");
            Console.WriteLine("\tРазмеры: {0}x{1} м", net.VacuumLine.Pipeline.ExternalDiameter,
                              net.VacuumLine.Pipeline.ExternalDiameter - net.VacuumLine.Pipeline.Diameter);
            Console.WriteLine("\tДлина: {0} м",net.VacuumLine.Pipeline.Length);
            Console.WriteLine("\tКоэффициент м.с.: {0}",net.VacuumLine.Pipeline.FactorOfLocalResistance);
            Console.WriteLine("Трубопровод нагнетательный");
            Console.WriteLine("\tРазмеры: {0}x{1} м", net.ForcingLine.Pipeline.ExternalDiameter,
                              net.ForcingLine.Pipeline.ExternalDiameter - net.ForcingLine.Pipeline.Diameter);
            Console.WriteLine("\tДлина: {0} м", net.ForcingLine.Pipeline.Length);
            Console.WriteLine("\tКоэффициент м.с.: {0}", net.ForcingLine.Pipeline.FactorOfLocalResistance);
            Console.WriteLine("Смесь во всасывающем ТП");
            Console.WriteLine("\tСкорость: {0} м/с",net.VacuumLine.Speed);
            Console.WriteLine("\tКритерий Рейнольдса: {0}",net.VacuumLine.Re);
            Console.WriteLine("\tКоэффициент трения: {0}", net.VacuumLine.FactorOfAFriction);
            Console.WriteLine("\tПотеря давления на трение: {0} Па",net.VacuumLine.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря давления на м.с.: {0} Па",net.VacuumLine.LossOfPressureUponLocalResistances());
            Console.WriteLine("\tПотеря давления: {0} Па", net.VacuumLine.LossOfPressureUponLocalResistances() + net.VacuumLine.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря напора: {0} м",
                              (net.VacuumLine.LossOfPressureUponLocalResistances() +
                               net.VacuumLine.LossOfPressureUponAFriction())/net.VacuumLine.Liquid.Density/9.81);
            Console.WriteLine("Смесь в нагнетательном ТП");
            Console.WriteLine("\tСкорость: {0} м/с", net.ForcingLine.Speed);
            Console.WriteLine("\tКритерий Рейнольдса: {0}", net.ForcingLine.Re);
            Console.WriteLine("\tКоэффициент трения: {0}", net.ForcingLine.FactorOfAFriction);
            Console.WriteLine("\tПотеря давления на трение: {0} Па", net.ForcingLine.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря давления на м.с.: {0} Па", net.ForcingLine.LossOfPressureUponLocalResistances());
            Console.WriteLine("\tПотеря давления: {0} Па", net.ForcingLine.LossOfPressureUponLocalResistances() + net.ForcingLine.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря напора: {0} м",
                              (net.ForcingLine.LossOfPressureUponLocalResistances() +
                               net.ForcingLine.LossOfPressureUponAFriction()) / net.ForcingLine.Liquid.Density / 9.81);
            Console.WriteLine("Смесь в трубном пространстве ТО");
            Console.WriteLine("\tСкорость: {0} м/с", net.HeatExchanger.LiquidInPipeline.Speed);
            Console.WriteLine("\tКритерий Рейнольдса: {0}", net.HeatExchanger.LiquidInPipeline.Re);
            Console.WriteLine("\tКоэффициент трения: {0}", net.HeatExchanger.LiquidInPipeline.FactorOfAFriction);
            Console.WriteLine("\tПотеря давления на трение: {0} Па", net.HeatExchanger.LiquidInPipeline.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря давления на м.с.: {0} Па", net.HeatExchanger.LiquidInPipeline.LossOfPressureUponLocalResistances());
            Console.WriteLine("\tПотеря давления: {0} Па", net.HeatExchanger.LiquidInPipeline.LossOfPressureUponLocalResistances() + net.HeatExchanger.LiquidInPipeline.LossOfPressureUponAFriction());
            Console.WriteLine("\tПотеря напора: {0} м",
                              (net.HeatExchanger.LiquidInPipeline.LossOfPressureUponLocalResistances() +
                               net.HeatExchanger.LiquidInPipeline.LossOfPressureUponAFriction()) / net.HeatExchanger.LiquidInPipeline.Liquid.Density / 9.81);
            Console.WriteLine("Затраты на создание скорости потока: {0} Па", net.ForcingLine.LossOfPressureUponCreationOfSpeed());
            Console.WriteLine("Затраты на подъем жидкости: {0} Па", net.ForcingLine.LossOfPressureUponLifting(5.6));
            Console.WriteLine("Полный напор: {0} м", (net.VacuumLine.LossOfPressureUponLocalResistances() +
                                                 net.VacuumLine.LossOfPressureUponAFriction())/
                                                net.VacuumLine.Liquid.Density/9.81 +
                                                (net.ForcingLine.LossOfPressureUponLocalResistances() +
                                                 net.ForcingLine.LossOfPressureUponAFriction())/
                                                net.ForcingLine.Liquid.Density/9.81 +
                                                (net.HeatExchanger.LiquidInPipeline.LossOfPressureUponLocalResistances() +
                                                 net.HeatExchanger.LiquidInPipeline.LossOfPressureUponAFriction())/
                                                net.HeatExchanger.LiquidInPipeline.Liquid.Density/9.81 +
                                                net.ForcingLine.LossOfPressureUponLifting(5.6) / 9.81 / net.ForcingLine.Liquid.Density);
            Console.WriteLine("Для смеси {0} с параметрами t={1} и p={2} подходит ТО {3}, чтобы ее вскипятить.", liq.Id,
                              liq.Temperature, liq.Pressure, net.HeatExchanger.Id);
            Console.WriteLine("Выбранный насос: {0}.",net.Pump.Brand);
            var liq2 = new LiquidPure("6", 20, 760);
            Console.WriteLine("Коэффициент теплопроводности ацетона: {0}",liq2.ThermalConductivity / 1.163);
            Console.ReadKey();
        }
    }
}
